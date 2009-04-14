namespace ApplicationControllerExample.App
{
	public interface IApplicationController
	{
		void Run<T>(T workflowData);
		void Execute<T>(T commandData);
		void Raise<T>(T eventData);
	}
}