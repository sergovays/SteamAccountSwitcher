using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace SteamAccountSwitcher
{
	public partial class AccountSwitcher : Form
	{
		private static WebClient _client = new WebClient();
		private static Options _options = new Options();

		public AccountSwitcher()
		{
			InitializeComponent();
		}

		private void AccountSwitcher_Load(object sender, EventArgs e)
		{
			// Config
			var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

			if (!File.Exists(appDataPath + "/steamAccountSwitcher.xml")) return;

			try
			{
				var serializer = new XmlSerializer(typeof(Options.Config));
				var reader = new StreamReader(appDataPath + "/steamAccountSwitcher.xml");
				var config = (Options.Config) serializer.Deserialize(reader);
				reader.Close();

				_options.steamWithNoVerifyFiles.Checked = config.NoVerifyFiles;
				_options.overrideSteamPath.Checked = config.OverrideSteamPath;
				_options.openFileDialog1.FileName = config.SteamPath;
				_options.steamPath.Text = config.SteamPath;
				_options.terminateTF2.Checked = config.TerminateTf2;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error while loading config file\n\n" + ex.Message);
			}
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			if (!action.Text.Equals("Idle"))
			{
				MessageBox.Show("Currently busy. Please wait until the status changes to \"Idle\"");
				return;
			}

			if (_options.terminateTF2.Checked)
			{
				// Terminate TF2
				action.Text = "Terminating Team Fortress 2...";

				try
				{
					foreach (var proc in Process.GetProcessesByName("hl2")) proc.Kill();
				}
				catch (Exception ex)
				{
					// Error while killing all "hl2" processes
					MessageBox.Show(ex.Message);
					action.Text = "Idle";
					return;
				}
			}

			// Terminate Steam
			action.Text = "Terminating Steam...";

			try
			{
				foreach (var proc in Process.GetProcessesByName("Steam")) proc.Kill();
			}
			catch (Exception ex)
			{
				// Error while killing all "Steam" processes
				MessageBox.Show(ex.Message);
				action.Text = "Idle";
				return;
			}

			// Generate account
			action.Text = "Generating new account...";

			string responseString = null;

			try
			{
				responseString = await _client.DownloadStringTaskAsync("https://accgen.inkcat.net:6969/account");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				action.Text = "Idle";
				return;
			}

			var oSerializer = new JavaScriptSerializer();
			Options.AccountGen account;

			try
			{
				account = oSerializer.Deserialize<Options.AccountGen>(responseString);
			}
			catch (Exception ex)
			{
				// Error while parsing the response
				MessageBox.Show(ex.Message);
				action.Text = "Idle";
				return;
			}

			if (account.login == null || account.password == null || account.email == null)
			{
				MessageBox.Show("Unknown API Response\n\n" + account.ToString());
				action.Text = "Idle";
				return;
			}
			
			var username = account.login;
			var password = account.password;
			var email = account.email;

			if (username == null || password == null)
			{
				// Failed to find "username" or "password" (Should never be triggered as the top already checks for this)
				MessageBox.Show(responseString);
				action.Text = "Idle";
				return;
			}

			if (email != null)
			{
				emailLabel.LinkVisited = false;
				emailLabel.Text = email;
			}
			else
			{
				emailLabel.LinkVisited = false;
				emailLabel.Text = "";
			}

			// Start Steam and login
			action.Text = "Starting Steam...";

			object r;
			if (_options.overrideSteamPath.Checked == false || _options.openFileDialog1.FileName.Length <= 0 ||
			    _options.openFileDialog1.FileName == "openFileDialog1")
			{
				// Find Steam installation path. First GetValue() is for 64-Bit, second one is for 32-Bit
				r = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Valve\\Steam", "InstallPath", null);
				if (r == null)
				{
					r = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Valve\\Steam", "InstallPath", null);
					if (r == null)
					{
						// Steam is not installed
						MessageBox.Show("Could not find Steam installation path");
						action.Text = "Idle";
						return;
					}
				}

				r += "/steam.exe";
			}
			else
			{
				r = _options.openFileDialog1.FileName;
			}

			// https://developer.valvesoftware.com/wiki/Command_Line_Options#Steam_.28Windows.29
			var startInfo = new ProcessStartInfo
			{
				FileName = r.ToString(),
				Arguments = "-login " + username + " " + password
			};
			if (_options.steamWithNoVerifyFiles.Checked) startInfo.Arguments += " -noverifyfiles";
			

			try
			{
				Process.Start(startInfo);
			}
			catch (Exception ex)
			{
				// Error while starting Steam
				MessageBox.Show(ex.Message);
				action.Text = "Idle";
				return;
			}

			// Return to waiting
			action.Text = "Idle";
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			linkLabel1.LinkVisited = true;
			Process.Start("https://t.me/BeepFelix");
		}

		private void settings_Click(object sender, EventArgs e)
		{
			_options.ShowDialog();
		}

		private void email_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			emailLabel.LinkVisited = true;
			Process.Start(emailLabel.Text);
		}
	}
}
