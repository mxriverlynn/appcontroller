using System.Collections.Generic;
using EventAggregator;
using SimpleOrgChart.App.NewEmployeeProcess;
using SimpleOrgChart.AppController;
using SimpleOrgChart.Model;

namespace SimpleOrgChart.App
{

	public class OrgChartPresenter: IEventHandler<EmployeeAddedEvent>
	{

		private IOrgChartView View { get; set; }
		private IApplicationController AppController { get; set; }
		private IEmployeeRepository Repository { get; set; }

		public OrgChartPresenter(IOrgChartView view, IApplicationController appController, IEmployeeRepository repository)
		{
			View = view;
			AppController = appController;
			View.Presenter = this;
			Repository = repository;
		}

		public void Run()
		{
			ShowEmployeeHierarchy();
		}

		public void EmployeeSelected(Employee selectedEmployee)
		{
			AppController.Raise(new EmployeeSelectedEvent(selectedEmployee));
		}

		public void AddNewEmployeeRequested()
		{
			AppController.Execute(new AddNewEmployeeData());
		}

		public void Handle(EmployeeAddedEvent employeeAddedEvent)
		{
			ShowEmployeeHierarchy();
		}

		private void ShowEmployeeHierarchy()
		{
			IList<Employee> employeeList = Repository.GetEmployeeOrgChart();
			View.DisplayEmployeeHierarchy(employeeList);
		}

	}

}