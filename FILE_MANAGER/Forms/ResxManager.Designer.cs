namespace FILE_MANAGER
{
	partial class ResxManager
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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radResxToJson = new System.Windows.Forms.RadioButton();
            this.radResxToXML = new System.Windows.Forms.RadioButton();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.txtXMLContainerTAg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSource2 = new System.Windows.Forms.TextBox();
            this.cmdBrowse2 = new System.Windows.Forms.Button();
            this.cmdSubmitMerge = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSource3 = new System.Windows.Forms.TextBox();
            this.cmdBrowse3 = new System.Windows.Forms.Button();
            this.panCompare = new System.Windows.Forms.Panel();
            this.chkHasSoureToMerge = new System.Windows.Forms.CheckBox();
            this.chkIncludeXmlHeaderTag = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUTF7Encoding = new System.Windows.Forms.CheckBox();
            this.panCompare.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.BackColor = System.Drawing.Color.White;
            this.txtSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.Location = new System.Drawing.Point(122, 26);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(640, 26);
            this.txtSource.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "source :";
            // 
            // rtbResult
            // 
            this.rtbResult.Location = new System.Drawing.Point(32, 332);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(891, 469);
            this.rtbResult.TabIndex = 7;
            this.rtbResult.Text = "";
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSubmit.Location = new System.Drawing.Point(560, 293);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(135, 29);
            this.cmdSubmit.TabIndex = 5;
            this.cmdSubmit.Text = "Submit";
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "result:";
            // 
            // radResxToJson
            // 
            this.radResxToJson.AutoSize = true;
            this.radResxToJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radResxToJson.Location = new System.Drawing.Point(20, 19);
            this.radResxToJson.Name = "radResxToJson";
            this.radResxToJson.Size = new System.Drawing.Size(83, 24);
            this.radResxToJson.TabIndex = 2;
            this.radResxToJson.TabStop = true;
            this.radResxToJson.Text = "toJSON";
            this.radResxToJson.UseVisualStyleBackColor = true;
            this.radResxToJson.CheckedChanged += new System.EventHandler(this.radResxToJson_CheckedChanged);
            // 
            // radResxToXML
            // 
            this.radResxToXML.AutoSize = true;
            this.radResxToXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radResxToXML.Location = new System.Drawing.Point(119, 19);
            this.radResxToXML.Name = "radResxToXML";
            this.radResxToXML.Size = new System.Drawing.Size(74, 24);
            this.radResxToXML.TabIndex = 3;
            this.radResxToXML.TabStop = true;
            this.radResxToXML.Text = "toXML";
            this.radResxToXML.UseVisualStyleBackColor = true;
            this.radResxToXML.CheckedChanged += new System.EventHandler(this.radResxToXML_CheckedChanged);
            // 
            // ofdBrowse
            // 
            this.ofdBrowse.FileName = "openFileDialog1";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowse.Location = new System.Drawing.Point(788, 26);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(135, 29);
            this.cmdBrowse.TabIndex = 1;
            this.cmdBrowse.Text = "BrowseFile";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // txtXMLContainerTAg
            // 
            this.txtXMLContainerTAg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXMLContainerTAg.Location = new System.Drawing.Point(701, 74);
            this.txtXMLContainerTAg.Name = "txtXMLContainerTAg";
            this.txtXMLContainerTAg.Size = new System.Drawing.Size(217, 26);
            this.txtXMLContainerTAg.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "source to merge :";
            // 
            // txtSource2
            // 
            this.txtSource2.BackColor = System.Drawing.Color.White;
            this.txtSource2.Enabled = false;
            this.txtSource2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource2.Location = new System.Drawing.Point(170, 52);
            this.txtSource2.Name = "txtSource2";
            this.txtSource2.ReadOnly = true;
            this.txtSource2.Size = new System.Drawing.Size(560, 26);
            this.txtSource2.TabIndex = 2;
            // 
            // cmdBrowse2
            // 
            this.cmdBrowse2.Enabled = false;
            this.cmdBrowse2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowse2.Location = new System.Drawing.Point(736, 52);
            this.cmdBrowse2.Name = "cmdBrowse2";
            this.cmdBrowse2.Size = new System.Drawing.Size(135, 29);
            this.cmdBrowse2.TabIndex = 3;
            this.cmdBrowse2.Text = "BrowseFile";
            this.cmdBrowse2.UseVisualStyleBackColor = true;
            this.cmdBrowse2.Click += new System.EventHandler(this.cmdBrowse2_Click);
            // 
            // cmdSubmitMerge
            // 
            this.cmdSubmitMerge.Enabled = false;
            this.cmdSubmitMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSubmitMerge.Location = new System.Drawing.Point(703, 290);
            this.cmdSubmitMerge.Name = "cmdSubmitMerge";
            this.cmdSubmitMerge.Size = new System.Drawing.Size(220, 29);
            this.cmdSubmitMerge.TabIndex = 6;
            this.cmdSubmitMerge.Text = "Submit and  Merge";
            this.cmdSubmitMerge.UseVisualStyleBackColor = true;
            this.cmdSubmitMerge.Click += new System.EventHandler(this.cmdSubmitMerge_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = " xml source :";
            // 
            // txtSource3
            // 
            this.txtSource3.BackColor = System.Drawing.Color.White;
            this.txtSource3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource3.Location = new System.Drawing.Point(170, 87);
            this.txtSource3.Name = "txtSource3";
            this.txtSource3.ReadOnly = true;
            this.txtSource3.Size = new System.Drawing.Size(560, 26);
            this.txtSource3.TabIndex = 4;
            // 
            // cmdBrowse3
            // 
            this.cmdBrowse3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowse3.Location = new System.Drawing.Point(736, 87);
            this.cmdBrowse3.Name = "cmdBrowse3";
            this.cmdBrowse3.Size = new System.Drawing.Size(135, 29);
            this.cmdBrowse3.TabIndex = 5;
            this.cmdBrowse3.Text = "BrowseFile";
            this.cmdBrowse3.UseVisualStyleBackColor = true;
            this.cmdBrowse3.Click += new System.EventHandler(this.cmdBrowse3_Click);
            // 
            // panCompare
            // 
            this.panCompare.Controls.Add(this.chkHasSoureToMerge);
            this.panCompare.Controls.Add(this.chkIncludeXmlHeaderTag);
            this.panCompare.Controls.Add(this.cmdBrowse3);
            this.panCompare.Controls.Add(this.txtSource3);
            this.panCompare.Controls.Add(this.label5);
            this.panCompare.Controls.Add(this.txtSource2);
            this.panCompare.Controls.Add(this.label3);
            this.panCompare.Controls.Add(this.cmdBrowse2);
            this.panCompare.Location = new System.Drawing.Point(32, 139);
            this.panCompare.Name = "panCompare";
            this.panCompare.Size = new System.Drawing.Size(891, 134);
            this.panCompare.TabIndex = 4;
            // 
            // chkHasSoureToMerge
            // 
            this.chkHasSoureToMerge.AutoSize = true;
            this.chkHasSoureToMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHasSoureToMerge.Location = new System.Drawing.Point(499, 15);
            this.chkHasSoureToMerge.Name = "chkHasSoureToMerge";
            this.chkHasSoureToMerge.Size = new System.Drawing.Size(173, 24);
            this.chkHasSoureToMerge.TabIndex = 41;
            this.chkHasSoureToMerge.Text = "has source to merge";
            this.chkHasSoureToMerge.UseVisualStyleBackColor = true;
            this.chkHasSoureToMerge.CheckedChanged += new System.EventHandler(this.chkHasSoureToMerge_CheckedChanged);
            // 
            // chkIncludeXmlHeaderTag
            // 
            this.chkIncludeXmlHeaderTag.AutoSize = true;
            this.chkIncludeXmlHeaderTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncludeXmlHeaderTag.Location = new System.Drawing.Point(90, 15);
            this.chkIncludeXmlHeaderTag.Name = "chkIncludeXmlHeaderTag";
            this.chkIncludeXmlHeaderTag.Size = new System.Drawing.Size(377, 24);
            this.chkIncludeXmlHeaderTag.TabIndex = 1;
            this.chkIncludeXmlHeaderTag.Text = "include \"<?xml version=\"1.0\" encoding=\"utf-8\" ?>\"";
            this.chkIncludeXmlHeaderTag.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(558, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "xml container tag :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radResxToJson);
            this.groupBox1.Controls.Add(this.radResxToXML);
            this.groupBox1.Location = new System.Drawing.Point(32, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 75);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // chkUTF7Encoding
            // 
            this.chkUTF7Encoding.AutoSize = true;
            this.chkUTF7Encoding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUTF7Encoding.Location = new System.Drawing.Point(286, 74);
            this.chkUTF7Encoding.Name = "chkUTF7Encoding";
            this.chkUTF7Encoding.Size = new System.Drawing.Size(139, 24);
            this.chkUTF7Encoding.TabIndex = 42;
            this.chkUTF7Encoding.Text = "UTF7 Encoding";
            this.chkUTF7Encoding.UseVisualStyleBackColor = true;
            // 
            // ResxManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 813);
            this.Controls.Add(this.chkUTF7Encoding);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdSubmitMerge);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtXMLContainerTAg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panCompare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ResxManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResxConverter";
            this.Load += new System.EventHandler(this.ResxToJSON_Load);
            this.panCompare.ResumeLayout(false);
            this.panCompare.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RichTextBox rtbResult;
		private System.Windows.Forms.Button cmdSubmit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radResxToJson;
		private System.Windows.Forms.RadioButton radResxToXML;
		private System.Windows.Forms.OpenFileDialog ofdBrowse;
		private System.Windows.Forms.Button cmdBrowse;
		private System.Windows.Forms.TextBox txtXMLContainerTAg;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSource2;
		private System.Windows.Forms.Button cmdBrowse2;
		private System.Windows.Forms.Button cmdSubmitMerge;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtSource3;
		private System.Windows.Forms.Button cmdBrowse3;
		private System.Windows.Forms.Panel panCompare;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkIncludeXmlHeaderTag;
		private System.Windows.Forms.CheckBox chkHasSoureToMerge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkUTF7Encoding;
    }
}