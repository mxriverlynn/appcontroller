using System;
using System.Windows.Forms;
using ApplicationControllerExample.App;
using ApplicationControllerExample.View;
using StructureMap;

namespace ApplicationControllerExample
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Container ioc = new Container(reg =>
			{
				reg.ForRequestedType<IAnotherView>()
					.TheDefault.Is.OfConcreteType<Form2>();

				reg.ForRequestedType<IApplicationWorkflow>()
					.TheDefault.Is.OfConcreteType<SomeWorkflow>();
				
				reg.ForRequestedType<IApplicationController>()
					.TheDefault.Is.OfConcreteType<ApplicationController>();
			});
			
			IApplicationController appController = ioc.GetInstance<IApplicationController>();

			Form1 mainForm = new Form1();
			SomePresenter presenter = new SomePresenter(mainForm, appController);

			Application.Run(mainForm);
		}
	}
}
