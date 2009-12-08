using System.Collections.Generic;
using SimpleOrgChart.Model;

namespace SimpleOrgChart.Repositories
{
	
	public class InMemoryEmployeeRepository: IEmployeeRepository
	{

		private static readonly IList<Employee> employeeList = new List<Employee>{new Employee("Bob", "Jones", "bob.jones@example.com")};

		public IList<Employee> GetEmployeeOrgChart()
		{
			return employeeList;
		}

		public IList<Employee> GetManagerList()
		{
			IList<Employee> flattenedList = new List<Employee>();
			foreach(Employee employee in employeeList)
			{
				flattenedList.Add(employee);
				IList<Employee> subEmployees = GetSubEmployees(employee);
				foreach (Employee subEmployee in subEmployees)
					flattenedList.Add(subEmployee);
			}
			return flattenedList;
		}

		private IList<Employee> GetSubEmployees(Employee manager)
		{
			IList<Employee> flattenedList = new List<Employee>();
			foreach (Employee employee in manager.Employees)
			{
				flattenedList.Add(employee);
				IList<Employee> subEmployees = GetSubEmployees(employee);
				foreach(Employee subEmployee in subEmployees)
					flattenedList.Add(subEmployee);
			}
			return flattenedList;			
		}
	}

}
