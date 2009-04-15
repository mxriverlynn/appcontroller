using System.Windows.Forms;
using ApplicationControllerExample.AppController;

namespace ApplicationControllerExample.Model
{
	public class SomeCommand: ICommand<SomeCommandData>
	{
		private ISomeWorkflowService WorkflowService { get; set; }

		public SomeCommand(ISomeWorkflowService workflowService)
		{
			WorkflowService = workflowService;
		}

		public void Execute(SomeCommandData commandData)
		{
			WorkflowService.Run();
		}
	}
}