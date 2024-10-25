using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FILE_MANAGER
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
			chkIntegral.Checked = true;
		}
		public  decimal RoundUp(decimal input, int places)
		{
			decimal multiplier = (decimal)Math.Pow(10, Convert.ToDouble(places));
			return Math.Ceiling(input * multiplier) / multiplier;
		}
		public  decimal RoundDown(decimal input, int places)
		{
			decimal multiplier = (decimal)Math.Pow(10, Convert.ToDouble(places));
			return Math.Floor(input * multiplier) / multiplier;
		}
		/// <summary>
		/// display value with commas  eg: 10,000.00
		/// </summary>
		/// <param name="input"></param>
		/// <param name="places"></param>
		/// <returns></returns>
		public  string NumberWithCommas(decimal input, int places,bool checkIntegral)
		{
			decimal noIntegral = 0;
			if (checkIntegral)
			{
				noIntegral = RoundUp(input - Math.Truncate(input), places);//remove integral value //eg:1.05 result 0.05

				if (input <= 0 && noIntegral == 0)
					return null;//eg: input 0.31 then continue if noIntegral 0.00 return null
			}

			var roundUpVal = RoundUp(input, places);

			if (checkIntegral && noIntegral == 0)//eg : input 1.00 result is 1
				return RemoveLeadingZeros(roundUpVal.ToString("#,0#", System.Globalization.CultureInfo.InvariantCulture));

			var decimalZeros = "";
			for (var i = 0; i < places; i++)
			{
				decimalZeros += "0";
			}
			var format = $"#,0.{decimalZeros}#";

			return roundUpVal.ToString(format, System.Globalization.CultureInfo.InvariantCulture);
		}
		private  string RemoveLeadingZeros(string str)
		{
			var retVal = Regex.Replace(str, "(^0+|(:)0*([1-9])|(:0)0*)", "$2$3$4");
			return retVal;
		}
		private void cmdSubmit_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace((txtAmount.Text.Trim())) || string.IsNullOrWhiteSpace(txtPlaces.Text.Trim())) return;

			lblResult.Text = NumberWithCommas(decimal.Parse(txtAmount.Text), int.Parse(txtPlaces.Text),chkIntegral.Checked);

		}
	}
}
