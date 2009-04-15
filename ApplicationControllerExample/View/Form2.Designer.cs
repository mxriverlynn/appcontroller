using ApplicationControllerExample.App;

namespace ApplicationControllerExample.View
{
	partial class Form2
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
			this.button1 = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.someMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clickThisYoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(21, 65);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(180, 128);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.someMenuToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(284, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// someMenuToolStripMenuItem
			// 
			this.someMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clickThisYoToolStripMenuItem});
			this.someMenuToolStripMenuItem.Name = "someMenuToolStripMenuItem";
			this.someMenuToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
			this.someMenuToolStripMenuItem.Text = "Some Menu";
			// 
			// clickThisYoToolStripMenuItem
			// 
			this.clickThisYoToolStripMenuItem.Name = "clickThisYoToolStripMenuItem";
			this.clickThisYoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.clickThisYoToolStripMenuItem.Text = "Click This, Yo!";
			this.clickThisYoToolStripMenuItem.Click += new System.EventHandler(this.clickThisYoToolStripMenuItem_Click);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 264);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form2";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem someMenuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clickThisYoToolStripMenuItem;
	}
}