using ApplicationControllerExample.AppController;
using ApplicationControllerExample.Model;

namespace ApplicationControllerExample.App
{
	public class SomeWorkflowService: ISomeWorkflowService
	{
		private IApplicationController AppController { get; set; }
		private IPartOfTheProcess PartOfTheProcess { get; set; }

		public SomeWorkflowService(IApplicationController appController, IPartOfTheProcess partOfTheProcess)
		{
			AppController = appController;
			PartOfTheProcess = partOfTheProcess;
		}

		public void Run()
		{
			PartOfTheProcess.DoThatThing();
		}
	}
}