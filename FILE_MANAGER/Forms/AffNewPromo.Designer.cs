namespace FILE_MANAGER
{
	partial class AffNewPromo
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
			this.SuspendLayout();
			// 
			// txtSource
			// 
			this.txtSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSource.Location = new System.Drawing.Point(118, 32);
			this.txtSource.Name = "txtSource";
			this.txtSource.Size = new System.Drawing.Size(439, 26);
			this.txtSource.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(17, 35);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 20);
			this.label4.TabIndex = 16;
			this.label4.Text = "source :";
			// 
			// cmdSubmit
			// 
			this.cmdSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdSubmit.Location = new System.Drawing.Point(459, 92);
			this.cmdSubmit.Name = "cmdSubmit";
			this.cmdSubmit.Size = new System.Drawing.Size(98, 32);
			this.cmdSubmit.TabIndex = 9;
			this.cmdSubmit.Text = "Submit";
			this.cmdSubmit.UseVisualStyleBackColor = true;
			this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
			// 
			// AffNewPromo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 164);
			this.Controls.Add(this.txtSource);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmdSubmit);
			this.Name = "AffNewPromo";
			this.Text = "AffNewPromo";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button cmdSubmit;
	}
}