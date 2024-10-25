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
using FILE_MANAGER.Model;

namespace FILE_MANAGER.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            var a = validateEmail("test");
            var b = validateEmail("x@test.com");
            var c = validateEmail("c.test.com");
            var d = validateEmail("@@test.com");
            var e = validateEmail("c_test@test.test.com");
            var f = validateEmail("$a12345@esample.com");
        }

        public bool validateEmail(string email)
        {
            var pattern =
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            return  Regex.IsMatch(email,
              pattern,
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        public  List<NavMenu> menus = new List<NavMenu>()
        {
            new NavMenu()
            {
                DisplayText = "Text Fixer",
                MenuClick = (sender, args) =>
                {
                    new TextFixer().ShowDialog();
                }
            },
            new NavMenu()
            {
                DisplayText = "New Language Manager",
                MenuClick = (sender, args) =>
                {
                    new NewLanguageManager().ShowDialog();
                }
            },
            new NavMenu()
            {
                DisplayText = "RESX Manager",
                MenuClick = (sender, args) =>
                {
                    new ResxManager().ShowDialog();
                }
            },
            new NavMenu()
            {
                DisplayText = "New Logo",
                MenuClick = (sender, args) =>
                {
                    new NewLogo().ShowDialog();
                }
            },
             new NavMenu()
            {
                DisplayText = "AFF PRODUCTS FORMATTER",
                MenuClick = (sender, args) =>
                {
                    new AFFProductsFormater().ShowDialog();
                }
            },
            new NavMenu()
            {
                DisplayText = "RESX TO EXCEL",
                MenuClick = (sender, args) =>
                {
                    new NewLanguageToExcel().ShowDialog();
                }
            },
            new NavMenu()
            {
                DisplayText = "XML To EXCEL",
                MenuClick = (sender, args) =>
                {
                    new XmlToExcel().ShowDialog();
                }
            },
            new NavMenu()
            {
                DisplayText = "EXCEL Converter",
                MenuClick = (sender, args) =>
                {
                    new ExcelConverter().ShowDialog();
                }
            },
               new NavMenu()
            {
                DisplayText = "EXCEL Manager (UL)",
                MenuClick = (sender, args) =>
                {
                    new ExcelManager().ShowDialog();
                }
            }
        };
        public void InitNavButtons()
        {
            int x_pos = 17,y_pos = 15, menu_w = 175, menu_h=118,nextCtr = 0;
            const int oxpos = 17;
            foreach (var menu in menus)
            {
                var newMenu = new Button()
                {
                    Location = new System.Drawing.Point(x_pos, y_pos),
                    Size = new System.Drawing.Size(menu_w, menu_h),
                    Text = menu.DisplayText,

                };
                newMenu.Click += new EventHandler(menu.MenuClick);
                panel1.Controls.Add(newMenu);
               
                nextCtr += 1;
                if (nextCtr % 3 == 0)
                {
                    x_pos = oxpos;
                    y_pos += menu_h + 5;

                }
                else
                {
                    x_pos += menu_w + 5;
                }
            }
        }
       
        private void Home_Load(object sender, EventArgs e)
        {
            InitNavButtons();
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
