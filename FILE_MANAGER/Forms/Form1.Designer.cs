namespace FILE_MANAGER
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdMove = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLanguage = new System.Windows.Forms.Label();
            this.txtSourceFiles = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.drpLanguage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTargetFolder = new System.Windows.Forms.TextBox();
            this.cmdClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.drpMoveOptions = new System.Windows.Forms.ComboBox();
            this.cmdCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdMove
            // 
            this.cmdMove.Location = new System.Drawing.Point(124, 237);
            this.cmdMove.Name = "cmdMove";
            this.cmdMove.Size = new System.Drawing.Size(86, 22);
            this.cmdMove.TabIndex = 5;
            this.cmdMove.Text = "Move";
            this.cmdMove.UseVisualStyleBackColor = true;
            this.cmdMove.Click += new System.EventHandler(this.cmdMove_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(19, 122);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(298, 20);
            this.txtDestination.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "*Destination/Root folder";
            // 
            // lbLanguage
            // 
            this.lbLanguage.AutoSize = true;
            this.lbLanguage.Location = new System.Drawing.Point(16, 200);
            this.lbLanguage.Name = "lbLanguage";
            this.lbLanguage.Size = new System.Drawing.Size(59, 13);
            this.lbLanguage.TabIndex = 4;
            this.lbLanguage.Text = "*Language";
            // 
            // txtSourceFiles
            // 
            this.txtSourceFiles.Location = new System.Drawing.Point(19, 77);
            this.txtSourceFiles.Name = "txtSourceFiles";
            this.txtSourceFiles.Size = new System.Drawing.Size(298, 20);
            this.txtSourceFiles.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "*Source Folder Path";
            // 
            // drpLanguage
            // 
            this.drpLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpLanguage.FormattingEnabled = true;
            this.drpLanguage.Location = new System.Drawing.Point(78, 197);
            this.drpLanguage.Name = "drpLanguage";
            this.drpLanguage.Size = new System.Drawing.Size(239, 21);
            this.drpLanguage.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "*Folder Name:";
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder.Location = new System.Drawing.Point(19, 167);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.Size = new System.Drawing.Size(298, 20);
            this.txtTargetFolder.TabIndex = 3;
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(19, 237);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(87, 22);
            this.cmdClear.TabIndex = 6;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "*Move by : ";
            // 
            // drpMoveOptions
            // 
            this.drpMoveOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpMoveOptions.FormattingEnabled = true;
            this.drpMoveOptions.Items.AddRange(new object[] {
            "-Select-",
            "Destination Path",
            "Folder Name",
            "All Languages"});
            this.drpMoveOptions.Location = new System.Drawing.Point(78, 22);
            this.drpMoveOptions.Name = "drpMoveOptions";
            this.drpMoveOptions.Size = new System.Drawing.Size(239, 21);
            this.drpMoveOptions.TabIndex = 0;
            this.drpMoveOptions.SelectedIndexChanged += new System.EventHandler(this.drpMoveOptions_SelectedIndexChanged);
            // 
            // cmdCopy
            // 
            this.cmdCopy.Location = new System.Drawing.Point(231, 237);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Size = new System.Drawing.Size(86, 22);
            this.cmdCopy.TabIndex = 14;
            this.cmdCopy.Text = "Copy";
            this.cmdCopy.UseVisualStyleBackColor = true;
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 276);
            this.Controls.Add(this.cmdCopy);
            this.Controls.Add(this.drpMoveOptions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTargetFolder);
            this.Controls.Add(this.drpLanguage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSourceFiles);
            this.Controls.Add(this.lbLanguage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.cmdMove);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asset Helper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdMove;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbLanguage;
        private System.Windows.Forms.TextBox txtSourceFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drpLanguage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTargetFolder;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox drpMoveOptions;
        private System.Windows.Forms.Button cmdCopy;
    }
}

