namespace SteamAccountSwitcher
{
	partial class AccountSwitcher
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
			this.button = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.action = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// button
			// 
			this.button.Location = new System.Drawing.Point(12, 53);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(208, 23);
			this.button.TabIndex = 0;
			this.button.Text = "Generate New Account";
			this.button.UseVisualStyleBackColor = true;
			this.button.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Status:";
			// 
			// action
			// 
			this.action.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.action.AutoSize = true;
			this.action.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.action.Location = new System.Drawing.Point(59, 37);
			this.action.Name = "action";
			this.action.Size = new System.Drawing.Size(24, 13);
			this.action.TabIndex = 3;
			this.action.Text = "Idle";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(13, 9);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(121, 13);
			this.linkLabel1.TabIndex = 4;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Created by: @BeepFelix";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// AccountSwitcher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(232, 85);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.action);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "AccountSwitcher";
			this.Text = "Account Switcher";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label action;
		private System.Windows.Forms.LinkLabel linkLabel1;
	}
}

