using System;

namespace EventAggregator
{
	public class EventHandlerOptions
	{
		private WeakReference HandlerReference { get; set; }

		internal Action<Exception> ErrorHandler { get; set; }

		internal Object EventHandler
		{
			get
			{
				return HandlerReference.Target;
			}
		}

		internal bool IsAlive
		{
			get
			{
				return HandlerReference.IsAlive;
			}
		}

		public EventHandlerOptions(object eventHandler)
		{
			HandlerReference = new WeakReference(eventHandler, false);
		}

		public void WithErrorHandler(Action<Exception> errorHandler)
		{
			ErrorHandler = errorHandler;
		}
	}
}