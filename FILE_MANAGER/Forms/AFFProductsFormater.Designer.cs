namespace FILE_MANAGER
{
    partial class AFFProductsFormater
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
            this.label1 = new System.Windows.Forms.Label();
            this.rtbSource = new System.Windows.Forms.RichTextBox();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.radWTM = new System.Windows.Forms.RadioButton();
            this.radMTW = new System.Windows.Forms.RadioButton();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "WEB:";
            // 
            // rtbSource
            // 
            this.rtbSource.Location = new System.Drawing.Point(23, 157);
            this.rtbSource.Name = "rtbSource";
            this.rtbSource.Size = new System.Drawing.Size(511, 516);
            this.rtbSource.TabIndex = 8;
            this.rtbSource.Text = "";
            // 
            // rtbResult
            // 
            this.rtbResult.Location = new System.Drawing.Point(555, 157);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.ReadOnly = true;
            this.rtbResult.Size = new System.Drawing.Size(520, 516);
            this.rtbResult.TabIndex = 10;
            this.rtbResult.Text = "";
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSubmit.Location = new System.Drawing.Point(956, 679);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(98, 32);
            this.cmdSubmit.TabIndex = 11;
            this.cmdSubmit.Text = "Submit";
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClear.Location = new System.Drawing.Point(852, 679);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(98, 32);
            this.cmdClear.TabIndex = 12;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(552, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "RESULT";
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.radWTM);
            this.grpOptions.Controls.Add(this.radMTW);
            this.grpOptions.Location = new System.Drawing.Point(23, 36);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(373, 75);
            this.grpOptions.TabIndex = 42;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // radWTM
            // 
            this.radWTM.AutoSize = true;
            this.radWTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radWTM.Location = new System.Drawing.Point(20, 19);
            this.radWTM.Name = "radWTM";
            this.radWTM.Size = new System.Drawing.Size(154, 24);
            this.radWTM.TabIndex = 2;
            this.radWTM.TabStop = true;
            this.radWTM.Text = "WEB TO MOBILE";
            this.radWTM.UseVisualStyleBackColor = true;
            // 
            // radMTW
            // 
            this.radMTW.AutoSize = true;
            this.radMTW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMTW.Location = new System.Drawing.Point(190, 19);
            this.radMTW.Name = "radMTW";
            this.radMTW.Size = new System.Drawing.Size(154, 24);
            this.radMTW.TabIndex = 3;
            this.radMTW.TabStop = true;
            this.radMTW.Text = "MOBILE TO WEB";
            this.radMTW.UseVisualStyleBackColor = true;
            // 
            // AFFProductsFormater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 723);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.rtbSource);
            this.Controls.Add(this.label1);
            this.Name = "AFFProductsFormater";
            this.Text = "AFF ProductFormater";
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbSource;
        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.RadioButton radWTM;
        private System.Windows.Forms.RadioButton radMTW;
    }
}