using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FILE_MANAGER.Helper;

namespace FILE_MANAGER.Forms
{
    public partial class NewLanguageToExcel : Form
    {
        public NewLanguageToExcel()
        {
            InitializeComponent();
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                string key = txtLanguage.Text.Trim(),
                     source = $@"{txtSource.Text.Trim()}",
                     destination = $@"{txtDestination.Text.Trim()}",
                     excelFileName = txtExcelFileName.Text.Trim();

                var destinationKeys = txtNewLanguage.Text.Trim().Split(',');//CASE SENTETIVE
                if (string.IsNullOrWhiteSpace(source) 
                    || string.IsNullOrWhiteSpace(destination)
                    || string.IsNullOrWhiteSpace(excelFileName))
                {
                    MessageBox.Show("Please fill up all the required field!");
                    return;
                }

                ResourceHelper.ResxToExcel(key, source, destination, destinationKeys,excelFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
