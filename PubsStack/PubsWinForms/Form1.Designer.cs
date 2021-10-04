
namespace PubsWinForms
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
            this.lvAuthors = new System.Windows.Forms.ListView();
            this.txtTempID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.lblFName = new System.Windows.Forms.Label();
            this.lblLName = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvAuthors
            // 
            this.lvAuthors.HideSelection = false;
            this.lvAuthors.Location = new System.Drawing.Point(12, 12);
            this.lvAuthors.Name = "lvAuthors";
            this.lvAuthors.Size = new System.Drawing.Size(718, 361);
            this.lvAuthors.TabIndex = 0;
            this.lvAuthors.UseCompatibleStateImageBehavior = false;
            this.lvAuthors.View = System.Windows.Forms.View.Details;
            this.lvAuthors.SelectedIndexChanged += new System.EventHandler(this.lvAuthors_SelectedIndexChanged);
            // 
            // txtTempID
            // 
            this.txtTempID.Location = new System.Drawing.Point(769, 48);
            this.txtTempID.Name = "txtTempID";
            this.txtTempID.Size = new System.Drawing.Size(125, 27);
            this.txtTempID.TabIndex = 1;
            this.txtTempID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblID.Location = new System.Drawing.Point(813, 25);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(25, 20);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "ID";
            this.lblID.Click += new System.EventHandler(this.lblID_Click);
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(769, 101);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(125, 27);
            this.txtFName.TabIndex = 3;
            this.txtFName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(769, 164);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(125, 27);
            this.txtLName.TabIndex = 4;
            this.txtLName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLName.TextChanged += new System.EventHandler(this.txtLName_TextChanged);
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFName.Location = new System.Drawing.Point(788, 78);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(86, 20);
            this.lblFName.TabIndex = 5;
            this.lblFName.Text = "First Name";
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLName.Location = new System.Drawing.Point(788, 141);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(84, 20);
            this.lblLName.TabIndex = 6;
            this.lblLName.Text = "Last Name";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEdit.Location = new System.Drawing.Point(13, 395);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(139, 63);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 502);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblLName);
            this.Controls.Add(this.lblFName);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtTempID);
            this.Controls.Add(this.lvAuthors);
            this.Name = "frmMain";
            this.Text = "Authors";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvAuthors;
        private System.Windows.Forms.TextBox txtTempID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Button btnEdit;
    }
}

