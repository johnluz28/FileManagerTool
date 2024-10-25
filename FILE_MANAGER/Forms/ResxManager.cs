using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FILE_MANAGER.Helper;
using FILE_MANAGER.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using FILE_MANAGER.Enums;

namespace FILE_MANAGER
{
	public partial class ResxManager : Form
	{
		public ResxManager()
		{
			InitializeComponent();
        }
		private List<FileContent> fileContents { get; set; }
		private void ResxToJSON_Load(object sender, EventArgs e)
		{
			radResxToJson.Checked = true;
			fileContents = new List<FileContent>();
			var limit = 3;
			for (var i = 1; i <= limit; i++)
			{
				fileContents.Add(new FileContent(){Id = i});
			}
			
		}
		
		//private string fileContent { get; set; }
		//private string filePath { get; set; }

		//private string fileContent2 { get; set; }
		//private string filePath2 { get; set; }
		

		private string convertResxToXmlString(string xml,string xmlContainerTag)
		{
			var sb = new StringBuilder();
			sb.AppendLine($"<{xmlContainerTag}>");
			var obj = new
			{
				Items = XElement.Parse(xml)
					.Elements("data")
					.Select(el => new
					{
						id = el.Attribute("name").Value,
						value = el.Element("value").Value.Trim()
					})
					.ToList()
			};

			foreach (var i in obj.Items)
			{
				sb.AppendLine($"<{i.id}><![CDATA[{i.value}]]></{i.id}>");
			}
			sb.AppendLine($"</{xmlContainerTag}>");

			return sb.ToString();
		}

		private JObject convertResxToJson(string xml)
		{
			//var source = $@"{txtSource.Text.Trim()}.{language}.ascx.resx";
			//var source = txtSource.Text.Trim();
			//var d = new DirectoryInfo($@"{source}");

			//var xml = File.ReadAllText(source);
			var obj = new
			{
				Items = XElement.Parse(xml)
					.Elements("data")
					.Select(el => new
					{
						id = el.Attribute("name").Value,
						value = el.Element("value").Value.Trim()
					})
					.ToList()
			};
			var nobj = new JObject();
			foreach (var i in obj.Items)
			{
				var val = Encoding.UTF7.GetString(Encoding.Default.GetBytes(i.value));
				nobj.Add(new JProperty(i.id, val));
			}

			return nobj;
			//string json = JsonConvert.SerializeObject(nobj, Newtonsoft.Json.Formatting.Indented);

			//var reg = "\"([^\"]+)\":";

			//return Regex.Replace(json, reg, "$1:");
		}




		private void cmdBrowse_Click(object sender, EventArgs e)
		{
			OpenFile(1,txtSource);
		}
		private void cmdBrowse2_Click(object sender, EventArgs e)
		{
			OpenFile(2, txtSource2);
		}
		private void cmdBrowse3_Click(object sender, EventArgs e)
		{
			OpenFile(3, txtSource3, "xml files (*.xml)|*.xml");
		}

		private void OpenFile(int id,TextBox txtField,string filter = "txt files (*.resx)|*.resx")
		{
			using (var openFileDialog = new OpenFileDialog())
			{
				//openFileDialog.InitialDirectory = "c:\\";
				openFileDialog.Filter = filter;
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					//Get the path of specified file
					//filePath = openFileDialog.FileName;

					//Read the contents of the file into a stream
					var fileStream = openFileDialog.OpenFile();

					using (var reader = new StreamReader(fileStream, Encoding.UTF8))
					{
						//fileContent = reader.ReadToEnd();
						foreach (var f in fileContents.Where(p => p.Id == id))
						{
							f.Path = openFileDialog.FileName;
							f.Content = reader.ReadToEnd();
							txtField.Text = f.Path;
						}
					}
				}
			}
		}

		private void radResxToJson_CheckedChanged(object sender, EventArgs e)
		{
			txtXMLContainerTAg.Clear();
			//txtXMLContainerTAg.Enabled = false;
			//cmdBrowse2.Enabled = false;
			//txtSource2.Clear();
			//txtSource2.Enabled = false;
			foreach (Control c in panCompare.Controls)
			{
				if (c is TextBox)
				{
					c.Text = "";
				}
				
			}
			panCompare.Enabled = false;
			cmdSubmitMerge.Enabled = false;
		}
		private void radResxToXML_CheckedChanged(object sender, EventArgs e)
		{
			//txtXMLContainerTAg.Enabled = true;
			panCompare.Enabled = true;
			cmdSubmitMerge.Enabled = true;
		}

		

		private void cmdSubmit_Click(object sender, EventArgs e)
		{
			//var obj = new JObject();
			////foreach (var lang in AppConfig.Languages)
			////{
			////	obj.Add(lang.Replace("-","_"), convertResxToJson(lang));
			////}

			//obj.Add("test", convertResxToJson(""));
			var fc = fileContents.FirstOrDefault(p => p.Id == 1);

			if (string.IsNullOrWhiteSpace(fc?.Content) || string.IsNullOrWhiteSpace(txtXMLContainerTAg.Text.Trim())) return;
			rtbResult.Clear();
			if (radResxToXML.Checked)
			{

				rtbResult.AppendText(convertResxToXmlString(fc.Content, txtXMLContainerTAg.Text.Trim()));
			}
			if(radResxToJson.Checked)
			{
                var reg = "\"([^\"]+)\":";
                //use for "es-mx,es-pe,es-cl,pt-br" languages
                var encType = chkUTF7Encoding.Checked ? EncodingType.UTF7 : EncodingType.UTF8;
                string json = JsonConvert.SerializeObject(ResourceHelper.ConvertResxToJson(fc.Content, encType), Newtonsoft.Json.Formatting.Indented);
                rtbResult.AppendText(Regex.Replace(json, reg, "$1:"));
            }

		}




