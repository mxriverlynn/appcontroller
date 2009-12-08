using System;
using System.Collections.Generic;

namespace EventAggregator
{
	public interface IEventPublisher
	{
		EventHandlerOptions RegisterHandler<T>(IEventHandler<T> eventHandler);
		IList<EventHandlerOptions> RegisterHandlers(object eventHandler);		
		
		void UnregisterHandler<T>(IEventHandler<T> eventHandler);
		void UnregisterHandlers(object eventHandler);
		
		void Publish<T>(T eventData);
		T GetMostRecentPublication<T>();

		void OnHandlerError(Action<Exception> errorHandler);
	}
}
