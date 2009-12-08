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
	public class AddNewEmployeeSpecs
	{

		public class KickoffAddNewEmployeeContext : ContextSpecification
		{

			private IEmployeeRepository employeeRepo;
			private IOrgChartView view;
			private IList<Employee> employeeList;
			private Employee bob;
			protected IApplicationController appController;

			protected override void SharedContext()
			{
				view = MockRepository.GenerateMock<IOrgChartView>();
				bob = new Employee("Bob", "Jones", "bob.jones@example.com");
				employeeList = new List<Employee> { bob };

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

		public class AddNewEmployeeCommandContext : ContextSpecification
		{
			protected AddNewEmployeeService addNewEmployeeService;

		}

		public class AddNewEmployeeSpecsContext : ContextSpecification
		{
			protected IGetNewEmployeeInfo getNewEmployeeInfo;
			protected IGetEmployeeManager getEmployeeManager;
			protected IApplicationController appController;
			protected EmployeeInfo employeeInfo;

			protected override void SharedContext()
			{
				employeeInfo = new EmployeeInfo { FirstName = "Jim", LastName = "Jones", Email = "jim.jones@example.com" };
				getNewEmployeeInfo = MockRepository.GenerateMock<IGetNewEmployeeInfo>();

				Employee newEmployee = new Employee("Bob", "Jones", "bob.jones@example.com");
				getEmployeeManager = MockRepository.GenerateMock<IGetEmployeeManager>();
				getEmployeeManager.Stub(g => g.GetManagerFor(null)).IgnoreArguments().Return(newEmployee);

				appController = MockRepository.GenerateMock<IApplicationController>();
			}

			protected AddNewEmployeeService GetAddNewEmployeeService()
			{
				AddNewEmployeeService service = new AddNewEmployeeService(getNewEmployeeInfo, getEmployeeManager, appController);
				return service;
			}
		}

		[TestFixture]
		[Concern("Add New Employee")]
		public class When_requesting_to_add_a_new_employee : KickoffAddNewEmployeeContext
		{

			protected override void Context()
			{
				OrgChartPresenter presenter = GetPresenter();
				presenter.Run();

				presenter.AddNewEmployeeRequested();
			}

			[Test]
			[Observation]
			public void Should_kick_off_the_add_new_employee_process()
			{
				appController.AssertWasCalled(c => c.Execute<AddNewEmployeeData>(null), mo => mo
					.IgnoreArguments()
					.Constraints(Is.TypeOf<AddNewEmployeeData>())
				);
			}

		}

		[TestFixture]
		[Concern("Add New Employee")]
		public class When_adding_a_new_employee : AddNewEmployeeSpecsContext
		{

			protected override void Context()
			{
				Result<EmployeeInfo> result = new Result<EmployeeInfo>(ServiceResult.Ok, employeeInfo);
				getNewEmployeeInfo.Stub(g => g.Get()).Return(result);

				AddNewEmployeeService service = GetAddNewEmployeeService();
				service.Execute(new AddNewEmployeeData());
			}

			[Test]
			[Observation]
			public void Should_request_the_employee_information()
			{
				getNewEmployeeInfo.AssertWasCalled(x => x.Get());
			}

			[Test]
			[Observation]
			public void Should_request_the_employees_manager()
			{
				getEmployeeManager.AssertWasCalled(x => x.GetManagerFor(null), mo => mo.IgnoreArguments().Constraints(Is.TypeOf<Employee>()));
			}

			[Test]
			[Observation]
			public void Should_create_the_new_employee()
			{
				getEmployeeManager.AssertWasCalled(g => g.GetManagerFor(null), mo => mo.IgnoreArguments());
			}

			[Test]
			[Observation]
			public void Should_notify_of_new_employee_added()
			{
				appController.AssertWasCalled(a => a.Raise<EmployeeAddedEvent>(null), mo => mo
					.IgnoreArguments()
					.Constraints(Is.TypeOf<EmployeeAddedEvent>())
				);
			}

		}

		[TestFixture]
		[Concern("Add New Employee")]
		public class When_cancelling_the_addition_of_a_new_employee : AddNewEmployeeSpecsContext
		{

			protected override void Context()
			{
				Result<EmployeeInfo> result = new Result<EmployeeInfo>(ServiceResult.Cancel);
				getNewEmployeeInfo.Stub(g => g.Get()).Return(result);
				AddNewEmployeeService service = GetAddNewEmployeeService();
				service.Execute(new AddNewEmployeeData());
			}

			[Test]
			[Observation]
			public void Should_not_notify_of_new_employee_added()
			{
				appController.AssertWasNotCalled(a => a.Raise<EmployeeAddedEvent>(null), mo => mo.IgnoreArguments());
			}

		}

	}
}
