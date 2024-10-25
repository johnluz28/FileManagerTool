using FILE_MANAGER.Helper;
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

namespace FILE_MANAGER.Forms
{
    public partial class ExcelConverter : Form
    {
        public ExcelConverter()
        {
            InitializeComponent();
            drpCovertTo.SelectedIndex = 0;
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.Enabled = false;
            try
            {
                string excelSource = txtExcelSource.Text.Trim(),
                    destination = txtDestination.Text.Trim(),
                    newLang = txtNewLanguage.Text.Trim();
                  

                if (string.IsNullOrWhiteSpace(newLang)
                    || string.IsNullOrWhiteSpace(destination)
                    || string.IsNullOrWhiteSpace(excelSource)
                )
                {
                    MessageBox.Show("Please fill up all the required fields!");
                    return;
                }
                switch (drpCovertTo.SelectedIndex)
                {
                    case 0: //XML
                        ResourceHelper.ExcelToXML(newLang, excelSource, destination);
                        break;
                    case 1:
                        ResourceHelper.ExcelToResx(newLang, excelSource, destination);
                        //RESX
                        break;
                    case 2:
                        ResourceHelper.ExcelToJson(newLang, excelSource, destination);
                        //JSON
                        break;
                }
               
                MessageBox.Show("Success!");
                btn.Enabled = true;
            }
            catch (Exception ex)
            {
                btn.Enabled = true;
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "excel files (*.xls)|*.xlsx| excel files (*.xlsx)|*.xlsx";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtExcelSource.Text = fileDialog.FileName;
            }
            
        }
    }
}
