namespace SimpleOrgChart.App
{
	public interface IEmployeeDetailView
	{
		void DisplayEmployeeName(string firstName, string lastName);
		void DisplayEmployeeEmail(string email);
	}
}