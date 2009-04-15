using EventAggregator;
using StructureMap;

namespace ApplicationControllerExample.AppController
{

	public class ApplicationController : IApplicationController
	{

		private IContainer Container { get; set; }
		private IEventPublisher EventPublisher { get; set; }

		public ApplicationController(IContainer container, IEventPublisher eventPublisher)
		{
			Container = container;
			EventPublisher = eventPublisher;
			
			Container.Inject<IApplicationController>(this);
		}

		public void Execute<T>(T commandData)
		{
			ICommand<T> command = Container.TryGetInstance<ICommand<T>>();
			if (command != null)
				command.Execute(commandData);
		}

		public void Raise<T>(T eventData)
		{
			EventPublisher.Publish(eventData);
		}

	}

}