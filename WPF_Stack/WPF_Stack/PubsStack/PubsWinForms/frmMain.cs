using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Extensions.Configuration;

using Repositories;
using Model;
using ViewModel;
using PubsServiceBus; 

namespace PubsWinForms
{
    public partial class frmMain : Form
    {
        PubsService _service; 

        public frmMain()
        {
            InitializeComponent();

            string con = GetConnection(); 

            AuthorRepoDB au_repo
                = new AuthorRepoDB(con);
            BookRepoDB b_repo = new BookRepoDB(con);

            _service = new PubsService(au_repo, b_repo);

            lvAuthors.View = View.Details;
            lvAuthors.FullRowSelect = true;
            lvAuthors.MultiSelect = false;
            lvAuthors.GridLines = true; 

            lvAuthors.Columns.Add("First");
            lvAuthors.Columns.Add("Last");

            ListViewItem item;

            // display all authors 

            List<AuthorViewModel> authors =
                _service.FindAllAuthors(); 

            foreach(AuthorViewModel au in authors)
            {
                item = new ListViewItem(au.FirstName);
                item.SubItems.Add(au.LastName);
                item.Tag = au.ID;  
                lvAuthors.Items.Add(item); 
            }
        }

        string GetConnection()
        {
            IConfiguration Configuration;

            var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional:
                    false, reloadOnChange: false);

            Configuration = builder.Build();

            string con = Configuration
                ["Configuration:pubsDBConnectionString"];

            return con;
        }

        private void lvAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // check for unselect 
            if (lvAuthors.SelectedItems.Count <= 0) return;

            ListViewItem item = lvAuthors.SelectedItems[0];

            //txtTempID.Text = (String)item.Tag; 
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lvAuthors.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Must Select and author to edit"); 
            }

            ListViewItem item = lvAuthors.SelectedItems[0];

            string id = (String)item.Tag;

            Author au = _service.FindAuthor(id); 
        }
    }
}
