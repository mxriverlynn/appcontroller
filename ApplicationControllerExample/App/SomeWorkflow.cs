using StructureMap;

namespace ApplicationControllerExample.App
{
	public class SomeWorkflow : IApplicationWorkflow
	{
		private IContainer IoC { get; set; }

		public SomeWorkflow(IContainer ioc)
		{
			IoC = ioc;
		}

		public void Handle<T>(T eventData)
		{
			IAnotherView view = IoC.GetInstance<IAnotherView>();
			view.Run();
		}
	}
}