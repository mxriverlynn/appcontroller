using System;
using System.Collections.Generic;

namespace EventAggregator
{
	public class EventPublisher : IEventPublisher
	{
		private EventHandlers EventHandlers { get; set; }
		private LatchManager<Type> Latches { get; set; }
		private IDictionary<Type, object> Publications { get; set; }

		public EventPublisher()
		{
			Latches = new LatchManager<Type>();
			EventHandlers = new EventHandlers();
			Publications = new Dictionary<Type, object>();
		}

		public EventHandlerOptions RegisterHandler<T>(IEventHandler<T> eventHandler)
		{
			EventHandlerOptions handlerOptions = new EventHandlerOptions(eventHandler);
			EventHandlers.Add<T>(handlerOptions);
			return handlerOptions;
		}

		public IList<EventHandlerOptions> RegisterHandlers(object eventHandler)
		{
			List<EventHandlerOptions> handlerOptionsList = new List<EventHandlerOptions>();
			Type[] handlers = eventHandler.GetType().GetInterfaces();

			Type eventHandlerType = typeof (IEventHandler<>);
			
			foreach(Type handler in handlers)
			{
				if (handler.Name.Equals(eventHandlerType.Name))
				{
					Type eventType = handler.GetGenericArguments()[0];
					EventHandlerOptions handlerOptions = new EventHandlerOptions(eventHandler);
					EventHandlers.Add(eventType, handlerOptions);
					handlerOptionsList.Add(handlerOptions);
				}
			}
			
			return handlerOptionsList;
		}

		public void UnregisterHandler<T>(IEventHandler<T> eventHandler)
		{
			EventHandlers.Remove(eventHandler);
		}

		public void UnregisterHandlers(object eventHandler)
		{
			Type[] handlers = eventHandler.GetType().GetInterfaces();

			Type eventHandlerType = typeof(IEventHandler<>);

			foreach (Type handler in handlers)
			{
				if (handler.Name.Equals(eventHandlerType.Name))
				{
					Type eventType = handler.GetGenericArguments()[0];
					EventHandlers.Remove(eventType, eventHandler);
				}
			}
		}

		public void Publish<T>(T eventData)
		{
			Type handleType = typeof(T);
			Latches.RunWithLock(handleType, delegate
			{
				SetPublication(eventData);
				EventHandlers.Handle(eventData);
			});
		}

		public T GetMostRecentPublication<T>()
		{
			T publicationValue;
			
			if (Publications.ContainsKey(typeof(T)))
				publicationValue = (T)Publications[typeof(T)];
			else
				publicationValue = default(T);

			return publicationValue;
		}

		public void OnHandlerError(Action<Exception> errorHandler)
		{
			EventHandlers.OnHandlerError(errorHandler);
		}

		private void SetPublication<T>(T eventData)
		{
			if (Publications.ContainsKey(typeof(T)))
				Publications[typeof(T)] = eventData;
			else
				Publications.Add(typeof(T), eventData);
		}
	}
}
