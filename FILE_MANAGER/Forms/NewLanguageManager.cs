using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Forms;
using System.Xml.Linq;
using FILE_MANAGER.Helper;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace FILE_MANAGER
{
	public partial class NewLanguageManager : Form
	{
		public NewLanguageManager()
		{
			InitializeComponent();
		}

		private void chkDestinationSetting_CheckedChanged(object sender, EventArgs e)
		{
			if (chkDestinationSetting.Checked)
			{
				txtDestination.Clear();
				txtDestination.Enabled = false;
			}
			else
			{
				txtDestination.Enabled = true;
			}

		}

		private void cmdGenerate_Click(object sender, EventArgs e)
		{
			try
			{
				var key = txtTargetLanuage.Text.Trim();
				var source = $@"{txtSource.Text.Trim()}";
				var destination = chkDestinationSetting.Checked ? source : $@"{txtDestination.Text.Trim()}";
				var destinationKeys = txtNewLanguage.Text.Trim().Split(',');//CASE SENTETIVE
				if (ValidateFields())
				{
					MessageBox.Show("Please fill up all the required field!");
					return;
				}
                Generate(key, source, destination, destinationKeys);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Generate(string key,string source,string destination,string[] destinationKeys)
        {
            var paths = new List<string>();
            
            if (chkAffMobileSettings.Checked)
                paths = AppConfig.AffMobilePaths;
            
            if (chkAffWebPaths.Checked)
                paths = AppConfig.AffWebPaths;

            if (paths.Any())
            {
                foreach (var dkey in destinationKeys)
                {
                    foreach (var amp in paths)
                    {
                        var path = amp.Replace("\r\n", "").Replace("/","\\").Trim();
                        var ms = $@"{source}/{path}";
                        var dPath = $@"{destination}/{path}";
                        var md = chkDestinationSetting.Checked ? ms : dPath;
                        if (!chkDestinationSetting.Checked)
                        {
                            if (!Directory.Exists(dPath))
                            {
                                Directory.CreateDirectory(dPath);
                            }
                           
                        }
                        var msd = new DirectoryInfo(ms);

                        foreach (var f in msd.GetFiles().Where(p => p.Name.IndexOf(key) != -1 || p.Name.IndexOf(key.ToLower()) != -1))
                        {
                            //.Move for Rename
                            File.Copy($@"{ms}\{f.Name}",
                                $@"{md}\{f.Name.Replace(key, dkey).Replace(key.ToLower(), dkey)}", true);
                        }
                    }
                }
            }
			else
			{
				var d = new DirectoryInfo($@"{source}");
				foreach (var dkey in destinationKeys)
				{
					foreach (var f in d.GetFiles().Where(p => p.Name.IndexOf(key) != -1 || p.Name.IndexOf(key.ToLower()) != -1))
					{
						File.Copy($@"{source}\{f.Name}",
							$@"{destination}\{f.Name.Replace(key, dkey).Replace(key.ToLower(), dkey)}", true);
					}
				}

			}

			MessageBox.Show("Success!");
		}

		private bool ValidateFields()
        {
            return chkDestinationSetting.Checked
				? (string.IsNullOrWhiteSpace(txtNewLanguage.Text.Trim())
				   || string.IsNullOrWhiteSpace(txtSource.Text.Trim())
				   || string.IsNullOrWhiteSpace(txtTargetLanuage.Text.Trim()))

				: (string.IsNullOrWhiteSpace(txtNewLanguage.Text.Trim())
				   || string.IsNullOrWhiteSpace(txtSource.Text.Trim())
				   || string.IsNullOrWhiteSpace(txtDestination.Text.Trim())
				   || string.IsNullOrWhiteSpace(txtTargetLanuage.Text.Trim()));

		}
    }
}
