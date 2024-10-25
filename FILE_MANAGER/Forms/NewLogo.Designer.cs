namespace FILE_MANAGER
{
	partial class NewLogo
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
			this.cmdSubmit = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.radWeb = new System.Windows.Forms.RadioButton();
			this.radMobile = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// txtSource
			// 
			this.txtSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSource.Location = new System.Drawing.Point(112, 43);
			this.txtSource.Name = "txtSource";
			this.txtSource.Size = new System.Drawing.Size(437, 26);
			this.txtSource.TabIndex = 19;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(29, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 20);
			this.label4.TabIndex = 20;
			this.label4.Text = "source :";
			// 
			// cmdSubmit
			// 
			this.cmdSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSubmit.Location = new System.Drawing.Point(451, 103);
			this.cmdSubmit.Name = "cmdSubmit";
			this.cmdSubmit.Size = new System.Drawing.Size(98, 32);
			this.cmdSubmit.TabIndex = 21;
			this.cmdSubmit.Text = "Submit";
			this.cmdSubmit.UseVisualStyleBackColor = true;
			this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(29, 81);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 20);
			this.label5.TabIndex = 23;
			this.label5.Text = "platform :";
			// 
			// radWeb
			// 
			this.radWeb.AutoSize = true;
			this.radWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radWeb.Location = new System.Drawing.Point(110, 81);
			this.radWeb.Name = "radWeb";
			this.radWeb.Size = new System.Drawing.Size(61, 22);
			this.radWeb.TabIndex = 24;
			this.radWeb.TabStop = true;
			this.radWeb.Text = "WEB";
			this.radWeb.UseVisualStyleBackColor = true;
			this.radWeb.CheckedChanged += new System.EventHandler(this.radWeb_CheckedChanged);
			// 
			// radMobile
			// 
			this.radMobile.AutoSize = true;
			this.radMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radMobile.Location = new System.Drawing.Point(177, 81);
			this.radMobile.Name = "radMobile";
			this.radMobile.Size = new System.Drawing.Size(82, 22);
			this.radMobile.TabIndex = 25;
			this.radMobile.TabStop = true;
			this.radMobile.Text = "MOBILE";
			this.radMobile.UseVisualStyleBackColor = true;
			// 
			// NewLogo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(575, 187);
			this.Controls.Add(this.radMobile);
			this.Controls.Add(this.radWeb);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cmdSubmit);
			this.Controls.Add(this.txtSource);
			this.Controls.Add(this.label4);
			this.Name = "NewLogo";
			this.Text = "NewLogo";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button cmdSubmit;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RadioButton radWeb;
		private System.Windows.Forms.RadioButton radMobile;
	}
}