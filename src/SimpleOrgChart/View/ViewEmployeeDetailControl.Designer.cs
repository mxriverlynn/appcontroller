namespace SimpleOrgChart.View
{
	partial class ViewEmployeeDetailControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.EmployeeName = new System.Windows.Forms.Label();
			this.Email = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Email);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.EmployeeName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(393, 89);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Employee Info";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name: ";
			// 
			// EmployeeName
			// 
			this.EmployeeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.EmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EmployeeName.Location = new System.Drawing.Point(69, 20);
			this.EmployeeName.Name = "EmployeeName";
			this.EmployeeName.Size = new System.Drawing.Size(307, 22);
			this.EmployeeName.TabIndex = 1;
			this.EmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Email
			// 
			this.Email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Email.Location = new System.Drawing.Point(69, 51);
			this.Email.Name = "Email";
			this.Email.Size = new System.Drawing.Size(307, 22);
			this.Email.TabIndex = 3;
			this.Email.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Email: ";
			// 
			// ViewEmployeeDetailControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Name = "ViewEmployeeDetailControl";
			this.Size = new System.Drawing.Size(393, 89);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label Email;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label EmployeeName;
		private System.Windows.Forms.Label label1;
	}
}
