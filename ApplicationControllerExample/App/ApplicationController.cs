using System;
using System.Collections.Generic;

namespace ApplicationControllerExample.App
{
	public class ApplicationController: IApplicationController
	{
		private IApplicationWorkflow Workflow { get; set; }
		private IDictionary<Type, ICommand> CommandRegistry { get; set; }

		public ApplicationController(IApplicationWorkflow workflow)
		{
			Workflow = workflow;
			CommandRegistry = new Dictionary<Type, ICommand>();
		}

		public void RegisterCommand<T>(ICommand command)
		{
			Type commandType = typeof (T);
			CommandRegistry[commandType] = command;
		}

		public void Run<T>(T eventData)
		{
			Workflow.Handle(eventData);
		}

		public void ExecuteCommand<T>()
		{
			Type commandType = typeof (T);
			if (CommandRegistry.ContainsKey(commandType))
			{
				ICommand command = CommandRegistry[commandType];
				command.Execute();
			}
		}
	}
}