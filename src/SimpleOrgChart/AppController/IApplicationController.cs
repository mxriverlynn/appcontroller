namespace SimpleOrgChart.AppController
{
	public interface IApplicationController
	{
		void Execute<T>(T commandData);
		R Query<T, R>(T queryData);
		void Raise<T>(T eventData);
	}
}