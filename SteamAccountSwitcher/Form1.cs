using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Web.Script.Serialization;
using System.IO;
using System.Xml.Serialization;

namespace SteamAccountSwitcher
{
	public partial class AccountSwitcher : Form
	{
		Options options = new Options();
		HttpClient client = new HttpClient();

		public AccountSwitcher()
		{
			InitializeComponent();

			// Super Duper Cool Gear Icon
			byte[] img = Convert.FromBase64String("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");
			Stream stream = new MemoryStream(img);
			this.settings.BackgroundImage = Image.FromStream(stream);
			this.settings.Text = "";

			// Config
			string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

			if (File.Exists(appDataPath + "/steamAccountSwitcher.xml"))
			{
				try
				{
					Options.Config config = new Options.Config();
					XmlSerializer serializer = new XmlSerializer(typeof(Options.Config));

					StreamReader reader = new StreamReader(appDataPath + "/steamAccountSwitcher.xml");
					config = (Options.Config)serializer.Deserialize(reader);
					reader.Close();
					
					options.steamWithNoVerifyFiles.Checked = config.noverifyfiles;
					options.overrideSteamPath.Checked = config.overrideSteamPath;
					options.openFileDialog1.FileName = config.steamPath;
					options.steamPath.Text = config.steamPath;
					options.terminateTF2.Checked = config.terminateTF2;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error while loading config file\n\n" + ex.Message);
				}
			}
		}
		
		private class accountGen
		{
			public int success = -1;
			public string username = null;
			public string password = null;
			public string email = null;
			public string error = null;
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			if (!this.action.Text.Equals("Idle"))
			{
				MessageBox.Show("Currently busy. Please wait until the status changes to \"Idle\"");
				return;
			}
			
			if (options.terminateTF2.Checked)
			{
				// Terminate TF2
				this.action.Text = "Terminating Team Fortress 2...";

				try
				{
					foreach (Process proc in Process.GetProcessesByName("hl2"))
					{
						proc.Kill();
					}
				}
				catch (Exception ex)
				{
					// Error while killing all "hl2" processes
					MessageBox.Show(ex.Message);
					this.action.Text = "Idle";
					return;
				}
			}

			// Terminate Steam
			this.action.Text = "Terminating Steam...";

			try
			{
				foreach (Process proc in Process.GetProcessesByName("Steam"))
				{
					proc.Kill();
				}
			}
			catch (Exception ex)
			{
				// Error while killing all "Steam" processes
				MessageBox.Show(ex.Message);
				this.action.Text = "Idle";
				return;
			}

			// Generate account
			this.action.Text = "Generating new account...";

			string responseString = null;

			try
			{
				responseString = await client.GetStringAsync("http://accgen.undo.it/steam/api");
			}
			catch(Exception ex)
			{
				// Error while requesting the page
				MessageBox.Show(ex.Message);
				this.action.Text = "Idle";
				return;
			}
			
			JavaScriptSerializer oSerializer = new JavaScriptSerializer();
			accountGen account = null;
			try
			{
				account = oSerializer.Deserialize<accountGen>(responseString);
			}
			catch (Exception ex)
			{
				// Error while parsing the response
				MessageBox.Show(ex.Message);
				this.action.Text = "Idle";
				return;
			}
			
			if (account == null || account.success != 1 || account.username == null || account.password == null)
			{
				// Result is not a success, does not contain "username" or does not contain "password"
				MessageBox.Show(account.error != null ? account.error : responseString);
				this.action.Text = "Idle";
				return;
			}

			string username = account.username;
			string password = account.password;
			string email = account.email;

			if (username == null || password == null)
			{
				// Failed to find "username" or "password" (Should never be triggered as the top already checks for this)
				MessageBox.Show(responseString);
				this.action.Text = "Idle";
				return;
			}

			if (email != null)
			{
				this.email.LinkVisited = false;
				this.email.Text = email;
			}
			else
			{
				this.email.LinkVisited = false;
				this.email.Text = "";
			}

			// Start Steam and login
			this.action.Text = "Starting Steam...";

			object r = null;
			if (options.overrideSteamPath.Checked == false || options.openFileDialog1.FileName.Length <= 0 || options.openFileDialog1.FileName == "openFileDialog1")
			{
				// Find Steam installation path. First GetValue() is for 64-Bit, second one is for 32-Bit
				r = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", null);
				if (r == null)
				{
					r = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", null);
					if (r == null)
					{
						// Steam is not installed
						MessageBox.Show("Could not find Steam installation path");
						this.action.Text = "Idle";
						return;
					}
				}
				r += "/steam.exe";
			}
			else
			{
				r = options.openFileDialog1.FileName;
			}

			// https://developer.valvesoftware.com/wiki/Command_Line_Options#Steam_.28Windows.29
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = r.ToString();
			startInfo.Arguments = "-login " + username + " " + password;
			if (options.steamWithNoVerifyFiles.Checked) startInfo.Arguments += " -noverifyfiles";
			Process.Start(startInfo);

			// Return to waiting
			this.action.Text = "Idle";
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.linkLabel1.LinkVisited = true;
			System.Diagnostics.Process.Start("https://t.me/BeepFelix");
		}

		private void settings_Click(object sender, EventArgs e)
		{
			options.ShowDialog();
		}

		private void email_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.email.LinkVisited = true;
			System.Diagnostics.Process.Start("https://asdf.pl/" + this.email.Text);
		}
	}
}
