using SimpleOrgChart.Model;

namespace SimpleOrgChart.App
{
	public class EmployeeSelectedEvent
	{
		public Employee Employee { get; private set; }

		public EmployeeSelectedEvent(Employee employee)
		{
			Employee = employee;
		}
	}
}