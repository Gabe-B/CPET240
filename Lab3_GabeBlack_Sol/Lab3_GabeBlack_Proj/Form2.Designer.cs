
namespace Lab3_GabeBlack_Proj
{
	partial class frmCalc
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalc));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbWageCustom = new System.Windows.Forms.RadioButton();
			this.rbWage4 = new System.Windows.Forms.RadioButton();
			this.rbWage3 = new System.Windows.Forms.RadioButton();
			this.rbWage2 = new System.Windows.Forms.RadioButton();
			this.rbWage1 = new System.Windows.Forms.RadioButton();
			this.lblNonStdWage = new System.Windows.Forms.Label();
			this.txtNSWInput = new System.Windows.Forms.TextBox();
			this.lblHoursWorked = new System.Windows.Forms.Label();
			this.txtHWInput = new System.Windows.Forms.TextBox();
			this.lblFullName = new System.Windows.Forms.Label();
			this.txtFullName = new System.Windows.Forms.TextBox();
			this.btnRunCalcs = new System.Windows.Forms.Button();
			this.btnSuspend = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbWageCustom);
			this.groupBox1.Controls.Add(this.rbWage4);
			this.groupBox1.Controls.Add(this.rbWage3);
			this.groupBox1.Controls.Add(this.rbWage2);
			this.groupBox1.Controls.Add(this.rbWage1);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.groupBox1.Size = new System.Drawing.Size(123, 155);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select Your Wage";
			// 
			// rbWageCustom
			// 
			this.rbWageCustom.AutoSize = true;
			this.rbWageCustom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rbWageCustom.Location = new System.Drawing.Point(6, 122);
			this.rbWageCustom.Name = "rbWageCustom";
			this.rbWageCustom.Size = new System.Drawing.Size(86, 19);
			this.rbWageCustom.TabIndex = 9;
			this.rbWageCustom.TabStop = true;
			this.rbWageCustom.Text = "Other wage";
			this.rbWageCustom.UseVisualStyleBackColor = true;
			this.rbWageCustom.CheckedChanged += new System.EventHandler(this.rbWageCustom_CheckedChanged);
			// 
			// rbWage4
			// 
			this.rbWage4.AutoSize = true;
			this.rbWage4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rbWage4.Location = new System.Drawing.Point(6, 97);
			this.rbWage4.Name = "rbWage4";
			this.rbWage4.Size = new System.Drawing.Size(58, 19);
			this.rbWage4.TabIndex = 8;
			this.rbWage4.TabStop = true;
			this.rbWage4.Text = "$11.20";
			this.rbWage4.UseVisualStyleBackColor = true;
			this.rbWage4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
			// 
			// rbWage3
			// 
			this.rbWage3.AutoSize = true;
			this.rbWage3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rbWage3.Location = new System.Drawing.Point(6, 72);
			this.rbWage3.Name = "rbWage3";
			this.rbWage3.Size = new System.Drawing.Size(58, 19);
			this.rbWage3.TabIndex = 7;
			this.rbWage3.TabStop = true;
			this.rbWage3.Text = "$10.00";
			this.rbWage3.UseVisualStyleBackColor = true;
			this.rbWage3.CheckedChanged += new System.EventHandler(this.rbWage3_CheckedChanged);
			// 
			// rbWage2
			// 
			this.rbWage2.AutoSize = true;
			this.rbWage2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rbWage2.Location = new System.Drawing.Point(6, 47);
			this.rbWage2.Name = "rbWage2";
			this.rbWage2.Size = new System.Drawing.Size(52, 19);
			this.rbWage2.TabIndex = 6;
			this.rbWage2.TabStop = true;
			this.rbWage2.Text = "$9.33";
			this.rbWage2.UseVisualStyleBackColor = true;
			this.rbWage2.CheckedChanged += new System.EventHandler(this.rbWage2_CheckedChanged);
			// 
			// rbWage1
			// 
			this.rbWage1.AutoSize = true;
			this.rbWage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rbWage1.Location = new System.Drawing.Point(6, 22);
			this.rbWage1.Name = "rbWage1";
			this.rbWage1.Size = new System.Drawing.Size(52, 19);
			this.rbWage1.TabIndex = 5;
			this.rbWage1.TabStop = true;
			this.rbWage1.Text = "$8.75";
			this.rbWage1.UseVisualStyleBackColor = true;
			this.rbWage1.CheckedChanged += new System.EventHandler(this.rbWage1_CheckedChanged);
			// 
			// lblNonStdWage
			// 
			this.lblNonStdWage.AutoSize = true;
			this.lblNonStdWage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblNonStdWage.Location = new System.Drawing.Point(157, 66);
			this.lblNonStdWage.Name = "lblNonStdWage";
			this.lblNonStdWage.Size = new System.Drawing.Size(118, 15);
			this.lblNonStdWage.TabIndex = 1;
			this.lblNonStdWage.Text = "Non Standard Wage";
			// 
			// txtNSWInput
			// 
			this.txtNSWInput.Location = new System.Drawing.Point(157, 85);
			this.txtNSWInput.Name = "txtNSWInput";
			this.txtNSWInput.Size = new System.Drawing.Size(118, 23);
			this.txtNSWInput.TabIndex = 2;
			this.txtNSWInput.TextChanged += new System.EventHandler(this.txtNSWInput_TextChanged);
			// 
			// lblHoursWorked
			// 
			this.lblHoursWorked.AutoSize = true;
			this.lblHoursWorked.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblHoursWorked.Location = new System.Drawing.Point(157, 117);
			this.lblHoursWorked.Name = "lblHoursWorked";
			this.lblHoursWorked.Size = new System.Drawing.Size(88, 15);
			this.lblHoursWorked.TabIndex = 3;
			this.lblHoursWorked.Text = "Hours Worked";
			// 
			// txtHWInput
			// 
			this.txtHWInput.Location = new System.Drawing.Point(157, 136);
			this.txtHWInput.Name = "txtHWInput";
			this.txtHWInput.Size = new System.Drawing.Size(118, 23);
			this.txtHWInput.TabIndex = 4;
			this.txtHWInput.TextChanged += new System.EventHandler(this.txtHWInput_TextChanged);
			// 
			// lblFullName
			// 
			this.lblFullName.AutoSize = true;
			this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblFullName.Location = new System.Drawing.Point(157, 16);
			this.lblFullName.Name = "lblFullName";
			this.lblFullName.Size = new System.Drawing.Size(62, 15);
			this.lblFullName.TabIndex = 5;
			this.lblFullName.Text = "Full Name";
			this.lblFullName.Click += new System.EventHandler(this.lblFullName_Click);
			// 
			// txtFullName
			// 
			this.txtFullName.Location = new System.Drawing.Point(157, 35);
			this.txtFullName.Name = "txtFullName";
			this.txtFullName.Size = new System.Drawing.Size(118, 23);
			this.txtFullName.TabIndex = 6;
			this.txtFullName.TextChanged += new System.EventHandler(this.txtFullName_TextChanged);
			// 
			// btnRunCalcs
			// 
			this.btnRunCalcs.Location = new System.Drawing.Point(12, 173);
			this.btnRunCalcs.Name = "btnRunCalcs";
			this.btnRunCalcs.Size = new System.Drawing.Size(263, 23);
			this.btnRunCalcs.TabIndex = 7;
			this.btnRunCalcs.Text = "Run Calculations";
			this.btnRunCalcs.UseVisualStyleBackColor = true;
			this.btnRunCalcs.Click += new System.EventHandler(this.btnRunCalcs_Click);
			// 
			// btnSuspend
			// 
			this.btnSuspend.Location = new System.Drawing.Point(12, 203);
			this.btnSuspend.Name = "btnSuspend";
			this.btnSuspend.Size = new System.Drawing.Size(263, 23);
			this.btnSuspend.TabIndex = 8;
			this.btnSuspend.Text = "Suspend to View Calculations";
			this.btnSuspend.UseVisualStyleBackColor = true;
			this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
			// 
			// frmCalc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(290, 236);
			this.Controls.Add(this.btnSuspend);
			this.Controls.Add(this.btnRunCalcs);
			this.Controls.Add(this.txtFullName);
			this.Controls.Add(this.lblFullName);
			this.Controls.Add(this.txtHWInput);
			this.Controls.Add(this.lblHoursWorked);
			this.Controls.Add(this.txtNSWInput);
			this.Controls.Add(this.lblNonStdWage);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(306, 275);
			this.Name = "frmCalc";
			this.Text = "Input The Data";
			this.Load += new System.EventHandler(this.frmCalc_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblNonStdWage;
		private System.Windows.Forms.TextBox txtNSWInput;
		private System.Windows.Forms.Label lblHoursWorked;
		private System.Windows.Forms.TextBox txtHWInput;
		private System.Windows.Forms.Label lblFullName;
		private System.Windows.Forms.TextBox txtFullName;
		private System.Windows.Forms.Button btnRunCalcs;
		private System.Windows.Forms.Button btnSuspend;
		private System.Windows.Forms.RadioButton rbWage2;
		private System.Windows.Forms.RadioButton rbWage1;
		private System.Windows.Forms.RadioButton rbWageCustom;
		private System.Windows.Forms.RadioButton rbWage4;
		private System.Windows.Forms.RadioButton rbWage3;
	}
}