namespace SteamAccountSwitcher
{
	partial class Options
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
			this.steamWithNoVerifyFiles = new System.Windows.Forms.CheckBox();
			this.overrideSteamPath = new System.Windows.Forms.CheckBox();
			this.selectSteam = new System.Windows.Forms.Button();
			this.steamPath = new System.Windows.Forms.TextBox();
			this.terminateTF2 = new System.Windows.Forms.CheckBox();
			this.closeSaveSettings = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// steamWithNoVerifyFiles
			// 
			this.steamWithNoVerifyFiles.AutoSize = true;
			this.steamWithNoVerifyFiles.Checked = true;
			this.steamWithNoVerifyFiles.CheckState = System.Windows.Forms.CheckState.Checked;
			this.steamWithNoVerifyFiles.Location = new System.Drawing.Point(12, 12);
			this.steamWithNoVerifyFiles.Name = "steamWithNoVerifyFiles";
			this.steamWithNoVerifyFiles.Size = new System.Drawing.Size(226, 17);
			this.steamWithNoVerifyFiles.TabIndex = 0;
			this.steamWithNoVerifyFiles.Text = "Launch Steam with \"-noverifyfiles\" (Faster)";
			this.steamWithNoVerifyFiles.UseVisualStyleBackColor = true;
			// 
			// overrideSteamPath
			// 
			this.overrideSteamPath.AutoSize = true;
			this.overrideSteamPath.Location = new System.Drawing.Point(12, 36);
			this.overrideSteamPath.Name = "overrideSteamPath";
			this.overrideSteamPath.Size = new System.Drawing.Size(175, 17);
			this.overrideSteamPath.TabIndex = 1;
			this.overrideSteamPath.Text = "Override Steam installation path";
			this.overrideSteamPath.UseVisualStyleBackColor = true;
			// 
			// selectSteam
			// 
			this.selectSteam.Location = new System.Drawing.Point(193, 32);
			this.selectSteam.Name = "selectSteam";
			this.selectSteam.Size = new System.Drawing.Size(45, 23);
			this.selectSteam.TabIndex = 2;
			this.selectSteam.Text = "Select";
			this.selectSteam.UseVisualStyleBackColor = true;
			this.selectSteam.Click += new System.EventHandler(this.selectSteam_Click);
			// 
			// steamPath
			// 
			this.steamPath.Location = new System.Drawing.Point(244, 34);
			this.steamPath.Name = "steamPath";
			this.steamPath.ReadOnly = true;
			this.steamPath.Size = new System.Drawing.Size(142, 20);
			this.steamPath.TabIndex = 3;
			// 
			// terminateTF2
			// 
			this.terminateTF2.AutoSize = true;
			this.terminateTF2.Location = new System.Drawing.Point(12, 59);
			this.terminateTF2.Name = "terminateTF2";
			this.terminateTF2.Size = new System.Drawing.Size(120, 17);
			this.terminateTF2.TabIndex = 4;
			this.terminateTF2.Text = "Terminate \"hl2.exe\"";
			this.terminateTF2.UseVisualStyleBackColor = true;
			// 
			// closeSaveSettings
			// 
			this.closeSaveSettings.Location = new System.Drawing.Point(12, 82);
			this.closeSaveSettings.Name = "closeSaveSettings";
			this.closeSaveSettings.Size = new System.Drawing.Size(85, 23);
			this.closeSaveSettings.TabIndex = 5;
			this.closeSaveSettings.Text = "Save && Close";
			this.closeSaveSettings.UseVisualStyleBackColor = true;
			this.closeSaveSettings.Click += new System.EventHandler(this.closeSaveSettings_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Steam Executable|Steam.exe";
			// 
			// Options
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(398, 117);
			this.ControlBox = false;
			this.Controls.Add(this.closeSaveSettings);
			this.Controls.Add(this.terminateTF2);
			this.Controls.Add(this.steamPath);
			this.Controls.Add(this.selectSteam);
			this.Controls.Add(this.overrideSteamPath);
			this.Controls.Add(this.steamWithNoVerifyFiles);
			this.MaximizeBox = false;
			this.Name = "Options";
			this.Text = "Options";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button selectSteam;
		private System.Windows.Forms.Button closeSaveSettings;
		public System.Windows.Forms.CheckBox steamWithNoVerifyFiles;
		public System.Windows.Forms.CheckBox overrideSteamPath;
		public System.Windows.Forms.CheckBox terminateTF2;
		public System.Windows.Forms.OpenFileDialog openFileDialog1;
		public System.Windows.Forms.TextBox steamPath;
	}
}