using FILE_MANAGER.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using FILE_MANAGER.Helper;

namespace FILE_MANAGER
{
	public partial class XmlToExcel : Form
	{
		public XmlToExcel()
		{
			InitializeComponent();
			fileContents = new List<FileContent>();
			var limit = 2;
			for (var i = 1; i <= limit; i++)
			{
				fileContents.Add(new FileContent() { Id = i });
			}
		}

		private List<FileContent> fileContents { get; set; }


		//private void Merge(string source, string source2, string resultPath)
		//{
		//	var d = new DirectoryInfo($@"{source}");

		//	foreach (var f in d.GetFiles())
		//	{
		//		if (f.Extension != ".resx") continue;
		//		var s2 = $@"{source2}\{f.Name}";
		//		if(!File.Exists(s2))continue;
		//		var xml = File.ReadAllText($@"{source}\{f.Name}");
		//		var xml2 = File.ReadAllText($@"{source2}\{f.Name}");
		//		var mergedResx = MergeResx(xml, xml2);
		//		using (var resx = new ResXResourceWriter($@"{resultPath}\{f.Name}"))
		//		{
		//			foreach (var a in mergedResx)
		//			{
		//				resx.AddResource(a.Id, a.Value);
		//			}
		//		}
				
		//	}

		//	MessageBox.Show("Success!");

		//}

		private List<ResxItem> MergeResx(string xml,string xml2)
		{
			//dgvResult.Rows.Clear();
			var obj = new
			{
				Source = XElement.Parse(xml)
					.Elements("data")
					.Select(el => new
					{
						id = el.Attribute("name").Value,
						value = el.Element("value").Value.Trim()
					})
					.ToList(),
				FinalSource =  XElement.Parse(xml2)
					.Elements("data")
					.Select(el => new
					{
						id = el.Attribute("name").Value,
						value = el.Element("value").Value.Trim()
					})
					.ToList()
			};

			var finalSource = new List<ResxItem>();
	
			foreach (var a in obj.FinalSource)
			{
				var val = a.value;
				var b = obj.Source.FirstOrDefault(p => p.id == a.id);
				if (b != null) val = b.value;
				finalSource.Add(new ResxItem()
				{
					Id = a.id,
					Value =  val
				});
			}

			return finalSource;

			//foreach (var p in finalSource)
			//{
			//	string[] row = { p.Id, p.Value};
			//	var listViewItem = new ListViewItem(row);
			//	dgvResult.Rows.Add(row);
			//}

		}

		private void cmdCopy_Click(object sender, EventArgs e)
		{
		
		}

        private void PreviewResult(XmlDocument xml)
        {
            //var resxItems = ResourceHelper.GetResxItems()

            
            //foreach (var p in resxItems)
            //{
            //    string[] row = { p.Id, p.Value };
            //    dgvResult.Rows.Add(row);
            //}

        }

      

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestination.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtExcelFileName.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtSource.Text.Trim()) || string.IsNullOrWhiteSpace(txtLanguage.Text.Trim()))
            {
                MessageBox.Show("Please fill in all required Fields!");
                return;
            }
            var destinationKeys = txtNewLanguage.Text.Trim().Split(',');
            ResourceHelper.XMLToExcel(txtLanguage.Text,txtSource.Text.Trim(),txtDestination.Text.Trim(),destinationKeys,txtExcelFileName.Text.Trim());
            MessageBox.Show("Success!");
        }
    }
}
