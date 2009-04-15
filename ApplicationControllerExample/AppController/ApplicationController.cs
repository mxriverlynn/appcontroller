using System;
using System.Collections.Generic;
using StructureMap;

namespace ApplicationControllerExample.AppController
{
	public class ApplicationController: IApplicationController
	{
		private IContainer IoC { get; set; }
		private IDictionary<Type, ICommand> CommandRegistry { get; set; }

		public ApplicationController(IContainer ioc)
		{
			IoC = ioc;
			CommandRegistry = new Dictionary<Type, ICommand>();
		}

		public void RegisterCommand<T>(ICommand<T> command)
		{
			Type commandType = typeof (T);
			CommandRegistry[commandType] = command;
		}

		public void Run<TWorkflow>() where TWorkflow: IApplicationWorkflow
		{
			TWorkflow workflow = IoC.GetInstance<TWorkflow>();
			workflow.Run();
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