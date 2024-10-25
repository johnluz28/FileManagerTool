using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FILE_MANAGER.Helper;
using HtmlAgilityPack;

namespace FILE_MANAGER
{
	public partial class AffNewPromo : Form
	{
		public AffNewPromo()
		{
			InitializeComponent();
			//var s = "First time Deposit? <a href=\"../BankingDetails.aspx\">Enroll your MPay Phone Number</a> now to speed up your deposit process.";
			//var htmlDoc = new HtmlAgilityPack.HtmlDocument();
			//htmlDoc.LoadHtml(s);

			////var html = htmlDoc.DocumentNode.SelectNodes("a").FirstOrDefault();
				
			///*HtmlNodeExtensions.GetElementSingleByTagName(htmlDoc.DocumentNode, "a");*/
			//var accountDom = "account";
			////html.SetAttributeValue("href", $"{accountDom}/profile/bankingdetails.aspx");
			////if (htmlDoc.DocumentNode.SelectNodes("a").Any())
			////{
			////	//htmlDoc.DocumentNode.SetAttributeValue("href", $"{accountDom}/profile/bankingdetails.aspx");
			////	//htmlDoc.DocumentNode.SelectNodes("a").FirstOrDefault().SetAttributeValue("href", $"{accountDom}/profile/bankingdetails.aspx");
			////	var newNodeStr = "<foo>bar</foo>";
			////	var newNode = HtmlNode.CreateNode(newNodeStr);
			////	item.ParentNode.ReplaceChild(newNode, item);
			////}

			////foreach (HtmlNode node in htmlDoc.DocumentNode
			////	.SelectSingleNode("a"))
			////{
			////	node.SetAttributeValue("href",
			////		$"{accountDom}/profile/bankingdetails.aspx");
			////}
			////;
			//htmlDoc.DocumentNode.SelectSingleNode("a").SetAttributeValue("href", $"{accountDom}/profile/bankingdetails.aspx");

			//MessageBox.Show(htmlDoc.DocumentNode.OuterHtml);

		}

		private void cmdSubmit_Click(object sender, EventArgs e)
		{
			//copyTo();
			copyTo(true);
		}


		private void copyTo(bool isMobile = false)
		{
			var platForm = isMobile ? "mobile" : "web";
			var source = txtSource.Text.Trim();
			var destination = isMobile ? $@"{AppConfig.MobPath}" :  $@"{AppConfig.WebPath}";
			processCopy(source,destination, isMobile ? AppConfig.MobBuildPath : null);
			//img files
			var imgDestination = isMobile ? AppConfig.MobImgPath : AppConfig.WebImgPath;
			var imgSource = $@"{source}\img";
			processCopy(imgSource, imgDestination, isMobile? AppConfig.MobImgBuildPath : null);
			MessageBox.Show($"copy to aff {platForm} Successful!");
			
		}

		private void processCopy(string source ,string destination,string mobilePath = null)
		{
			var d = new DirectoryInfo($@"{source}");
			foreach (var f in d.GetFiles())
			{
				File.Copy($@"{source}\{f.Name}",
					$@"{destination}\{f.Name}", true);
				if (!string.IsNullOrWhiteSpace(mobilePath))
				{
					File.Copy($@"{source}\{f.Name}",
						$@"{mobilePath}\{f.Name}", true);
				}
			}
		}
	}
}
