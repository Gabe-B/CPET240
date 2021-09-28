
namespace Lab3_GabeBlack_Proj
{
	partial class frmMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.btnCalculator = new System.Windows.Forms.Button();
			this.lblResults = new System.Windows.Forms.Label();
			this.txtResultsBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// btnCalculator
			// 
			this.btnCalculator.Location = new System.Drawing.Point(208, 23);
			this.btnCalculator.Name = "btnCalculator";
			this.btnCalculator.Size = new System.Drawing.Size(106, 42);
			this.btnCalculator.TabIndex = 0;
			this.btnCalculator.Text = "Calculator";
			this.btnCalculator.UseVisualStyleBackColor = true;
			this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
			// 
			// lblResults
			// 
			this.lblResults.AutoSize = true;
			this.lblResults.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblResults.Location = new System.Drawing.Point(32, 5);
			this.lblResults.Name = "lblResults";
			this.lblResults.Size = new System.Drawing.Size(147, 15);
			this.lblResults.TabIndex = 1;
			this.lblResults.Text = "Results From Calculations";
			// 
			// txtResultsBox
			// 
			this.txtResultsBox.Location = new System.Drawing.Point(12, 23);
			this.txtResultsBox.Name = "txtResultsBox";
			this.txtResultsBox.Size = new System.Drawing.Size(190, 255);
			this.txtResultsBox.TabIndex = 2;
			this.txtResultsBox.Text = "";
			this.txtResultsBox.TextChanged += new System.EventHandler(this.txtResultsBox_TextChanged);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(326, 288);
			this.Controls.Add(this.txtResultsBox);
			this.Controls.Add(this.lblResults);
			this.Controls.Add(this.btnCalculator);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(342, 327);
			this.Name = "frmMain";
			this.Text = "Calculating Your Wages";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCalculator;
		private System.Windows.Forms.Label lblResults;
		private System.Windows.Forms.RichTextBox txtResultsBox;
	}
}

