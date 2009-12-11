using System.Collections.Generic;
using System.Windows.Forms;
using EventAggregator;
using SimpleOrgChart.App;
using SimpleOrgChart.App.NewEmployeeProcess;
using SimpleOrgChart.App.NewEmployeeProcess.SelectEmployeeManager;
using SimpleOrgChart.App.NewEmployeeProcess.SupplyEmployeeInfo;
using SimpleOrgChart.AppController;
using SimpleOrgChart.Model;
using SimpleOrgChart.Repositories;
using SimpleOrgChart.View;
using StructureMap.Configuration.DSL;

namespace SimpleOrgChart
{

	public class DefaultRegistry : Registry
	{

		public DefaultRegistry()
		{
			ForRequestedType<IQuery<EmployeeOrgChart, IList<Employee>>>()
				.TheDefault.Is.OfConcreteType<InMemoryEmployeeRepository>();

			ForRequestedType<ApplicationContext>()
				.TheDefault.Is.OfConcreteType<AppContext>();

			ForRequestedType<IApplicationController>()
				.TheDefault.Is.OfConcreteType<ApplicationController>();

			ForRequestedType<IEventPublisher>()
				.AsSingletons()
				.TheDefault.Is.OfConcreteType<EventPublisher>();

			ForRequestedType<IOrgChartView>()
				.TheDefaultIsConcreteType<MainForm>()
				.OnCreation((i,v) => i.GetInstance<EmployeeDetailPresenter>());

			ForRequestedType<IEmployeeRepository>()
				.TheDefaultIsConcreteType<InMemoryEmployeeRepository>();

			ForRequestedType<IEmployeeDetailView>()
				.TheDefaultIsConcreteType<ViewEmployeeDetailControl>();

			ForRequestedType<ICommand<AddNewEmployeeData>>()
				.TheDefaultIsConcreteType<AddNewEmployeeService>();

			ForRequestedType<IGetNewEmployeeInfo>()
				.TheDefaultIsConcreteType<NewEmployeeInfoPresenter>();

			ForRequestedType<INewEmployeeInfoView>()
				.TheDefaultIsConcreteType<NewEmployeeInfoForm>();

			ForRequestedType<IGetEmployeeManager>()
				.TheDefaultIsConcreteType<SelectEmployeeManagerPresenter>();

			ForRequestedType<ISelectEmployeeManagerView>()
				.TheDefaultIsConcreteType<SelectEmployeeManagerForm>();

			RegisterInterceptor(new EventAggregatorInterceptor());
		}

	}

}