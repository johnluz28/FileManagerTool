using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FILE_MANAGER.Helper;

namespace FILE_MANAGER
{
	
	public partial class NewLogo : Form
	{
		public NewLogo()
		{
			InitializeComponent();
			radWeb.Checked = true;
		}

		private void cmdSubmit_Click(object sender, EventArgs e)
		{
			var source = $@"{txtSource.Text.Trim()}";
			var d = new DirectoryInfo($@"{source}");
			foreach (var f in d.GetFiles())
			{
				//if (f.Name.Contains("mobile_mobile_")) continue;
				//var newFname = radWeb.Checked ? $"{f.Name.Replace(".grey", "")}" : $"mobile_{f.Name.Replace(".grey", "")}";
                var newFname = string.Empty;
                if (radMobile.Checked)
                {
                    foreach (var lcc in AppConfig.LanguageCountryCodes)
                    {
                        var lcCode = $"_{lcc}.png";
                        if (f.Name.Contains(lcCode))
                        {
                            newFname = $"mobile_logo_affiliate{lcCode}";
                        }
                    }
                }
                else
                {
                    newFname = $"{f.Name.Replace(".grey", "")}";
                }

				File.Move($@"{source}\{f.Name}",
					$@"{source}\{newFname}");

			}
		}

		private void radWeb_CheckedChanged(object sender, EventArgs e)
		{
			
		}
	}
}
