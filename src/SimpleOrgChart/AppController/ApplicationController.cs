using EventAggregator;
using StructureMap;

namespace SimpleOrgChart.AppController
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

		public R Query<T, R>(T queryData)
		{
			IQuery<T,R> query = Container.TryGetInstance<IQuery<T,R>>();
			R value = default(R);
			if (query != null)
				value = query.Query(queryData);
			return value;
		}

		public void Raise<T>(T eventData)
		{
			EventPublisher.Publish(eventData);
		}

	}

}