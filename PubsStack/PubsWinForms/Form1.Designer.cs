
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.lvAuthors = new System.Windows.Forms.ListView();
			this.txtTempID = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
			this.txtFName = new System.Windows.Forms.TextBox();
			this.txtLName = new System.Windows.Forms.TextBox();
			this.lblFName = new System.Windows.Forms.Label();
			this.lblLName = new System.Windows.Forms.Label();
			this.btnEdit = new System.Windows.Forms.Button();
			this.lblPhone = new System.Windows.Forms.Label();
			this.txtPhoneNum = new System.Windows.Forms.TextBox();
			this.lblAddress = new System.Windows.Forms.Label();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.lblCity = new System.Windows.Forms.Label();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.lblState = new System.Windows.Forms.Label();
			this.txtState = new System.Windows.Forms.TextBox();
			this.lblZIP = new System.Windows.Forms.Label();
			this.txtZIP = new System.Windows.Forms.TextBox();
			this.lblContract = new System.Windows.Forms.Label();
			this.txtContract = new System.Windows.Forms.TextBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.lbBooks = new System.Windows.Forms.ListBox();
			this.txtTitleID = new System.Windows.Forms.TextBox();
			this.txtType = new System.Windows.Forms.TextBox();
			this.lblTitleID = new System.Windows.Forms.Label();
			this.lblType = new System.Windows.Forms.Label();
			this.lblPubID = new System.Windows.Forms.Label();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.lblPrice = new System.Windows.Forms.Label();
			this.txtYTD = new System.Windows.Forms.TextBox();
			this.lblYTD = new System.Windows.Forms.Label();
			this.dtPubDate = new System.Windows.Forms.DateTimePicker();
			this.btnAddBook = new System.Windows.Forms.Button();
			this.lbAllBooks = new System.Windows.Forms.ListBox();
			this.lblPubName = new System.Windows.Forms.Label();
			this.txtPubName = new System.Windows.Forms.TextBox();
			this.btnDeleteBook = new System.Windows.Forms.Button();
			this.btnCreateBook = new System.Windows.Forms.Button();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.cbPubID = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lvAuthors
			// 
			this.lvAuthors.HideSelection = false;
			this.lvAuthors.Location = new System.Drawing.Point(12, 12);
			this.lvAuthors.Name = "lvAuthors";
			this.lvAuthors.Size = new System.Drawing.Size(460, 361);
			this.lvAuthors.TabIndex = 0;
			this.lvAuthors.UseCompatibleStateImageBehavior = false;
			this.lvAuthors.View = System.Windows.Forms.View.Details;
			this.lvAuthors.SelectedIndexChanged += new System.EventHandler(this.lvAuthors_SelectedIndexChanged);
			// 
			// txtTempID
			// 
			this.txtTempID.Location = new System.Drawing.Point(488, 78);
			this.txtTempID.Name = "txtTempID";
			this.txtTempID.Size = new System.Drawing.Size(125, 27);
			this.txtTempID.TabIndex = 1;
			this.txtTempID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtTempID.TextChanged += new System.EventHandler(this.txtTempID_TextChanged);
			// 
			// lblID
			// 
			this.lblID.AutoSize = true;
			this.lblID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblID.Location = new System.Drawing.Point(539, 58);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(25, 20);
			this.lblID.TabIndex = 2;
			this.lblID.Text = "ID";
			this.lblID.Click += new System.EventHandler(this.lblID_Click);
			// 
			// txtFName
			// 
			this.txtFName.Location = new System.Drawing.Point(487, 33);
			this.txtFName.Name = "txtFName";
			this.txtFName.Size = new System.Drawing.Size(125, 27);
			this.txtFName.TabIndex = 3;
			this.txtFName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtLName
			// 
			this.txtLName.Location = new System.Drawing.Point(632, 33);
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
			this.lblFName.Location = new System.Drawing.Point(506, 10);
			this.lblFName.Name = "lblFName";
			this.lblFName.Size = new System.Drawing.Size(86, 20);
			this.lblFName.TabIndex = 5;
			this.lblFName.Text = "First Name";
			// 
			// lblLName
			// 
			this.lblLName.AutoSize = true;
			this.lblLName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblLName.Location = new System.Drawing.Point(653, 8);
			this.lblLName.Name = "lblLName";
			this.lblLName.Size = new System.Drawing.Size(84, 20);
			this.lblLName.TabIndex = 6;
			this.lblLName.Text = "Last Name";
			this.lblLName.Click += new System.EventHandler(this.lblLName_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnEdit.Location = new System.Drawing.Point(12, 403);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(140, 55);
			this.btnEdit.TabIndex = 7;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// lblPhone
			// 
			this.lblPhone.AutoSize = true;
			this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblPhone.Location = new System.Drawing.Point(664, 60);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(66, 20);
			this.lblPhone.TabIndex = 8;
			this.lblPhone.Text = "Phone #";
			this.lblPhone.Click += new System.EventHandler(this.lblPhone_Click);
			// 
			// txtPhoneNum
			// 
			this.txtPhoneNum.Location = new System.Drawing.Point(632, 78);
			this.txtPhoneNum.Name = "txtPhoneNum";
			this.txtPhoneNum.Size = new System.Drawing.Size(125, 27);
			this.txtPhoneNum.TabIndex = 9;
			this.txtPhoneNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblAddress
			// 
			this.lblAddress.AutoSize = true;
			this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblAddress.Location = new System.Drawing.Point(591, 106);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Size = new System.Drawing.Size(66, 20);
			this.lblAddress.TabIndex = 10;
			this.lblAddress.Text = "Address";
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(544, 129);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(153, 27);
			this.txtAddress.TabIndex = 11;
			this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblCity
			// 
			this.lblCity.AutoSize = true;
			this.lblCity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblCity.Location = new System.Drawing.Point(535, 156);
			this.lblCity.Name = "lblCity";
			this.lblCity.Size = new System.Drawing.Size(36, 20);
			this.lblCity.TabIndex = 12;
			this.lblCity.Text = "City";
			// 
			// txtCity
			// 
			this.txtCity.Location = new System.Drawing.Point(488, 179);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(125, 27);
			this.txtCity.TabIndex = 13;
			this.txtCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblState
			// 
			this.lblState.AutoSize = true;
			this.lblState.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblState.Location = new System.Drawing.Point(673, 156);
			this.lblState.Name = "lblState";
			this.lblState.Size = new System.Drawing.Size(45, 20);
			this.lblState.TabIndex = 14;
			this.lblState.Text = "State";
			// 
			// txtState
			// 
			this.txtState.Location = new System.Drawing.Point(632, 179);
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(125, 27);
			this.txtState.TabIndex = 15;
			this.txtState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblZIP
			// 
			this.lblZIP.AutoSize = true;
			this.lblZIP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblZIP.Location = new System.Drawing.Point(534, 206);
			this.lblZIP.Name = "lblZIP";
			this.lblZIP.Size = new System.Drawing.Size(32, 20);
			this.lblZIP.TabIndex = 16;
			this.lblZIP.Text = "ZIP";
			// 
			// txtZIP
			// 
			this.txtZIP.Location = new System.Drawing.Point(488, 228);
			this.txtZIP.Name = "txtZIP";
			this.txtZIP.Size = new System.Drawing.Size(125, 27);
			this.txtZIP.TabIndex = 17;
			this.txtZIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblContract
			// 
			this.lblContract.AutoSize = true;
			this.lblContract.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblContract.Location = new System.Drawing.Point(661, 206);
			this.lblContract.Name = "lblContract";
			this.lblContract.Size = new System.Drawing.Size(69, 20);
			this.lblContract.TabIndex = 18;
			this.lblContract.Text = "Contract";
			// 
			// txtContract
			// 
			this.txtContract.Location = new System.Drawing.Point(632, 229);
			this.txtContract.Name = "txtContract";
			this.txtContract.Size = new System.Drawing.Size(125, 27);
			this.txtContract.TabIndex = 19;
			this.txtContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnAdd
			// 
			this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnAdd.Location = new System.Drawing.Point(172, 403);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(140, 55);
			this.btnAdd.TabIndex = 20;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnDelete.Location = new System.Drawing.Point(332, 403);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(140, 55);
			this.btnDelete.TabIndex = 22;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// lbBooks
			// 
			this.lbBooks.FormattingEnabled = true;
			this.lbBooks.ItemHeight = 20;
			this.lbBooks.Location = new System.Drawing.Point(816, 12);
			this.lbBooks.Name = "lbBooks";
			this.lbBooks.Size = new System.Drawing.Size(515, 144);
			this.lbBooks.TabIndex = 24;
			this.lbBooks.SelectedIndexChanged += new System.EventHandler(this.lbBooks_SelectedIndexChanged);
			// 
			// txtTitleID
			// 
			this.txtTitleID.Location = new System.Drawing.Point(942, 188);
			this.txtTitleID.Name = "txtTitleID";
			this.txtTitleID.Size = new System.Drawing.Size(125, 27);
			this.txtTitleID.TabIndex = 28;
			this.txtTitleID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtTitleID.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// txtType
			// 
			this.txtType.Location = new System.Drawing.Point(1075, 188);
			this.txtType.Name = "txtType";
			this.txtType.Size = new System.Drawing.Size(125, 27);
			this.txtType.TabIndex = 29;
			this.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtType.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
			// 
			// lblTitleID
			// 
			this.lblTitleID.AutoSize = true;
			this.lblTitleID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblTitleID.Location = new System.Drawing.Point(975, 165);
			this.lblTitleID.Name = "lblTitleID";
			this.lblTitleID.Size = new System.Drawing.Size(60, 20);
			this.lblTitleID.TabIndex = 30;
			this.lblTitleID.Text = "Title ID";
			this.lblTitleID.Click += new System.EventHandler(this.lblTitleID_Click);
			// 
			// lblType
			// 
			this.lblType.AutoSize = true;
			this.lblType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblType.Location = new System.Drawing.Point(1118, 165);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(42, 20);
			this.lblType.TabIndex = 31;
			this.lblType.Text = "Type";
			this.lblType.Click += new System.EventHandler(this.lblType_Click);
			// 
			// lblPubID
			// 
			this.lblPubID.AutoSize = true;
			this.lblPubID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblPubID.Location = new System.Drawing.Point(849, 165);
			this.lblPubID.Name = "lblPubID";
			this.lblPubID.Size = new System.Drawing.Size(56, 20);
			this.lblPubID.TabIndex = 35;
			this.lblPubID.Text = "Pub ID";
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(1206, 188);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(125, 27);
			this.txtPrice.TabIndex = 36;
			this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
			// 
			// lblPrice
			// 
			this.lblPrice.AutoSize = true;
			this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblPrice.Location = new System.Drawing.Point(1248, 166);
			this.lblPrice.Name = "lblPrice";
			this.lblPrice.Size = new System.Drawing.Size(43, 20);
			this.lblPrice.TabIndex = 37;
			this.lblPrice.Text = "Price";
			this.lblPrice.Click += new System.EventHandler(this.lblPrice_Click);
			// 
			// txtYTD
			// 
			this.txtYTD.Location = new System.Drawing.Point(1206, 243);
			this.txtYTD.Name = "txtYTD";
			this.txtYTD.Size = new System.Drawing.Size(125, 27);
			this.txtYTD.TabIndex = 38;
			this.txtYTD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtYTD.TextChanged += new System.EventHandler(this.txtYTD_TextChanged);
			// 
			// lblYTD
			// 
			this.lblYTD.AutoSize = true;
			this.lblYTD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblYTD.Location = new System.Drawing.Point(1233, 221);
			this.lblYTD.Name = "lblYTD";
			this.lblYTD.Size = new System.Drawing.Size(77, 20);
			this.lblYTD.TabIndex = 39;
			this.lblYTD.Text = "YTD Sales";
			this.lblYTD.Click += new System.EventHandler(this.lblYTD_Click);
			// 
			// dtPubDate
			// 
			this.dtPubDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.dtPubDate.Location = new System.Drawing.Point(1075, 297);
			this.dtPubDate.Name = "dtPubDate";
			this.dtPubDate.Size = new System.Drawing.Size(256, 27);
			this.dtPubDate.TabIndex = 40;
			this.dtPubDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
			// 
			// btnAddBook
			// 
			this.btnAddBook.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnAddBook.Location = new System.Drawing.Point(611, 330);
			this.btnAddBook.Name = "btnAddBook";
			this.btnAddBook.Size = new System.Drawing.Size(236, 44);
			this.btnAddBook.TabIndex = 41;
			this.btnAddBook.Text = "Add Book To Author";
			this.btnAddBook.UseVisualStyleBackColor = true;
			this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
			// 
			// lbAllBooks
			// 
			this.lbAllBooks.FormattingEnabled = true;
			this.lbAllBooks.ItemHeight = 20;
			this.lbAllBooks.Location = new System.Drawing.Point(853, 330);
			this.lbAllBooks.Name = "lbAllBooks";
			this.lbAllBooks.Size = new System.Drawing.Size(478, 144);
			this.lbAllBooks.TabIndex = 42;
			this.lbAllBooks.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// lblPubName
			// 
			this.lblPubName.AutoSize = true;
			this.lblPubName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblPubName.Location = new System.Drawing.Point(967, 222);
			this.lblPubName.Name = "lblPubName";
			this.lblPubName.Size = new System.Drawing.Size(82, 20);
			this.lblPubName.TabIndex = 43;
			this.lblPubName.Text = "Pub Name";
			this.lblPubName.Click += new System.EventHandler(this.lblPubName_Click);
			// 
			// txtPubName
			// 
			this.txtPubName.Location = new System.Drawing.Point(816, 243);
			this.txtPubName.Name = "txtPubName";
			this.txtPubName.Size = new System.Drawing.Size(381, 27);
			this.txtPubName.TabIndex = 44;
			this.txtPubName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtPubName.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
			// 
			// btnDeleteBook
			// 
			this.btnDeleteBook.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnDeleteBook.Location = new System.Drawing.Point(611, 380);
			this.btnDeleteBook.Name = "btnDeleteBook";
			this.btnDeleteBook.Size = new System.Drawing.Size(236, 46);
			this.btnDeleteBook.TabIndex = 45;
			this.btnDeleteBook.Text = "Delete Book From Author";
			this.btnDeleteBook.UseVisualStyleBackColor = true;
			this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
			// 
			// btnCreateBook
			// 
			this.btnCreateBook.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnCreateBook.Location = new System.Drawing.Point(611, 432);
			this.btnCreateBook.Name = "btnCreateBook";
			this.btnCreateBook.Size = new System.Drawing.Size(236, 42);
			this.btnCreateBook.TabIndex = 46;
			this.btnCreateBook.Text = "Create New Book";
			this.btnCreateBook.UseVisualStyleBackColor = true;
			this.btnCreateBook.Click += new System.EventHandler(this.btnCreateBook_Click);
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(816, 297);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(251, 27);
			this.txtTitle.TabIndex = 47;
			this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblTitle.Location = new System.Drawing.Point(916, 274);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(40, 20);
			this.lblTitle.TabIndex = 48;
			this.lblTitle.Text = "Title";
			// 
			// cbPubID
			// 
			this.cbPubID.FormattingEnabled = true;
			this.cbPubID.Location = new System.Drawing.Point(816, 188);
			this.cbPubID.Name = "cbPubID";
			this.cbPubID.Size = new System.Drawing.Size(120, 28);
			this.cbPubID.TabIndex = 49;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1356, 486);
			this.Controls.Add(this.cbPubID);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.btnCreateBook);
			this.Controls.Add(this.btnDeleteBook);
			this.Controls.Add(this.txtPubName);
			this.Controls.Add(this.lblPubName);
			this.Controls.Add(this.lbAllBooks);
			this.Controls.Add(this.btnAddBook);
			this.Controls.Add(this.dtPubDate);
			this.Controls.Add(this.lblYTD);
			this.Controls.Add(this.txtYTD);
			this.Controls.Add(this.lblPrice);
			this.Controls.Add(this.txtPrice);
			this.Controls.Add(this.lblPubID);
			this.Controls.Add(this.lblType);
			this.Controls.Add(this.lblTitleID);
			this.Controls.Add(this.txtType);
			this.Controls.Add(this.txtTitleID);
			this.Controls.Add(this.lbBooks);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.txtContract);
			this.Controls.Add(this.lblContract);
			this.Controls.Add(this.txtZIP);
			this.Controls.Add(this.lblZIP);
			this.Controls.Add(this.txtState);
			this.Controls.Add(this.lblState);
			this.Controls.Add(this.txtCity);
			this.Controls.Add(this.lblCity);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.lblAddress);
			this.Controls.Add(this.txtPhoneNum);
			this.Controls.Add(this.lblPhone);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.lblLName);
			this.Controls.Add(this.lblFName);
			this.Controls.Add(this.txtLName);
			this.Controls.Add(this.txtFName);
			this.Controls.Add(this.lblID);
			this.Controls.Add(this.txtTempID);
			this.Controls.Add(this.lvAuthors);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.MinimumSize = new System.Drawing.Size(1374, 533);
			this.Name = "frmMain";
			this.Text = "Authors and Books";
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
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label lblZIP;
        private System.Windows.Forms.TextBox txtZIP;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.TextBox txtContract;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lbBooks;
        private System.Windows.Forms.TextBox txtTitleID;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblTitleID;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPubID;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtYTD;
        private System.Windows.Forms.Label lblYTD;
        private System.Windows.Forms.DateTimePicker dtPubDate;
		private System.Windows.Forms.Button btnAddBook;
		private System.Windows.Forms.ListBox lbAllBooks;
		private System.Windows.Forms.Label lblPubName;
		private System.Windows.Forms.TextBox txtPubName;
		private System.Windows.Forms.Button btnDeleteBook;
		private System.Windows.Forms.Button btnCreateBook;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.ComboBox cbPubID;
	}
}

