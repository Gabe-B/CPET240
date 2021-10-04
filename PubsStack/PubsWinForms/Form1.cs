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

using Model;
using Repositories;
using ViewModels;
using PubsServiceBus;

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

            _service = new ServiceBus(au_repo);

            lvAuthors.View = View.Details;
            lvAuthors.FullRowSelect = true;
            lvAuthors.MultiSelect = false;
            lvAuthors.GridLines = true;

            lvAuthors.Columns.Add("First");
            lvAuthors.Columns.Add("Last");

            ListViewItem item;

            List<AuthorViewModel> authors = _service.findAllAuthors();

            foreach(AuthorViewModel au in authors)
            {
                item = new ListViewItem(au.FirstName);
                item.SubItems.Add(au.LastName);
                item.Tag = au.ID;
                lvAuthors.Items.Add(item);
            }
            lvAuthors.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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
            //check for unselected
            if(lvAuthors.SelectedItems.Count <= 0)
            {
                return;
            }

            ListViewItem item = lvAuthors.SelectedItems[0];

            txtTempID.Text = (string)item.Tag;
            txtFName.Text = (string)lvAuthors.SelectedItems[0].SubItems[0].Text;
            txtLName.Text = (string)lvAuthors.SelectedItems[0].SubItems[1].Text;
        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }
    }
}
