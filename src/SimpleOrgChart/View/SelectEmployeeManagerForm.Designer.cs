namespace SimpleOrgChart.View
{
	partial class SelectEmployeeManagerForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.Done = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.Employee = new System.Windows.Forms.Label();
			this.ManagerList = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Employee:";
			// 
			// Done
			// 
			this.Done.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Done.Location = new System.Drawing.Point(300, 65);
			this.Done.Name = "Done";
			this.Done.Size = new System.Drawing.Size(75, 23);
			this.Done.TabIndex = 2;
			this.Done.Text = "Done";
			this.Done.UseVisualStyleBackColor = true;
			this.Done.Click += new System.EventHandler(this.Done_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Select Manager:";
			// 
			// Employee
			// 
			this.Employee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Employee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Employee.Location = new System.Drawing.Point(114, 9);
			this.Employee.Name = "Employee";
			this.Employee.Size = new System.Drawing.Size(261, 22);
			this.Employee.TabIndex = 4;
			this.Employee.Text = "lastname, firstname (email@address)";
			this.Employee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ManagerList
			// 
			this.ManagerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.ManagerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ManagerList.FormattingEnabled = true;
			this.ManagerList.Location = new System.Drawing.Point(114, 38);
			this.ManagerList.Name = "ManagerList";
			this.ManagerList.Size = new System.Drawing.Size(261, 21);
			this.ManagerList.TabIndex = 5;
			this.ManagerList.SelectedIndexChanged += new System.EventHandler(this.ManagerList_SelectedIndexChanged);
			// 
			// SelectEmployeeManagerForm
			// 
			this.AcceptButton = this.Done;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(387, 98);
			this.ControlBox = false;
			this.Controls.Add(this.ManagerList);
			this.Controls.Add(this.Employee);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Done);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SelectEmployeeManagerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Org Chart :: Add New Employee :: Manager";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Done;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label Employee;
		private System.Windows.Forms.ComboBox ManagerList;
	}
}