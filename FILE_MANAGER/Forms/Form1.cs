using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FILE_MANAGER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private List<LanguageModel> languages = new List<LanguageModel>()
            {
                  new LanguageModel() { Id = "IN",Code = "en-in"},
                  new LanguageModel() { Id = "US",Code = "en-us"},
                  new LanguageModel() { Id = "ID",Code = "id-id"},
                  new LanguageModel() { Id = "KH",Code = "km-kh"},
                  new LanguageModel() { Id = "KR",Code = "ko-kr"},
                  new LanguageModel() { Id = "TH",Code = "th-th"},
                  new LanguageModel() { Id = "VN",Code = "vi-vn"},
                  new LanguageModel() { Id = "CN",Code = "zh-cn"},
                  new LanguageModel() { Id = "JP",Code = "ja-jp"},
                  new LanguageModel() { Id = "AU",Code = "en-au"}
        };

        private void Init()
        {
            drpLanguage.Items.Clear();
            drpLanguage.Items.Add("-select-");
            languages.ForEach(p => drpLanguage.Items.Add(p.Id));
            drpMoveOptions.SelectedIndex = 0;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #region Events 
        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtDestination.Clear();
            txtTargetFolder.Clear();
            txtSourceFiles.Clear();
            drpMoveOptions.SelectedIndex = 0;
            drpLanguage.ResetText();
        }

        private void drpMoveOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpLanguage.SelectedIndex = 0;
            txtTargetFolder.Clear();
            txtDestination.Clear();
            txtSourceFiles.Clear();
            txtDestination.Enabled = true;
            txtSourceFiles.Enabled = true;
            cmdMove.Enabled = true;
            cmdClear.Enabled = true;
            switch (drpMoveOptions.SelectedIndex)
                {
                    case 0://-select-
                        txtTargetFolder.Enabled = false;
                        drpLanguage.Enabled = false;
                        txtDestination.Enabled = false;
                        txtSourceFiles.Enabled = false;
                        cmdMove.Enabled = false;
                        cmdClear.Enabled = false;
                    break;
                    case 1://move by destination
                        drpLanguage.Enabled = true;
                        txtTargetFolder.Enabled = false;
                        break;
                    case 2://move by folder id
                        drpLanguage.Enabled = true;
                        txtTargetFolder.Enabled = true;
                        break;
                    case 3://move by all language
                        drpLanguage.Enabled = false;
                        txtTargetFolder.Enabled = true;
                        break;
                }
        }

        private void cmdMove_Click(object sender, EventArgs e)
        {
            var source = txtSourceFiles.Text.Trim();
            var destination = txtDestination.Text.Trim();
            var targetFolder = txtTargetFolder.Text.Trim();
            switch (drpMoveOptions.SelectedIndex)
            {
                case 1: MoveByDestination(source,destination); break;
                case 2: MoveByFolderId(source,destination,targetFolder); break;
                case 3: MoveAllByLanguage(source,destination,targetFolder); break;
            }
        }
        #endregion

        #region Private Methods
        private void MoveByDestination(string source,string destination)
        {
            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(destination) || drpLanguage.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill up all the required Fields!");
                return;
            }

            var d = new DirectoryInfo(string.Format(@"{0}", source));

            var key = "-" + drpLanguage.SelectedItem.ToString() + ".";
            foreach (FileInfo f in d.GetFiles().Where(p => p.Name.IndexOf(key) != -1 || p.Name.IndexOf(key.ToLower()) != -1))
            {
                File.Move(string.Format(@"{0}\{1}", source, f.Name),
                         string.Format(@"{0}\{1}", destination, f.Name.Replace(key, ".").Replace(key.ToLower(), ".")));
            }
        }
        private void MoveByFolderId(string source, string destination, string targetFolder)
        {
            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(destination) || drpLanguage.SelectedIndex ==0 || string.IsNullOrWhiteSpace(targetFolder))
            {
                MessageBox.Show("Please fill up all the required Fields!");
                return;
            }

            var language =  languages.Where(p=> p.Id == drpLanguage.SelectedItem.ToString()).FirstOrDefault();

            var d = new DirectoryInfo(string.Format(@"{0}", source));

            foreach (FileInfo f in d.GetFiles().Where(p => p.Name.IndexOf(language.Key) != -1 || p.Name.IndexOf(language.Key.ToLower()) != -1))
            {
                var tdf = string.Format(@"{0}\{1}\{2}", destination, language.Code, targetFolder);
                if (!Directory.Exists(tdf)) Directory.CreateDirectory(tdf);
                File.Move(string.Format(@"{0}\{1}", source, f.Name),
                       string.Format(@"{0}\{1}",tdf, f.Name.Replace(language.Key, ".").Replace(language.Key.ToLower(), ".")));
            }
        }

        private void MoveAllByLanguage(string source, string destination, string targetFolder)
        {
            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(destination) || string.IsNullOrWhiteSpace(targetFolder))
            {
                MessageBox.Show("Please fill up all the required Fields!");
                return;
            }

            var d = new DirectoryInfo(string.Format(@"{0}", source));

            foreach (var lang in languages)
            {
                foreach (FileInfo f in d.GetFiles().Where(p => p.Name.IndexOf(lang.Key) != -1 || p.Name.IndexOf(lang.Key.ToLower()) != -1))
                {
                    //Target Destination Folder
                    var tdf = string.Format(@"{0}\{1}\{2}", destination, lang.Code, targetFolder);
                    if (!Directory.Exists(tdf)) Directory.CreateDirectory(tdf);
                    File.Move(string.Format(@"{0}\{1}", source, f.Name),
                            string.Format(@"{0}\{1}", tdf, f.Name.Replace(lang.Key, ".").Replace(lang.Key.ToLower(), ".")));
                }
            }
        }

        private void CopyByDestination(string source, string destination)
        {
            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(destination) || drpLanguage.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill up all the required Fields!");
                return;
            }

            var d = new DirectoryInfo(string.Format(@"{0}", source));

            var key = "-us.";
            var destinationKey = "";  //  $"-{drpLanguage.SelectedItem.ToString()}.";
            foreach (FileInfo f in d.GetFiles().Where(p => p.Name.IndexOf(key) != -1 || p.Name.IndexOf(key.ToLower()) != -1))
            {
                File.Copy(string.Format(@"{0}\{1}", source, f.Name),
                         string.Format(@"{0}\{1}", destination, f.Name.Replace(key, destinationKey).Replace(key.ToLower(), destinationKey)));
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            var source = txtSourceFiles.Text.Trim();
            var destination = txtDestination.Text.Trim();
            var targetFolder = txtTargetFolder.Text.Trim();
            switch (drpMoveOptions.SelectedIndex)
            {
                case 1: CopyByDestination(source, destination); break;
                case 2: MoveByFolderId(source, destination, targetFolder); break;
                case 3: MoveAllByLanguage(source, destination, targetFolder); break;
            }
        }
    }
}
