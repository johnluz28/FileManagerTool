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
using FILE_MANAGER.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FILE_MANAGER
{
    public partial class AFFProductsFormater : Form
    {
        public AFFProductsFormater()
        {
            InitializeComponent();
            //var x = "VN:\r\nT&#224;i khoản của bạn đ&#227; bị tạm kh&#243;a\r\n\r\nCN: \r\n你的账号已被暂停使用\r\n\r\nID:\r\nAkun anda telah ditangguhkan\r\n\r\nKR: \r\n회원님의 계정이 정지되었습니다. \r\n\r\nTH :\r\nบัญชีของคุณถูกระงับ";
            //var y = Regex.Replace(x, @"(\r\n?|\n)/gm", "<br />");
            //var z = Regex.Replace(x, @"\r\n?|\n", "<br />");
            //DateTime? a = null;
            //var b = a.ToDateTimeSafe();
            radWTM.Checked = true;
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
         
            if (string.IsNullOrWhiteSpace(rtbSource.Text))
            {
                MessageBox.Show("Please enter a valid source json string!");
                return;
            }
            
            if (radMTW.Checked)
            {
                var products = new JArray();
                var source = JsonConvert.DeserializeObject<JObject>(rtbSource.Text);
                foreach (var x in source)
                {
                    string productCode = x.Key;
                    JToken displayText = x.Value;
                    products.Add(JObject.FromObject(new
                    {
                        productCode,
                        displayText
                    }));
                }
                var result = JToken.FromObject(new
                {
                    products
                });
                rtbResult.Text = result.ToString();
            }
            else
            {
                
                var source = JsonConvert.DeserializeObject<JObject>(rtbSource.Text);
                var subAffiliateSummary = new JObject();
                foreach (var x in source["products"].ToArray())
                {
                    subAffiliateSummary.Add(
                        new JProperty(x["productCode"].ToStringSafe(), x["displayText"].ToString())
                        );
                }
                var result = JToken.FromObject(new
                {
                    subAffiliateSummary
                });
                rtbResult.Text = result.ToString();

            }
        
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            rtbResult.Clear();
            rtbSource.Clear();
            rtbSource.Focus();
        }
    }
}
