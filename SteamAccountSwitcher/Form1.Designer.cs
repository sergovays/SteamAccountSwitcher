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
			this.settings = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.email = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// button
			// 
			this.button.Location = new System.Drawing.Point(12, 61);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(179, 23);
			this.button.TabIndex = 0;
			this.button.Text = "Generate New Account";
			this.button.UseVisualStyleBackColor = true;
			this.button.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 45);
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
			this.action.Location = new System.Drawing.Point(72, 45);
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
			// settings
			// 
			this.settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.settings.Location = new System.Drawing.Point(197, 61);
			this.settings.Name = "settings";
			this.settings.Size = new System.Drawing.Size(23, 23);
			this.settings.TabIndex = 5;
			this.settings.Text = "O";
			this.settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.settings.UseVisualStyleBackColor = true;
			this.settings.Click += new System.EventHandler(this.settings_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Last email:";
			// 
			// email
			// 
			this.email.AutoSize = true;
			this.email.Location = new System.Drawing.Point(72, 32);
			this.email.Name = "email";
			this.email.Size = new System.Drawing.Size(0, 13);
			this.email.TabIndex = 7;
			this.email.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.email_LinkClicked);
			// 
			// AccountSwitcher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(232, 96);
			this.Controls.Add(this.email);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.settings);
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
		private System.Windows.Forms.Button settings;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel email;
	}
}

