using System.Collections.Generic;

namespace SimpleOrgChart.Model
{
	public interface IEmployeeRepository
	{
		IList<Employee> GetEmployeeOrgChart();
		IList<Employee> GetManagerList();
	}
}