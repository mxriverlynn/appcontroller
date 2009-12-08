using System.Collections.Generic;

namespace SimpleOrgChart.Model
{
	public class Employee
	{
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string Email { get; private set; }
		
		public IList<Employee> Employees { get; private set; }

		public string DisplayName
		{
			get { return string.Format("{1}, {0}, ({2})", FirstName, LastName, Email); }
		}

		public Employee(string firstName, string lastName, string email)
		{
			Employees = new List<Employee>();
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}

	}

}