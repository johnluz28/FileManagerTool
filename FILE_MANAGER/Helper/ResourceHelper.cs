using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FILE_MANAGER.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Xml;
using FILE_MANAGER.Enums;
using Newtonsoft.Json.Linq;
using System.Resources;
using System.Text.RegularExpressions;

namespace FILE_MANAGER.Helper
{
    public static class ResourceHelper
    {
        public static void ResxToExcel(string key, string source, string destination, string[] destinationKeys, string excelFileName)
        {
            GenerateExcel(key,source,destination,destinationKeys,excelFileName);
        }

        public static void XMLToExcel(string key, string source, string destination, string[] destinationKeys,
            string excelFileName)
        {
            GenerateExcel(key, source, destination, destinationKeys, excelFileName,true);
        }
        public static JObject ConvertResxToJson(string xml, EncodingType encodingType)
        {
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
                var val = encodingType == EncodingType.UTF7 ? Encoding.UTF7.GetString(Encoding.Default.GetBytes(i.value)) : i.value;
                nobj.Add(new JProperty(i.id, val));
            }

            return nobj;

        }

        private static List<ResxItem> GetResxItems(string sourceFile,bool isXML)
        {
            if (!isXML)
            {
                var xml = File.ReadAllText(sourceFile);
                return XElement.Parse(xml)
                    .Elements("data")
                    .Select(el => new ResxItem()
                    {
                        Id = el.Attribute("name").Value,
                        Value = el.Element("value").Value.Trim()
                    }).ToList();
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(sourceFile);
            var finalSource = new List<ResxItem>();
            finalSource.Add(new ResxItem()
            {
                XMLTag = $"<{doc.DocumentElement.Name}>"
            });
            var invalidNodeValues = new List<string>() { "#comment" };
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var subItems = new List<ResxSubItem>();
                if(invalidNodeValues.Any(a=> a == node.Name)) continue;
                
                if (node.FirstChild != null)
                {
                    if (node.ChildNodes.Count > 1)
                    {
                        subItems.Add(new ResxSubItem()
                        {
                            XMLTag = $"<{node.Name}>"
                        });
                    }
                    

                    foreach (XmlNode si in node.ChildNodes)
                    {
                        if (invalidNodeValues.Any(a => a == si.Name)) continue;

                        if (si.FirstChild != null)
                        {
                            if (si.ChildNodes.Count > 1)
                            {
                                subItems.Add(new ResxSubItem()
                                {
                                    XMLTag = $"<{si.Name}/>"
                                });
                            }
                            
                            foreach (XmlNode sic in si.ChildNodes)
                            {
                                if (invalidNodeValues.Any(a => a == sic.Name)) continue;
                                subItems.Add(new ResxSubItem()
                                {
                                    Id = sic.Name.Equals("#cdata-section", StringComparison.InvariantCultureIgnoreCase) ||
                                         sic.Name.Equals("#text", StringComparison.InvariantCultureIgnoreCase) ? sic.ParentNode?.Name : sic.Name,
                                    Value = sic.InnerText
                                   // XMLTag = si.Name
                                });
                            }

                            if (si.ChildNodes.Count > 1)
                            {
                                subItems.Add(new ResxSubItem()
                                {
                                    XMLTag = $"</{si.Name}>"
                                });
                            }
                            
                            continue;
                        }
                        subItems.Add(new ResxSubItem()
                        {
                            Id = si.Name.Equals("#cdata-section",StringComparison.InvariantCultureIgnoreCase)  ||
                                 si.Name.Equals("#text", StringComparison.InvariantCultureIgnoreCase) ? si.ParentNode?.Name : si.Name,
                            Value = si.InnerText
                            // XMLTag = node.Name
                        });
                        
                       
                    }
                }
                
               
                //add Closing Tag
                if (node.ChildNodes.Count > 1)
                {
                   
                    subItems.Add(new ResxSubItem()
                    {
                        XMLTag = $"</{node.Name}>"
                    });
                }

                finalSource.Add(new ResxItem()
                {
                    Id = node.Name,
                    Value = node.InnerText,
                    SubItems = subItems
                });
               
            }
            finalSource.Add(new ResxItem()
            {
                XMLTag = $"</{doc.DocumentElement.Name}>"
            });
            return finalSource;
        }

