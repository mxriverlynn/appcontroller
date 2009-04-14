namespace ApplicationControllerExample.App
{
	public interface IApplicationController
	{
		void Run<T>(T eventData);
		void ExecuteCommand<T>();
		void RegisterCommand<T>(ICommand command);
	}
}