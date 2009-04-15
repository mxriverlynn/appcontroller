using System.Windows.Forms;
using ApplicationControllerExample.App;
using ApplicationControllerExample.AppController;
using ApplicationControllerExample.Model;
using ApplicationControllerExample.View;
using EventAggregator;
using StructureMap.Configuration.DSL;

namespace ApplicationControllerExample
{

	public class DefaultRegistry : Registry
	{

		public DefaultRegistry()
		{
			ForRequestedType<ApplicationContext>()
				.TheDefault.Is.OfConcreteType<AppContext>();

			ForRequestedType<IApplicationController>()
				.TheDefault.Is.OfConcreteType<ApplicationController>();

			ForRequestedType<MainPresenter>()
				.TheDefault.Is.OfConcreteType<MainPresenter>();

			ForRequestedType<IEventPublisher>()
				.AsSingletons()
				.TheDefault.Is.OfConcreteType<EventPublisher>();

			ForRequestedType<ICommand<SomeCommandData>>()
				.TheDefault.Is.OfConcreteType<SomeCommand>();

			ForRequestedType<ISomeWorkflowService>()
				.TheDefault.Is.OfConcreteType<SomeWorkflowService>();

			ForRequestedType<IPartOfTheProcess>()
				.TheDefault.Is.OfConcreteType<SecondaryPresenter>();

			ForRequestedType<ISecondaryView>()
				.TheDefault.Is.OfConcreteType<Form2>();

			RegisterInterceptor(new EventAggregatorInterceptor());
		}

	}
}