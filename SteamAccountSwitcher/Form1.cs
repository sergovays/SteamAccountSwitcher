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
using System.Json;

namespace SteamAccountSwitcher
{
	public partial class AccountSwitcher : Form
	{
		public AccountSwitcher()
		{
			InitializeComponent();
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			if (!this.action.Text.Equals("Idle"))
			{
				MessageBox.Show("Currently busy. Please wait until the status changes to \"Idle\"");
				return;
			}

			// Terminate steam
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

			HttpClient client = new HttpClient();
			try
			{
				responseString = await client.GetStringAsync("http://accgen.undo.it/steam/apit");
			}
			catch(Exception ex)
			{
				// Error while requesting the page
				MessageBox.Show(ex.Message);
				this.action.Text = "Idle";
				return;
			}

			JsonValue json = null;
			try
			{
				json = JsonValue.Parse(responseString);
			}
			catch (Exception ex)
			{
				// Error while parsing the response
				MessageBox.Show(ex.Message);
				this.action.Text = "Idle";
				return;
			}

			if (!json.ContainsKey("success") || json["success"] != 1 || !json.ContainsKey("username") || !json.ContainsKey("password"))
			{
				// Result is not a success, does not contain "username" or does not contain "password"
				MessageBox.Show(responseString);
				this.action.Text = "Idle";
				return;
			}

			string username = json["username"];
			string password = json["password"];

			if (username == null || password == null)
			{
				// Failed to find "username" or "password" (Should never be triggered as the top already checks for this)
				MessageBox.Show(responseString);
				this.action.Text = "Idle";
				return;
			}

			// Start Steam and login
			this.action.Text = "Starting Steam...";
			
			// Find Steam installation path. First GetValue() is for 64-Bit, second one is for 32-Bit
			var r = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", null);
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

			// https://developer.valvesoftware.com/wiki/Command_Line_Options#Steam_.28Windows.29
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = r.ToString() + "/steam.exe";
			startInfo.Arguments = "-login " + username + " " + password;
			Process.Start(startInfo);

			// Return to waiting
			this.action.Text = "Idle";
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.linkLabel1.LinkVisited = true;
			System.Diagnostics.Process.Start("https://t.me/BeepFelix");
		}
	}
}
