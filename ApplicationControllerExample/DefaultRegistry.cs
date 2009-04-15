using System.Windows.Forms;
using ApplicationControllerExample.App;
using ApplicationControllerExample.AppController;
using ApplicationControllerExample.Model;
using ApplicationControllerExample.View;
using EventAggregator;
using StructureMap.Attributes;
using StructureMap.Configuration.DSL;

namespace ApplicationControllerExample
{

	public class DefaultRegistry : Registry
	{

		public DefaultRegistry()
		{
			ForRequestedType<ApplicationContext>()
				.TheDefaultIsConcreteType<AppContext>();

			ForRequestedType<IApplicationController>()
				.TheDefaultIsConcreteType<ApplicationController>();

			ForRequestedType<MainPresenter>()
				.TheDefaultIsConcreteType<MainPresenter>();

			ForRequestedType<IEventPublisher>()
				.TheDefaultIsConcreteType<EventPublisher>()
				.CacheBy(InstanceScope.Singleton);

			ForRequestedType<ICommand<SomeCommandData>>()
				.TheDefaultIsConcreteType<SomeCommand>();

			ForRequestedType<ISomeWorkflowService>()
				.TheDefaultIsConcreteType<SomeWorkflowService>();

			ForRequestedType<IPartOfTheProcess>()
				.TheDefaultIsConcreteType<SecondaryPresenter>();

			ForRequestedType<ISecondaryView>()
				.TheDefaultIsConcreteType<Form2>();

			RegisterInterceptor(new EventAggregatorInterceptor());
		}

	}
}