namespace ApplicationControllerExample.App
{
	public class SomeWorkflowService: ISomeWorkflowService
	{
		private IPartOfTheProcess PartOfTheProcess { get; set; }

		public SomeWorkflowService(IPartOfTheProcess partOfTheProcess)
		{
			PartOfTheProcess = partOfTheProcess;
		}

		public void Run()
		{
			PartOfTheProcess.DoThatThing();
		}
	}
}