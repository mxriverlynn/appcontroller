using System;

namespace EventAggregator
{
	public class EventHandlerOptions
	{
		internal Action<Exception> ErrorHandler { get; set; }
		internal object EventHandler { get; set; }
		
		public EventHandlerOptions(object eventHandler)
		{
			EventHandler = eventHandler;
		}

		public void WithErrorHandler(Action<Exception> errorHandler)
		{
			ErrorHandler = errorHandler;
		}
	}
}