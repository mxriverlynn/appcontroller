namespace SimpleOrgChart.View
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.OrgChart = new System.Windows.Forms.TreeView();
			this.AddNewEmployee = new System.Windows.Forms.Button();
			this.ViewEmployeeDetail = new ViewEmployeeDetailControl();
			this.SuspendLayout();
			// 
			// OrgChart
			// 
			this.OrgChart.Location = new System.Drawing.Point(12, 12);
			this.OrgChart.Name = "OrgChart";
			this.OrgChart.Size = new System.Drawing.Size(482, 196);
			this.OrgChart.TabIndex = 0;
			this.OrgChart.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OrgChart_AfterSelect);
			// 
			// AddNewEmployee
			// 
			this.AddNewEmployee.Location = new System.Drawing.Point(12, 309);
			this.AddNewEmployee.Name = "AddNewEmployee";
			this.AddNewEmployee.Size = new System.Drawing.Size(140, 23);
			this.AddNewEmployee.TabIndex = 2;
			this.AddNewEmployee.Text = "Add New Employee";
			this.AddNewEmployee.UseVisualStyleBackColor = true;
			this.AddNewEmployee.Click += new System.EventHandler(this.AddNewEmployee_Click);
			// 
			// ViewEmployeeDetail
			// 
			this.ViewEmployeeDetail.Location = new System.Drawing.Point(12, 214);
			this.ViewEmployeeDetail.Name = "ViewEmployeeDetail";
			this.ViewEmployeeDetail.Size = new System.Drawing.Size(482, 89);
			this.ViewEmployeeDetail.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(506, 340);
			this.Controls.Add(this.AddNewEmployee);
			this.Controls.Add(this.ViewEmployeeDetail);
			this.Controls.Add(this.OrgChart);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Org Chart";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView OrgChart;
		private ViewEmployeeDetailControl ViewEmployeeDetail;
		private System.Windows.Forms.Button AddNewEmployee;
	}
}