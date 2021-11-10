using Microsoft.Extensions.Configuration;
using Model;
using PubsServiceBus;
using Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ViewModels;

namespace PubsWinForms
{
    public partial class frmMain : Form
    {
        ServiceBus _service;

        public frmMain()
        {
            InitializeComponent();

            string con = GetConnection();

            authorDBRepo au_repo = new authorDBRepo(con);
            BookRepoDB b_repo = new BookRepoDB(con);

            _service = new ServiceBus(au_repo, b_repo);

            lvAuthors.View = View.Details;
            lvAuthors.FullRowSelect = true;
            lvAuthors.MultiSelect = false;
            lvAuthors.GridLines = true;

            lvAuthors.Columns.Add("First");
            lvAuthors.Columns.Add("Last");
            lvAuthors.Columns.Add("Phone #");
            lvAuthors.Columns.Add("Address");
            lvAuthors.Columns.Add("City");
            lvAuthors.Columns.Add("State");
            lvAuthors.Columns.Add("ZIP");
            lvAuthors.Columns.Add("Contract");

            ListViewItem item;

            List<AuthorViewModel> authors = _service.findAllAuthors();

            foreach(AuthorViewModel au in authors)
            {
                item = new ListViewItem(au.FirstName);
                item.SubItems.Add(au.LastName);
                item.SubItems.Add(au.Phone);
                item.SubItems.Add(au.Address);
                item.SubItems.Add(au.City);
                item.SubItems.Add(au.State);
                item.SubItems.Add(au.Zip);
                item.SubItems.Add(au.Contract.ToString());
                item.Tag = au.ID;
                lvAuthors.Items.Add(item);
            }
            lvAuthors.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvAuthors.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            List<Book> books = (List<Book>)b_repo.FindAll();

            foreach (Book b in books)
            {
                lbAllBooks.Items.Add(b.title);
            }

            List<Publisher> pubs = new List<Publisher>();

            pubs = au_repo.FindAllPubs();

            foreach(Publisher p in pubs)
			{
                cbPubID.Items.Add(p.pub_id);
			}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static string GetConnection()
        {
            IConfiguration Configuration;

            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

            Configuration = builder.Build();

            string con = Configuration["Configuration:pubsDBSConnectionString"];

            return con;
        }

        private void lvAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            string con = GetConnection();
            authorDBRepo au_repo = new authorDBRepo(con);
            BookRepoDB b_repo = new BookRepoDB(con);
            _service = new ServiceBus(au_repo, b_repo);

            lbBooks.Items.Clear();

            //check for unselected
            if (lvAuthors.SelectedItems.Count <= 0)
            {
                return;
            }

            ListViewItem item = lvAuthors.SelectedItems[0];
            List<Book> books = (List<Book>)b_repo.ItemsFor(_service.FindAuthor((string)item.Tag));

            foreach(Book b in books)
            {
                lbBooks.Items.Add(b.title);
            }
            lvAuthors.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvAuthors.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            
            txtTempID.Text = (string)item.Tag;
            txtFName.Text = item.SubItems[0].Text;
            txtLName.Text = item.SubItems[1].Text;
            txtPhoneNum.Text = item.SubItems[2].Text;
            txtAddress.Text = item.SubItems[3].Text;
            txtCity.Text = item.SubItems[4].Text;
            txtState.Text = item.SubItems[5].Text;
            txtZIP.Text = item.SubItems[6].Text;
            txtContract.Text = item.SubItems[7].Text;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string con = GetConnection();
            authorDBRepo au_repo = new authorDBRepo(con);
            BookRepoDB b_repo = new BookRepoDB(con);

            _service = new ServiceBus(au_repo, b_repo);

            Author au = _service.FindAuthor(lvAuthors.SelectedItems[0].Tag.ToString());

            ListViewItem item = lvAuthors.SelectedItems[0];

            au.au_lname = txtLName.Text.ToString();
            au.au_fname = txtFName.Text.ToString();
            au.au_phone = txtPhoneNum.Text.ToString();
            au.au_address = txtAddress.Text.ToString();
            au.au_city = txtCity.Text.ToString();
            au.au_state = txtState.Text.ToString();
            au.au_zip = txtZIP.Text.ToString();
            au.au_contract = Convert.ToInt32(txtContract.Text);

            au_repo.Update(au);

            item.SubItems[0].Text = txtFName.Text;
            item.SubItems[1].Text = txtLName.Text;
            item.SubItems[2].Text = txtPhoneNum.Text;
            item.SubItems[3].Text = txtAddress.Text;
            item.SubItems[4].Text = txtCity.Text;
            item.SubItems[5].Text = txtState.Text;
            item.SubItems[6].Text = txtZIP.Text;
            item.SubItems[7].Text = txtContract.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string con = GetConnection();
            authorDBRepo au_repo = new authorDBRepo(con);
            BookRepoDB b_repo = new BookRepoDB(con);
            _service = new ServiceBus(au_repo, b_repo);

			#region Add error checking
			if (txtTempID.Text == "")
			{
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if(txtLName.Text == "")
			{
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if(txtFName.Text == "")
			{
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if(txtPhoneNum.Text == "")
			{
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if(txtAddress.Text == "")
			{
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if(txtCity.Text == "")
			{
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if(txtState.Text == "")
			{
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if(txtZIP.Text == "")
			{
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if(txtContract.Text == "")
			{
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            #endregion
            else
            {
                if ((Convert.ToInt32(txtContract.Text) != 0) && (Convert.ToInt32(txtContract.Text) != 1))
                {
                    MessageBox.Show("Please enter either '1' for true or '0' for false.");
                    return;
                }


                Author newAuthor = new Author();
                newAuthor.au_id = txtTempID.Text.ToString();
                newAuthor.au_lname = txtLName.Text.ToString();
                newAuthor.au_fname = txtFName.Text.ToString();
                newAuthor.au_phone = txtPhoneNum.Text.ToString();
                newAuthor.au_address = txtAddress.Text.ToString();
                newAuthor.au_city = txtCity.Text.ToString();
                newAuthor.au_state = txtState.Text.ToString();
                newAuthor.au_zip = txtZIP.Text.ToString();
                newAuthor.au_contract = Convert.ToInt32(txtContract.Text);

                au_repo.Create(newAuthor);

                ListViewItem item;
                item = new ListViewItem(newAuthor.au_fname);
                item.SubItems.Add(newAuthor.au_lname);
                item.SubItems.Add(newAuthor.au_phone);
                item.SubItems.Add(newAuthor.au_address);
                item.SubItems.Add(newAuthor.au_city);
                item.SubItems.Add(newAuthor.au_state);
                item.SubItems.Add(newAuthor.au_zip);
                item.SubItems.Add(newAuthor.au_contract.ToString());
                item.Tag = newAuthor.au_id;
                lvAuthors.Items.Add(item);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlgR = MessageBox.Show("Are you sure you want to delete this author?", "DELETE", MessageBoxButtons.YesNo);

            if(dlgR == DialogResult.Yes)
            {
                string con = GetConnection();
                authorDBRepo au_repo = new authorDBRepo(con);
                BookRepoDB b_repo = new BookRepoDB(con);
                _service = new ServiceBus(au_repo, b_repo);

                Author au = _service.FindAuthor(lvAuthors.SelectedItems[0].Tag.ToString());

                au_repo.Delete(au);

                lvAuthors.SelectedItems[0].Remove();
            }
        }

        private void lbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string con = GetConnection();
            authorDBRepo au_repo = new authorDBRepo(con);
            BookRepoDB b_repo = new BookRepoDB(con);
            _service = new ServiceBus(au_repo, b_repo);

            List<Book> books = (List<Book>)b_repo.ItemsFor(_service.FindAuthor(lvAuthors.SelectedItems[0].Tag.ToString()));

            if(lbBooks.SelectedIndex < books.Count)
            {
                Book b;

                if (lbBooks.SelectedIndex == -1)
				{
                    b = books[books.Count - 1];
                }
                else
				{
                    b = books[lbBooks.SelectedIndex];
                }

                txtTitleID.Text = b.title_id;
                txtType.Text = b.type;
                txtTitle.Text = b.title;

                /*if(b.publisher.pub_id != null)
				{
                    txtPubID.Text = b.publisher.pub_id;
                }
                else
				{
                    txtPubID.Text = "NULL";
				}*/
                
                if(b.publisher.pub_name != null)
				{
                    txtPubName.Text = b.publisher.pub_name;
                }
                else
				{
                    txtPubName.Text = "NULL";
				}

                if(b.price != null)
                {
                    txtPrice.Text = b.price.ToString();
                }
                else
                {
                    txtPrice.Text = "NULL";
                }
                
                if(b.ytd_sales != null)
				{
                    txtYTD.Text = b.ytd_sales.ToString();
                }
                else
				{
                    txtYTD.Text = "NULL";
				}
                
                dtPubDate.Value = b.pubdate;
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string con = GetConnection();
            authorDBRepo au_repo = new authorDBRepo(con);
            BookRepoDB b_repo = new BookRepoDB(con);
            _service = new ServiceBus(au_repo, b_repo);

            List<Book> books = (List<Book>)b_repo.FindAll();

			if (lbAllBooks.SelectedIndex < 0)
			{
                MessageBox.Show("Please select a book to add to an author", "ATTENTION", MessageBoxButtons.OK);
            }
            else
			{
                Book b = books[lbAllBooks.SelectedIndex];
                Author au = _service.FindAuthor(lvAuthors.SelectedItems[0].Tag.ToString());

                if (lbBooks.Items.Contains(b.title))
                {
                    MessageBox.Show("This book is already assigned to this author", "ATTENTION", MessageBoxButtons.OK);
                    return;
                }

                b_repo.Update(b, au.au_id);

                lbBooks.Items.Add(b.title);
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if(lbBooks.SelectedIndex == -1)
			{
                MessageBox.Show("Please select a book to be deleted", "ATTENTION", MessageBoxButtons.OK);
                return;
            }

            string con = GetConnection();
            authorDBRepo au_repo = new authorDBRepo(con);
            BookRepoDB b_repo = new BookRepoDB(con);
            _service = new ServiceBus(au_repo, b_repo);

            DialogResult dlgR = MessageBox.Show("Are you sure you want to delete this book from this author?", "DELETE", MessageBoxButtons.YesNo);

            if(dlgR == DialogResult.Yes)
			{
                List<Book> books = (List<Book>)b_repo.FindAll();

                Book b = books[lbBooks.SelectedIndex];
                Author au = _service.FindAuthor(lvAuthors.SelectedItems[0].Tag.ToString());

                b_repo.Delete(b, au);

                lbBooks.Items.RemoveAt(lbBooks.SelectedIndex);
            }
        }

        private void btnCreateBook_Click(object sender, EventArgs e)
        {
			#region Create Error Checking
			if (txtTitle.Text == "")
            {
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if (txtTitleID.Text == "")
            {
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if (txtType.Text == "")
            {
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if (cbPubID.SelectedItem == null /*txtPubID.Text == ""*/)
            {
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if (txtPubName.Text == "")
            {
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if (txtPrice.Text == "")
            {
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
            else if (txtYTD.Text == "")
            {
                MessageBox.Show("A field has not been filled in. Please make sure all fields have been filled.", "ERROR", MessageBoxButtons.OK);
                return;
            }
			#endregion
			else
			{
                string con = GetConnection();
                authorDBRepo au_repo = new authorDBRepo(con);
                BookRepoDB b_repo = new BookRepoDB(con);
                _service = new ServiceBus(au_repo, b_repo);

                Publisher p = new Publisher();
                p.pub_id = cbPubID.SelectedItem.ToString();
                p.pub_name = txtPubName.Text;

                Book book = new Book();
                book.title_id = txtTitleID.Text;
                book.title = txtTitle.Text;
                book.type = txtType.Text;
                book.publisher = p;
                book.price = Convert.ToDecimal(txtPrice.Text);
                book.ytd_sales = Convert.ToInt32(txtYTD.Text);
                book.pubdate = dtPubDate.Value;

                b_repo.Create(book);

                lbAllBooks.Items.Add(book.title);
            }
        }

        #region Labels And Textboxes And Extras
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblLName_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitleID_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void txtTempID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPhone_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblYTD_Click(object sender, EventArgs e)
        {

        }

        private void txtYTD_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPubName_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }
		#endregion
	}
}
