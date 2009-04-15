using System;
using System.Windows.Forms;
using StructureMap;

namespace ApplicationControllerExample
{

	static class Program
	{

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Container ioc = new Container();
			BootStrapper bootStrapper = new BootStrapper(ioc);
			ApplicationContext appcontext = bootStrapper.GetAppContext();

			Application.Run(appcontext);
		}

	}

}
