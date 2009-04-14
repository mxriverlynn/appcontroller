using System;
using System.Windows.Forms;
using ApplicationControllerExample.App;

namespace ApplicationControllerExample.View
{
	public partial class Form1 : Form, ISomeView
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Presenter.DoSomething();
		}

		public SomePresenter Presenter { get; set; }

		private void button2_Click(object sender, EventArgs e)
		{
			Presenter.DoAnotherThing();
		}
	}
}