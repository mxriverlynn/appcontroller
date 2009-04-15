using System;
using System.Windows.Forms;
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

			});

			Application.Run();
		}
	}
}
