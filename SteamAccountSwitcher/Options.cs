using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace SteamAccountSwitcher
{
	public partial class Options : Form
	{
		public Options()
		{
			InitializeComponent();
		}

		public class Config
		{
			public bool noverifyfiles = false;
			public bool overrideSteamPath = false;
			public string steamPath = null;
			public bool terminateTF2 = false;
		}
		
		private void closeSaveSettings_Click(object sender, EventArgs e)
		{
			this.Close();
			
			string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

			Config config = new Config();
			config.noverifyfiles = this.steamWithNoVerifyFiles.Checked;
			config.overrideSteamPath = this.overrideSteamPath.Checked;
			config.steamPath = this.openFileDialog1.FileName == "openFileDialog1" ? "" : this.openFileDialog1.FileName;
			config.terminateTF2 = this.terminateTF2.Checked;

			XmlSerializer serializer = new XmlSerializer(typeof(Config));
			TextWriter writer = new StreamWriter(appDataPath + "/steamAccountSwitcher.xml");

			serializer.Serialize(writer, config);
			writer.Close();
		}

		private void selectSteam_Click(object sender, EventArgs e)
		{
			DialogResult res = this.openFileDialog1.ShowDialog();
			if (res == DialogResult.OK)
			{
				this.steamPath.Text = this.openFileDialog1.FileName == "openFileDialog1" ? "" : this.openFileDialog1.FileName;
			}
		}
	}
}
