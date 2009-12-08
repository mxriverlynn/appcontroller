using System;
using System.Windows.Forms;
using SimpleOrgChart.App.NewEmployeeProcess.SupplyEmployeeInfo;

namespace SimpleOrgChart.View
{

	public partial class NewEmployeeInfoForm : Form, INewEmployeeInfoView
	{

		public NewEmployeeInfoPresenter Presenter { get; set; }

		public NewEmployeeInfoForm()
		{
			InitializeComponent();
		}

		private void FirstName_TextChanged(object sender, EventArgs e)
		{
			Presenter.FirstNameSupplied(FirstName.Text);
		}

		private void LastName_TextChanged(object sender, EventArgs e)
		{
			Presenter.LastNameSupplied(LastName.Text);
		}

		private void Email_TextChanged(object sender, EventArgs e)
		{
			Presenter.EmailSupplied(Email.Text);
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			Presenter.Cancel();
			Close();
		}

		private void Next_Click(object sender, EventArgs e)
		{
			Presenter.Next();
			Close();
		}

		public void Run()
		{
			ShowDialog();
		}

	}

}