		private string compareAndconvertResxToXmlString(string xml,string xml2,string xml3, string xmlContainerTag)
		{
			var sb = new StringBuilder();
			if(chkIncludeXmlHeaderTag.Checked) sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
			sb.AppendLine($"<{xmlContainerTag}>");
			var xmldoc = new XmlDataDocument();
			xmldoc.LoadXml(xml3);
			var xmlnode = xmldoc.GetElementsByTagName(txtXMLContainerTAg.Text.Trim());
			if (xmlnode.Count == 0)
			{
				MessageBox.Show("Invalid xml tag name!");
				return null;
			}
			//var nodes = 
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
				SourceToMerge = chkHasSoureToMerge.Checked ?   XElement.Parse(xml2)
					.Elements("data")
					.Select(el => new
					{
						id = el.Attribute("name").Value,
						value = el.Element("value").Value.Trim()
					})
					.ToList() : null,
				Final = xmlnode[0].ChildNodes.OfType<XmlElement>().Select(el=> new
				{
					id = el.Name.ToString(),
					value = el.InnerXml.Trim()
				}).ToList()


			};
			
			var mergedSource = new  List<ResxItem>();
			var finalSource = new List<ResxItem>();
			//get all source items then merge 
			foreach (var a in obj.Source)
			{
				var val = a.value;
				if (chkHasSoureToMerge.Checked)
				{
					var b = obj.SourceToMerge.FirstOrDefault(p => p.id == a.id);
					if (b != null) val = b.value;
				}
				
				mergedSource.Add(new ResxItem()
				{
					Id = a.id,
					Value = val
				});
			}

			if (chkHasSoureToMerge.Checked)
			{
				foreach (var a in obj.SourceToMerge.Where(p => !obj.Source.Any(j => j.id == p.id)))
				{
					mergedSource.Add(new ResxItem()
					{
						Id = a.id,
						Value = a.value
					});
				}
			}
			
			//merge to final
			foreach (var a in obj.Final)
			{
				var val = a.value;
				foreach (var b in mergedSource.Where(p=> p.Id  == a.id))
				{
					val = $"<![CDATA[{b.Value}]]>";
				}
				finalSource.Add(new ResxItem()
				{
					Id = a.id,
					Value = val
				});
			}

			foreach (var i in finalSource.OrderBy(p=> p.Id))
			{
				sb.AppendLine($"<{i.Id}>{i.Value}</{i.Id}>");
			}
			sb.AppendLine($"</{xmlContainerTag}>");

			return sb.ToString();
		}

		private void cmdSubmitMerge_Click(object sender, EventArgs e)
		{
			var fc1 = fileContents.FirstOrDefault(p => p.Id == 1);
			var fc2 = fileContents.FirstOrDefault(p => p.Id == 2);
			var fc3 = fileContents.FirstOrDefault(p => p.Id == 3);
			var isNotValid = string.IsNullOrWhiteSpace(fc1?.Content)
			                 || string.IsNullOrWhiteSpace(txtXMLContainerTAg.Text.Trim())
			                 || (chkHasSoureToMerge.Checked && string.IsNullOrWhiteSpace(fc2?.Content))
			                 || string.IsNullOrWhiteSpace(fc3?.Content);
			//if (chkHasSoureToMerge.Checked)
			//{
			//	isNotValid = 
			//}
			//else
			//{

			//	isNotValid = string.IsNullOrWhiteSpace(fc1?.Content)
			//	             || string.IsNullOrWhiteSpace(txtXMLContainerTAg.Text.Trim())
			//	             || string.IsNullOrWhiteSpace(fc3?.Content);
			//}

			if (isNotValid)
			{
				MessageBox.Show("Please fill in all required Fields!");
				return;
			}
			

			rtbResult.Clear();
			var result = compareAndconvertResxToXmlString(fc1?.Content, fc2?.Content, fc3?.Content,
				txtXMLContainerTAg.Text.Trim());
			if(string.IsNullOrWhiteSpace(result))return;
			rtbResult.AppendText(result);
		}

		private void chkHasSoureToMerge_CheckedChanged(object sender, EventArgs e)
		{
			if (chkHasSoureToMerge.Checked)
			{
				txtSource2.Enabled = true;
				cmdBrowse2.Enabled = true;
			}
			else
			{
				txtSource2.Enabled = false;
				cmdBrowse2.Enabled = false;
				txtSource2.Clear();
				foreach (var f in fileContents.Where(p=> p.Id == 2))
				{
					f.Content = string.Empty;
					f.Path = string.Empty;
				}
			}
		}
	}
}
