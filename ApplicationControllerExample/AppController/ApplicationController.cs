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
		}

		public void Execute<T>(T commandData)
		{
			ICommand<T> command = Container.GetInstance<ICommand<T>>();
			command.Execute(commandData);
		}

		public void Raise<T>(T eventData)
		{
			EventPublisher.Publish(eventData);
		}

	}

}