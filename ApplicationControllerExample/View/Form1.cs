using System;
using System.Windows.Forms;
using ApplicationControllerExample.App;

namespace ApplicationControllerExample.View
{
	
	public partial class Form1 : Form, IMainView
	{

		public MainPresenter Presenter { get; set; }

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Presenter.DoSomething();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Presenter.SomethingElseIsHappening();
		}

		public void Run()
		{
			ShowDialog();
		}

	}

}