using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using SimpleOrgChart.App;
using SimpleOrgChart.App.NewEmployeeProcess;
using SimpleOrgChart.AppController;
using SimpleOrgChart.Model;
using SpecUnit;

namespace SimpleOrgChart.UnitTests
{

	public class ViewOrgChartSpecs
	{

		public class ViewOrgChartSpecsContext : ContextSpecification
		{
			private IEmployeeRepository employeeRepo;
			protected IOrgChartView view;
			protected IList<Employee> employeeList;
			protected Employee bob;
			protected IApplicationController appController;

			protected override void SharedContext()
			{
				view = MockRepository.GenerateMock<IOrgChartView>();
				bob = new Employee("Bob", "Jones", "bob.jones@example.com");
				employeeList = new List<Employee>{bob};

				appController = MockRepository.GenerateMock<IApplicationController>();
				
				employeeRepo = MockRepository.GenerateMock<IEmployeeRepository>();
				employeeRepo.Stub(r => r.GetEmployeeOrgChart()).Return(employeeList);

			}

			protected OrgChartPresenter GetPresenter()
			{
				OrgChartPresenter presenter = new OrgChartPresenter(view, appController, employeeRepo);
				return presenter;
			}

		}

		[TestFixture]
		[Concern("View Org Chart")]
		public class When_viewing_the_org_chart : ViewOrgChartSpecsContext
		{

			protected override void Context()
			{
				OrgChartPresenter presenter = GetPresenter();
				presenter.Run();
			}

			[Test]
			[Observation]
			public void Should_show_the_hiearchy_of_employees()
			{
				view.AssertWasCalled(v => v.DisplayEmployeeHierarchy(employeeList));
			}

		}

		[TestFixture]
		[Concern("View Org Chart")]
		public class When_selecting_an_employee : ViewOrgChartSpecsContext
		{

			protected override void Context()
			{
				OrgChartPresenter presenter = GetPresenter();
				presenter.Run();

				presenter.EmployeeSelected(bob);
			}

			[Test]
			[Observation]
			public void Should_send_notification_of_the_selected_employee()
			{
				appController.AssertWasCalled(c => c.Raise<EmployeeSelectedEvent>(null), mo => mo
					.IgnoreArguments()
					.Constraints(Is.TypeOf<EmployeeSelectedEvent>())
				);
			}

		}

		[TestFixture]
		[Concern("View Org Chart")]
		public class When_a_new_employee_has_been_added : ViewOrgChartSpecsContext
		{

			protected override void Context()
			{
				OrgChartPresenter presenter = GetPresenter();
				presenter.Handle(new EmployeeAddedEvent());
			}

			[Test]
			[Observation]
			public void Should_update_the_org_chart_display()
			{
				
			}

		}


	}

}