        public static void ExcelToResx(string newLanguage,string excelSource, string destination)
        {
            //var sd = new DirectoryInfo($@"{source}");

            FileInfo existingFile = new FileInfo(excelSource);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
            
                foreach (var ws in package.Workbook.Worksheets)
                {
                    int rowCount = ws.Dimension.End.Row;     //get row count
                    var wsName = ws.Name.Replace("en-us",newLanguage).Replace(".resx","").Replace(".re","");
                    var resxFname = $@"{destination}/{wsName}.resx";
                    using (ResXResourceWriter resx = new ResXResourceWriter(resxFname))
                    {
                      
                        for (int row = 2; row <= rowCount; row++)
                        {
                            var id = ws.Cells[row, 1].Value?.ToString().Trim();
                            if(string.IsNullOrWhiteSpace(id))continue;
                            var newVal = string.IsNullOrWhiteSpace(ws.Cells[row, 3].Value?.ToString().Trim()) ?
                                ws.Cells[row, 2].Value?.ToString().Trim() : ws.Cells[row, 3].Value?.ToString().Trim();
                            resx.AddResource(id,newVal);
                        }
                    }
                   
                }
               
            }

        }

        public static void ExcelToJson(string newLanguage,string excelSource,string destination)
        {
            FileInfo existingFile = new FileInfo(excelSource);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook

                foreach (var ws in package.Workbook.Worksheets)
                {
                    int rowCount = ws.Dimension.End.Row;     //get row count
                    var resxFname = $@"{destination}/{ws.Name}.json";
                    using (TextWriter tw = new StreamWriter(resxFname))
                    {
                        tw.Write("");  //empty all
                        var sb = new StringBuilder();
                        sb.AppendLine("{");
                        for (int row = 2; row <= rowCount; row++)
                        {
                            var id = ws.Cells[row, 1].Value?.ToString().Trim();
                            if (string.IsNullOrWhiteSpace(id)) continue;
                            var newVal = string.IsNullOrWhiteSpace(ws.Cells[row, 3].Value?.ToString().Trim()) ?
                                ws.Cells[row, 2].Value?.ToString().Trim() : ws.Cells[row, 3].Value?.ToString().Trim();
                            //resx.AddResource(id, newVal);
                            newVal = Regex.Replace(newVal, @"\r\n?|\n", "");
                            if (row != rowCount)
                            {
                                sb.AppendLine(string.Format("\"{0}\":\"{1}\",", id, newVal));
                            }
                            else
                            {
                                sb.AppendLine(string.Format("\"{0}\":\"{1}\"", id, newVal));
                            }
                           
                        }
                        sb.AppendLine("}");
                        tw.Write(sb);
                    }

                }

            }
        }
        public static void ExcelToXML(string newLanguage, string excelSource, string desination)
        {
            //var sd = new DirectoryInfo($@"{source}");

            FileInfo existingFile = new FileInfo(excelSource);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook

                foreach (var ws in package.Workbook.Worksheets)
                {
                    int rowCount = ws.Dimension.End.Row;     //get row count
                    var wsName = ws.Name.Replace("en-us", newLanguage).Replace(".xml", "");
                   
                    var dFname = $@"{desination}/{wsName}.xml";
                    File.WriteAllText(dFname, string.Empty);
                    using (TextWriter tw = new StreamWriter(dFname, true))
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");

                        for (var row = 2; row <= rowCount; row++)
                        {
                            var xmlTagName = ws.Cells[row, 1].Value?.ToString().Trim();
                            if (string.IsNullOrWhiteSpace(xmlTagName)) continue;
                            var oldTranslation = ws.Cells[row, 2].Value?.ToString().Trim();
                            var newTranslation = ws.Cells[row, 3].Value?.ToString().Trim();
                            var newVal = string.IsNullOrWhiteSpace(newTranslation) ? oldTranslation : newTranslation;
                            //handle nested xml node
                            if (string.IsNullOrWhiteSpace(newVal) && (xmlTagName.Contains("<") && xmlTagName.Contains(">")))
                            {
                                sb.AppendLine(xmlTagName);
                                continue;
                            }
                            sb.AppendLine($"<{xmlTagName}><![CDATA[{newVal}]]></{xmlTagName}>");

                        }
                        tw.Write(sb);
                    }

                }

            }

        }
        private static void GenerateExcel(string key, string source, string destination, string[] destinationKeys,string excelFileName,bool isFromXML = false)
        {

            var d = new DirectoryInfo($@"{source}");
            var package = new ExcelPackage();
            foreach (var dkey in destinationKeys)
            {
                foreach (var f in d.GetFiles().Where(p => p.Name.IndexOf(key) != -1 || p.Name.IndexOf(key.ToLower()) != -1))
                {
                    var validExtension = isFromXML ? ".xml" : ".resx";
                    if (f.Extension != validExtension) continue;
                   

                    
                    var sourceFile = $@"{source}\{f.Name}";
                    var resxItems = GetResxItems(sourceFile, isFromXML);

                    //var package = new ExcelPackage();
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add(f.Name.Replace(".resx","").Replace(".xml",""));

                    ws.Cells[1, 1].Value = "Id";
                    ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    ws.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[1, 1].Style.Font.Bold = true;
                    ws.Cells[1, 1].Style.Locked = true;
                    ws.Column(1).Width = 24;

                    ws.Cells[1, 2].Value = key;
                    ws.Cells[1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    ws.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[1, 2].Style.Font.Bold = true;
                    ws.Cells[1, 2].Style.Locked = true;
                    ws.Column(2).Width = 100;


                    ws.Cells[1, 3].Value = dkey;
                    ws.Cells[1, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    ws.Cells[1, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[1, 3].Style.Font.Bold = true;
                    ws.Cells[1, 3].Style.Locked = true;
                    ws.Column(3).Width = 100;
                    var rowCtr = 2;
                    foreach (var i in resxItems)
                    {
                        //nobj.Add(new JProperty(i.id, i.value));
                        if (!string.IsNullOrWhiteSpace(i.XMLTag))
                        {
                            ws.Cells[rowCtr, 1].Value = i.XMLTag;
                            ws.Cells[rowCtr, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[rowCtr, 1].Style.Fill.BackgroundColor.SetColor(Color.CadetBlue);
                            ws.Cells[rowCtr,1].Style.Font.Bold = true;
                            ws.Cells[rowCtr, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            ws.Cells[rowCtr, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            rowCtr++;
                            continue;
                        }

                        if (i.SubItems != null && (i.SubItems != null || i.SubItems.Any()))
                        {
                            foreach (var si in i.SubItems)
                            {
                                if (!string.IsNullOrWhiteSpace(si.XMLTag))
                                {
                                    ws.Cells[rowCtr, 1].Value = si.XMLTag;
                                    ws.Cells[rowCtr, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    ws.Cells[rowCtr, 1].Style.Fill.BackgroundColor.SetColor(Color.CadetBlue);
                                    ws.Cells[rowCtr, 1].Style.Font.Bold = true;
                                    ws.Cells[rowCtr, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                    ws.Cells[rowCtr, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                    rowCtr++;
                                    continue;
                                }
                                ws.Cells[rowCtr, 1].Value = si.Id;
                                ws.Cells[rowCtr, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                ws.Cells[rowCtr, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                                ws.Cells[rowCtr, 2].Value = si.Value;
                                ws.Cells[rowCtr, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                ws.Cells[rowCtr, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                rowCtr++;

                            }
                            continue;
                        }
                        ws.Cells[rowCtr, 1].Value = i.Id;
                        ws.Cells[rowCtr, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        ws.Cells[rowCtr, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        ws.Cells[rowCtr, 2].Value = i.Value;
                        ws.Cells[rowCtr, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        ws.Cells[rowCtr, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        rowCtr++;
                    }
                    //var exd = $@"{destination}\{f.Name}.{dkey}.xlsx";
                    //package.SaveAs(new FileInfo(exd));
                }
                var exd = $@"{destination}\{excelFileName}.{dkey}.xlsx";
                package.SaveAs(new FileInfo(exd));
                MessageBox.Show("Success!");
            }
        }
    }
}
