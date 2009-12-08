namespace SimpleOrgChart.AppController
{
	public interface IApplicationController
	{
		void Execute<T>(T commandData);
		void Raise<T>(T eventData);
	}
}