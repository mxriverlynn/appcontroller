namespace ApplicationControllerExample.AppController
{
	public interface IApplicationController
	{
		void Run<TWorkflow>() where TWorkflow : IApplicationWorkflow;
		void Execute<T>(T commandData);
		void Raise<T>(T eventData);
	}
}