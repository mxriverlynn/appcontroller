using System.Windows.Forms;
using ApplicationControllerExample.AppController;

namespace ApplicationControllerExample.Model
{
	public class SomeCommand: ICommand<SomeCommandData>
	{
		public void Execute(SomeCommandData commandData)
		{
			MessageBox.Show("This is the command");
		}
	}
}