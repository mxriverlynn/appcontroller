namespace SimpleOrgChart.View
{
	partial class NewEmployeeInfoForm
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
			this.FirstName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.LastName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Email = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Next = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// FirstName
			// 
			this.FirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.FirstName.Location = new System.Drawing.Point(108, 12);
			this.FirstName.Name = "FirstName";
			this.FirstName.Size = new System.Drawing.Size(390, 20);
			this.FirstName.TabIndex = 3;
			this.FirstName.TextChanged += new System.EventHandler(this.FirstName_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "First Name:";
			// 
			// LastName
			// 
			this.LastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.LastName.Location = new System.Drawing.Point(108, 38);
			this.LastName.Name = "LastName";
			this.LastName.Size = new System.Drawing.Size(390, 20);
			this.LastName.TabIndex = 5;
			this.LastName.TextChanged += new System.EventHandler(this.LastName_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Last Name:";
			// 
			// Email
			// 
			this.Email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Email.Location = new System.Drawing.Point(108, 64);
			this.Email.Name = "Email";
			this.Email.Size = new System.Drawing.Size(390, 20);
			this.Email.TabIndex = 7;
			this.Email.TextChanged += new System.EventHandler(this.Email_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Email Address:";
			// 
			// Next
			// 
			this.Next.Location = new System.Drawing.Point(423, 90);
			this.Next.Name = "Next";
			this.Next.Size = new System.Drawing.Size(75, 23);
			this.Next.TabIndex = 8;
			this.Next.Text = "Next";
			this.Next.UseVisualStyleBackColor = true;
			this.Next.Click += new System.EventHandler(this.Next_Click);
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(15, 90);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 9;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// NewEmployeeInfoForm
			// 
			this.AcceptButton = this.Next;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(510, 123);
			this.ControlBox = false;
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.Next);
			this.Controls.Add(this.Email);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.LastName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.FirstName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NewEmployeeInfoForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Org Chart :: Add New Employee :: Info";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox FirstName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox LastName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Email;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button Next;
		private System.Windows.Forms.Button Cancel;

	}
}