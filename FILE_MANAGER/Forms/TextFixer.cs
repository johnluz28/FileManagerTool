using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FILE_MANAGER
{
	public partial class TextFixer : Form
	{
		public TextFixer()
		{
			InitializeComponent();
		}

		private void cmdSubmit_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(rtbFrom.Text))
			{
				MessageBox.Show("Please fill up all the required fields!");
				return;
			}

			var cleanText = rtbFrom.Text.Replace("\n", ""); /*rtbFrom.Text.Replace(" ", "").Replace("\n", "");*/
            rtbResult.Text = cleanText;
		}

        private void cmdNewDomainSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbFrom.Text))
            {
                MessageBox.Show("Please fill up all the required fields!");
                return;
            }

            var cleanText = rtbFrom.Text.Replace("\n", ",."); /*rtbFrom.Text.Replace(" ", "").Replace("\n", "");*/
            rtbResult.Text = cleanText;
        }
    }
}
