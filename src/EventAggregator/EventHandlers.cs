using System;
using System.Collections.Generic;
using System.Linq;

namespace EventAggregator
{
	internal class EventHandlers
	{
		private Action<Exception> ErrorHandler { get; set; }
		private IDictionary<Type, IList<EventHandlerOptions>> Handlers { get; set; }

		internal EventHandlers()
		{
			Handlers = new Dictionary<Type, IList<EventHandlerOptions>>();
		}

		internal void Add<T>(EventHandlerOptions handler)
		{
			Type handleType = typeof(T);
			Add(handleType, handler);
		}

		internal void Add(Type eventType, EventHandlerOptions handler)
		{
			if (!Handlers.ContainsKey(eventType))
				Handlers[eventType] = new List<EventHandlerOptions>();

			Handlers[eventType].Add(handler);
		}

		internal void Remove<T>(IEventHandler<T> handler)
		{
			Type handleType = typeof(T);
			Remove(handleType, handler);
		}

		internal void Remove<T>(IEnumerable<EventHandlerOptions> handlers)
		{
			if (handlers.Count() == 0)
				return;

			IList<EventHandlerOptions> handlerOptions = Handlers[typeof(T)];
			foreach(var handler in handlers)
			{
				handlerOptions.Remove(handler);
			}
		}

		internal void Remove(Type eventType, object handler)
		{
			if (!Handlers.ContainsKey(eventType))
				return;
			
			IList<EventHandlerOptions> handlerOptions = Handlers[eventType];
			IList<EventHandlerOptions> filteredOptions = handlerOptions.Where(h => (h.EventHandler == handler)).ToList();
			for (int i = 0; i < filteredOptions.Count; i++)
			{
				var option = filteredOptions[i];
				handlerOptions.Remove(option);
			}
		}

		internal void Handle<T>(T eventData)
		{
			IList<EventHandlerOptions> handlersToUnregister = new List<EventHandlerOptions>();
			IEnumerable<EventHandlerOptions> handlers = GetEventHandlers<T>();
			foreach (EventHandlerOptions handlerOptions in handlers)
			{
				try
				{
					if (!handlerOptions.IsAlive)
					{
						handlersToUnregister.Add(handlerOptions);
						continue;
					}

					IEventHandler<T> eventHandler = handlerOptions.EventHandler as IEventHandler<T>;
					if (eventHandler != null)
						eventHandler.Handle(eventData);
				}
				catch (Exception ex)
				{
					HandleError(handlerOptions, ex);
				}
			}
			Remove<T>(handlersToUnregister);
		}

		internal void OnHandlerError(Action<Exception> errorHandler)
		{
			ErrorHandler = errorHandler;
		}

		private void HandleError(EventHandlerOptions eventhandlerOptions, Exception ex)
		{
			if (ErrorHandler != null)
				ErrorHandler(ex);

			if (eventhandlerOptions.ErrorHandler != null)
				eventhandlerOptions.ErrorHandler(ex);
		}

		private IEnumerable<EventHandlerOptions> GetEventHandlers<T>()
		{
			Type handleType = typeof(T);
			IList<EventHandlerOptions> handlers = new List<EventHandlerOptions>();

			if (Handlers.ContainsKey(handleType))
			{
				handlers = Handlers[handleType];
			}

			return handlers;
		}

	}
}
