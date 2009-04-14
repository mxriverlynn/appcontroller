namespace ApplicationControllerExample.App
{
	public interface IApplicationWorkflow
	{
		void Handle<T>(T eventData);
	}
}