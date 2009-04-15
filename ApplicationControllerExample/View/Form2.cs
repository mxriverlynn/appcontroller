using System.Windows.Forms;
using ApplicationControllerExample.App;

namespace ApplicationControllerExample.View
{

	public partial class Form2 : Form, ISecondaryView
	{

		public SecondaryPresenter Presenter { get; set; }

		public Form2()
		{
			InitializeComponent();
		}

		public void Run()
		{
			ShowDialog();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Presenter.Whatever();
		}

		private void clickThisYoToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			Presenter.ThatThingHappened("Did you click the menu item?");
		}

	}

}