using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SteamAccountSwitcher
{
	public partial class Options : Form
	{
		public Options()
		{
			InitializeComponent();
		}

		private void closeSaveSettings_Click(object sender, EventArgs e)
		{
			Close();

			var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

			var config = new Config
			{
				NoVerifyFiles = steamWithNoVerifyFiles.Checked,
				OverrideSteamPath = overrideSteamPath.Checked,
				SteamPath = openFileDialog1.FileName == "openFileDialog1" ? "" : openFileDialog1.FileName,
				TerminateTf2 = terminateTF2.Checked
			};

			var serializer = new XmlSerializer(typeof(Config));
			TextWriter writer = new StreamWriter(appDataPath + "/steamAccountSwitcher.xml");

			serializer.Serialize(writer, config);
			writer.Close();
		}

		private void selectSteam_Click(object sender, EventArgs e)
		{
			var res = openFileDialog1.ShowDialog();
			if (res == DialogResult.OK)
				steamPath.Text = openFileDialog1.FileName == "openFileDialog1" ? "" : openFileDialog1.FileName;
		}

		public class Config
		{
			public bool NoVerifyFiles { get; set; }
			public bool OverrideSteamPath { get; set; }
			public string SteamPath { get; set; }
			public bool TerminateTf2 { get; set; }
		}

		public class AccountGen
		{
			public int Success { get; set; } = -1;
			public string Username { get; set; } = null;
			public string Password { get; set; } = null;
			public string Email { get; set; } = null;
			public string Error { get; set; } = null;
		}
	}
}