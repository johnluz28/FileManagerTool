using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
namespace FILE_MANAGER.Helper
{
	public enum NumString
	{
		one = 1,
		two = 2,
		three = 3,
		four = 4,
		five = 5,
		six = 6,
		seven = 7,
		eight = 8,
		nine = 9,
		ten = 10
	}
	public static class HtmlNodeExtensions
	{
		public static HtmlNodeCollection GetElementsContainsId(this HtmlNode htmlNode, string elementId)
		{
			return string.IsNullOrEmpty(elementId) ? null : htmlNode.SelectNodes(string.Format("//a[contains(translate(@id, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{0}')]", elementId));
		}

		public static HtmlNodeCollection GetElementsContainsId(this HtmlNode htmlNode, string elementId, string tag)
		{
			return string.IsNullOrEmpty(elementId)
				? null
				: htmlNode.SelectNodes(string.Format(
					"//{1}[contains(translate(@id, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{0}')]",
					elementId, tag));
		}

		public static HtmlNode GetElementSingleContainsId(this HtmlNode htmlNode, string elementId, string tag)
		{
			return GetElementsContainsId(htmlNode, elementId, tag).FirstOrDefault();
		}

		public static IEnumerable<HtmlNode> GetElementsByTagName(this HtmlNode parent, string name)
		{
			return parent.Descendants(name);
		}

		public static HtmlNode GetElementSingleByTagName(this HtmlNode parent, string name)
		{
			return parent.Descendants(name).FirstOrDefault();
		}

		public static void RemoveNode(this HtmlDocument htmlDocument, string elementId)
		{
			var node = htmlDocument.GetElementbyId(elementId);
			node?.Remove();
		}

		public static void RemoveClass(this HtmlDocument htmlDocument, string elementId, string className)
		{
			var node = htmlDocument.GetElementbyId(elementId);
			node?.RemoveClass(className);
		}

		public static void AddClass(this HtmlDocument htmlDocument, string elementId, string className)
		{
			var node = htmlDocument.GetElementbyId(elementId);
			node?.AddClass(className);
		}

		public static void RemoveClass(this HtmlDocument htmlDocument, string elementId, string className, out HtmlNode node)
		{
			node = htmlDocument.GetElementbyId(elementId);
			node?.RemoveClass(className);
		}

		public static NumString GetStringCount(this HtmlNodeCollection htmlNodeCollection)
		{
			NumString menuCount;
			Enum.TryParse(htmlNodeCollection.Count.ToString(), out menuCount);

			return menuCount;
		}

		public static NumString GetStringCount(this IEnumerable<HtmlNode> htmlNodeCollection)
		{
			NumString menuCount;
			Enum.TryParse(htmlNodeCollection.Count().ToString(), out menuCount);

			return menuCount;
		}
	}
}
