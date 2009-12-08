using SimpleOrgChart.Model;

namespace SimpleOrgChart.App.NewEmployeeProcess
{
	public interface IGetEmployeeManager
	{
		Employee GetManagerFor(Employee employee);
	}
}