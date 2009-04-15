using System.Windows.Forms;
using ApplicationControllerExample.App;
using ApplicationControllerExample.View;
using StructureMap;

namespace ApplicationControllerExample
{

	public class AppContext : ApplicationContext
	{
		
		private IContainer Container { get; set; }

		public AppContext(IContainer container)
		{
			Container = container;
			MainForm = GetMainForm();
		}

		private Form GetMainForm()
		{
			Form1 mainForm = new Form1();
			Container.Inject<IMainView>(mainForm);
			Container.GetInstance<MainPresenter>();
			return mainForm;
		}

	}

}