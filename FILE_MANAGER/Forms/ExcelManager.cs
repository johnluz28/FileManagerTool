using FILE_MANAGER.Helper;
using FILE_MANAGER.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FILE_MANAGER.Forms
{
    public partial class ExcelManager : Form
    {
        public ExcelManager()
        {
            InitializeComponent();
        }
        private List<LookUpSource> lookUpSourceEn { get; set; }

        private async void cmdGenerate_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.Enabled = false;
            try
            {
                string excelSource = txtExcelSource.Text.Trim(),
                    destination = txtDestination.Text.Trim();

                if (txtDestination.Text.Trim().Length == 0 || txtExcelSource.Text.Trim().Length == 0)
                {
                    //test
                    MessageBox.Show("Please enter all the required fields!");
                    return;
                }

                lookUpSourceEn = new List<LookUpSource>();
                foreach (var f in AppConfig.LocalizationFolders)
                {
                    var en_us_jsonPath = $@"{Application.StartupPath}\localization\{f.Trim()}\en-US.json";
                    var lookups = await FileHelper.ReadFileAsync<LookupsModel>(en_us_jsonPath);
                    lookUpSourceEn.Add(new LookUpSource() { Id = f, LookUps = lookups });

                }

                ExcelToJsonUL(excelSource, destination);
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

        public void ExcelToJsonUL(string excelSource, string destination)
        {
            FileInfo existingFile = new FileInfo(excelSource);
            var languages = AppConfig.LanguagesUL;
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                foreach (var ws in package.Workbook.Worksheets)
                {
                    var wsLookUpEn = lookUpSourceEn.FirstOrDefault(p => p.Id.Equals(ws.Name.ToStringSafe().Trim()));
                    int rowCount = ws.Dimension.End.Row;     //get row count
                    int colCount = ws.Dimension.End.Column;

                    for (int col = 1; col <= colCount; col++)
                    {
                        var lookups = new LookupsModel();
                        var lookUpItems = new List<LookupsItemModel>();

                        var lang = "en-US";
                        for (int row = 1; row <= rowCount; row++)
                        {
                            if (row == 1) continue; //row headers

                            var rowHeader = ws.Cells[1, col].Value.ToStringSafe();
                            if (!AppConfig.LanguagesUL.Any(p => p.Equals(rowHeader, StringComparison.InvariantCultureIgnoreCase))) continue;
                            lang = rowHeader;
                            var val = ws.Cells[row, col].Value.ToStringSafe().Trim();
                            var valEn = ws.Cells[row, 1].Value.ToStringSafe().Trim().Replace("amp;", "");
                            var id = wsLookUpEn.LookUps.Items.FirstOrDefault(c => c.Name == valEn).Id; // get id from en lookup source
                            lookUpItems.Add(new LookupsItemModel()
                            {
                                Id = id,
                                Name = val,
                            });
                        }
                        //sort lookups items by id
                        lookups.Items = lookUpItems.OrderBy(i => i.Id)?.ToList();
                       //check destination paths folder
                        var destinationFolder = $@"{destination}/{ws.Name.ToLower().Trim()}";
                        if (!Directory.Exists(destinationFolder))
                        {
                            Directory.CreateDirectory(destinationFolder);
                        }

                     
                        //create json file
                        var targetPath = $@"{destinationFolder}/{lang}.json";
                        var json = JsonConvert.SerializeObject(lookups, Formatting.Indented);
                        File.WriteAllText(targetPath, json);
                    }
                }

            }
        }
    }
}
