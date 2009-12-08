using System.Collections.Generic;
using SimpleOrgChart.Model;

namespace SimpleOrgChart.App.NewEmployeeProcess.SelectEmployeeManager
{
	public class SelectEmployeeManagerPresenter: IGetEmployeeManager
	{
		private ISelectEmployeeManagerView View { get; set; }
		private IEmployeeRepository EmployeeRepository { get; set; }
		private Employee SelectedManager { get; set; }

		public SelectEmployeeManagerPresenter(ISelectEmployeeManagerView view, IEmployeeRepository employeeRepository)
		{
			View = view;
			View.Presenter = this;
			EmployeeRepository = employeeRepository;
		}

		public void ManagerSelected(Employee manager)
		{
			SelectedManager = manager;
		}

		public Employee GetManagerFor(Employee employee)
		{
			IList<Employee> managerList = EmployeeRepository.GetManagerList();
			View.ShowListOfManagers(managerList);

			View.ShowEmployee(employee);

			View.Run();

			return SelectedManager;
		}
	}
}