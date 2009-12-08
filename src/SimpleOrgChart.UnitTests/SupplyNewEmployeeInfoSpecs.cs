using NUnit.Framework;
using Rhino.Mocks;
using SimpleOrgChart.App;
using SimpleOrgChart.App.NewEmployeeProcess;
using SimpleOrgChart.App.NewEmployeeProcess.SupplyEmployeeInfo;
using SpecUnit;

namespace SimpleOrgChart.UnitTests
{
	public class SupplyNewEmployeeInfoSpecs
	{

		public class SupplyNewEmployeeInfoSpecsContext : ContextSpecification
		{
			protected INewEmployeeInfoView view;
			protected Result<EmployeeInfo> result;

			protected override void SharedContext()
			{
				view = MockRepository.GenerateMock<INewEmployeeInfoView>();
			}

			protected NewEmployeeInfoPresenter GetNewEmployeeInfoPresenter()
			{
				NewEmployeeInfoPresenter presenter = new NewEmployeeInfoPresenter(view);
				return presenter;
			}
		}

		[TestFixture]
		[Concern("Supply New Employee Info")]
		public class When_supplying_new_employee_info : SupplyNewEmployeeInfoSpecsContext
		{

			protected override void Context()
			{
				NewEmployeeInfoPresenter presenter = GetNewEmployeeInfoPresenter();
				presenter.FirstNameSupplied("FirstName");
				presenter.LastNameSupplied("LastName");
				presenter.EmailSupplied("firstname.lastname@example.com");
				presenter.Next();

				result = presenter.Get();
			}

			[Test]
			[Observation]
			public void Should_run_the_info_retrieval()
			{
				view.AssertWasCalled(v => v.Run());
			}

			[Test]
			[Observation]
			public void Should_return_the_supplied_info()
			{
				EmployeeInfo employeeInfo = result.Data;
				employeeInfo.FirstName.ShouldEqual("FirstName");
				employeeInfo.LastName.ShouldEqual("LastName");
				employeeInfo.Email.ShouldEqual("firstname.lastname@example.com");
			}

			[Test]
			[Observation]
			public void Should_return_successfully()
			{
				result.ServiceResult.ShouldEqual(ServiceResult.Ok);
			}

		}

		[TestFixture]
		[Concern("Supply New Employee Info")]
		public class When_cancelling_out_of_supplying_the_employee_info : SupplyNewEmployeeInfoSpecsContext
		{

			protected override void Context()
			{
				NewEmployeeInfoPresenter presenter = GetNewEmployeeInfoPresenter();
				presenter.Cancel();

				result = presenter.Get();
			}

			[Test]
			[Observation]
			public void Should_not_provide_the_employee_info()
			{
				result.Data.ShouldBeNull();
			}

			[Test]
			[Observation]
			public void Should_return_a_result_of_cancel()
			{
				result.ServiceResult.ShouldEqual(ServiceResult.Cancel);
			}

		}


	}
}
