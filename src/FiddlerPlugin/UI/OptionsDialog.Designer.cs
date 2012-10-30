namespace FiddlerPlugin.UI
{
	partial class OptionsDialog
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
			this.labelRowColor = new System.Windows.Forms.Label();
			this.textRowColor = new System.Windows.Forms.TextBox();
			this.textRowTextColor = new System.Windows.Forms.TextBox();
			this.labelRowTextColor = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDefaults = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelRowColor
			// 
			this.labelRowColor.AutoSize = true;
			this.labelRowColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRowColor.Location = new System.Drawing.Point(12, 13);
			this.labelRowColor.Name = "labelRowColor";
			this.labelRowColor.Size = new System.Drawing.Size(98, 13);
			this.labelRowColor.TabIndex = 0;
			this.labelRowColor.Text = "Entry Row Color";
			// 
			// textRowColor
			// 
			this.textRowColor.Location = new System.Drawing.Point(12, 30);
			this.textRowColor.Name = "textRowColor";
			this.textRowColor.Size = new System.Drawing.Size(174, 20);
			this.textRowColor.TabIndex = 1;
			this.textRowColor.TextChanged += new System.EventHandler(this.textColor_TextChanged);
			// 
			// textRowTextColor
			// 
			this.textRowTextColor.Location = new System.Drawing.Point(12, 74);
			this.textRowTextColor.Name = "textRowTextColor";
			this.textRowTextColor.Size = new System.Drawing.Size(174, 20);
			this.textRowTextColor.TabIndex = 3;
			this.textRowTextColor.TextChanged += new System.EventHandler(this.textColor_TextChanged);
			// 
			// labelRowTextColor
			// 
			this.labelRowTextColor.AutoSize = true;
			this.labelRowTextColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRowTextColor.Location = new System.Drawing.Point(12, 57);
			this.labelRowTextColor.Name = "labelRowTextColor";
			this.labelRowTextColor.Size = new System.Drawing.Size(127, 13);
			this.labelRowTextColor.TabIndex = 2;
			this.labelRowTextColor.Text = "Entry Row Text Color";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(12, 101);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDefaults
			// 
			this.btnDefaults.Location = new System.Drawing.Point(111, 101);
			this.btnDefaults.Name = "btnDefaults";
			this.btnDefaults.Size = new System.Drawing.Size(75, 23);
			this.btnDefaults.TabIndex = 5;
			this.btnDefaults.Text = "Defaults";
			this.btnDefaults.UseVisualStyleBackColor = true;
			this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
			// 
			// OptionsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(199, 139);
			this.Controls.Add(this.btnDefaults);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.textRowTextColor);
			this.Controls.Add(this.labelRowTextColor);
			this.Controls.Add(this.textRowColor);
			this.Controls.Add(this.labelRowColor);
			this.Name = "OptionsDialog";
			this.Text = "OptionsDialog";
			this.Load += new System.EventHandler(this.OptionsDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelRowColor;
		private System.Windows.Forms.TextBox textRowColor;
		private System.Windows.Forms.TextBox textRowTextColor;
		private System.Windows.Forms.Label labelRowTextColor;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnDefaults;
	}
}