using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SimpleOrgChart.App.NewEmployeeProcess.SelectEmployeeManager;
using SimpleOrgChart.Model;
using SpecUnit;

namespace SimpleOrgChart.UnitTests
{
	public class SelectManagerSpec
	{

		public class SelectManagerSpecContext : ContextSpecification
		{

			protected ISelectEmployeeManagerView view;
			private IEmployeeRepository employeeRepository;
			protected Employee employee;
			protected Employee manager;
			protected IList<Employee> managerList;
			protected Employee selectedManager;

			protected override void SharedContext()
			{
				employee = new Employee("First Name", "Last Name", "firstname.lastname@example.com");
				manager = new Employee("First Name", "Last Name", "firstname.lastname@example.com");
				managerList = new List<Employee> { manager };

				view = MockRepository.GenerateMock<ISelectEmployeeManagerView>();

				employeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
				employeeRepository.Stub(r => r.GetManagerList()).Return(managerList);
			}

			protected SelectEmployeeManagerPresenter GetSelectEmployeeManagerPresenter()
			{
				SelectEmployeeManagerPresenter presenter = new SelectEmployeeManagerPresenter(view, employeeRepository);
				return presenter;
			}
		}

		[TestFixture]
		[Concern("Select Employee Manager")]
		public class When_selecting_an_employees_manager : SelectManagerSpecContext
		{

			protected override void Context()
			{
				SelectEmployeeManagerPresenter presenter = GetSelectEmployeeManagerPresenter();
				presenter.ManagerSelected(manager);

				selectedManager = presenter.GetManagerFor(employee);
			}

			[Test]
			[Observation]
			public void Should_show_the_employee_that_a_manager_is_being_selected_for()
			{
				view.AssertWasCalled(v => v.ShowEmployee(employee));
			}

			[Test]
			[Observation]
			public void Should_show_a_list_of_all_employees_to_choose_from()
			{
				view.AssertWasCalled(v => v.ShowListOfManagers(managerList));
			}

			[Test]
			[Observation]
			public void Should_run_the_manager_selection_process()
			{
				view.AssertWasCalled(v => v.Run());
			}

			[Test]
			[Observation]
			public void Should_return_the_selected_manager()
			{
				selectedManager.ShouldEqual(manager);
			}

		}

	}

}
