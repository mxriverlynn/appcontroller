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

			ForRequestedType<IMainView>()
				.TheDefault.Is.OfConcreteType<Form1>();

			ForRequestedType<MainPresenter>()
				.TheDefault.Is.OfConcreteType<MainPresenter>();

			ForRequestedType<IEventPublisher>()
				.TheDefault.Is.OfConcreteType<EventPublisher>();

			ForRequestedType<ICommand<SomeCommandData>>()
				.TheDefault.Is.OfConcreteType<SomeCommand>();

			RegisterInterceptor(new EventAggregatorInterceptor());
		}

	}

}