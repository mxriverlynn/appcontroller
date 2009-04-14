using System.Windows.Forms;
using ApplicationControllerExample.App;

namespace ApplicationControllerExample.View
{
	public partial class Form2 : Form, IAnotherView
	{
		public Form2()
		{
			InitializeComponent();
		}

		public void Run()
		{
			ShowDialog();
		}
	}
}