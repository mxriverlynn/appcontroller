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

		public void RegisterCommand<T>(ICommand<T> command)
		{
			Type commandType = typeof (T);
			CommandRegistry[commandType] = command;
		}

		public void Run<T>(T workflowData)
		{
			Workflow.Handle(workflowData);
		}

		public void Execute<T>(T commandParameters)
		{
			Type commandType = typeof (T);
			if (CommandRegistry.ContainsKey(commandType))
			{
				ICommand<T> command = CommandRegistry[commandType] as ICommand<T>;
				if (command != null)
					command.Execute(commandParameters);
			}
		}

		public void Raise<T>(T eventData)
		{
			
		}
	}
}