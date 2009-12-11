using System.Collections.Generic;

namespace SimpleOrgChart.Model
{
	public interface IEmployeeRepository
	{
		IList<Employee> GetManagerList();
	}
}