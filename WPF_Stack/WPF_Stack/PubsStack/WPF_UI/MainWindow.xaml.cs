using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Model;
using ViewModel;
using Repositories;
using PubsServiceBus;
using Microsoft.Extensions.Configuration;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PubsService _service = null;

        List<AuthorViewModel> authors;
        List<BookViewModel> books;

        public MainWindow()
        {
            InitializeComponent();

            AuthorsGrid.SelectionMode = DataGridSelectionMode.Single; 

            string database = GetConnection(); 
            AuthorRepoDB auRepo = new AuthorRepoDB(database);
            BookRepoDB bRepo = new BookRepoDB(database);

            _service = new PubsService(auRepo, bRepo);

            authors = _service.FindAllAuthors();

            AuthorsGrid.ItemsSource = authors;
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

        private void txtTest_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void AuthorsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AuthorsGrid.SelectedItems.Count <= 0) return;

            AuthorViewModel x = AuthorsGrid.SelectedItem as AuthorViewModel;

            txtID.Text = x.ID;
        }

        private void NewAuthor_Click(object sender, RoutedEventArgs e)
        {
            if(AuthorsGrid.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select an author");
                return; 
            }

            AuthorViewModel x = AuthorsGrid.SelectedItem as AuthorViewModel;

            Author a = _service.FindAuthor(x.ID); 

            AuthorWindow win = new AuthorWindow(a);

            bool ? result = win.ShowDialog(); 

            if(result.HasValue)
            {
                if(result.Value == true)
                {
                    // accept changes to author 

                    MessageBox.Show(a.au_fname); 
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
		{
            if (AuthorsGrid.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select an author");
                return;
            }

            AuthorViewModel x = AuthorsGrid.SelectedItem as AuthorViewModel;

            Author a = _service.FindAuthor(x.ID);

            AuthorWindow win = new AuthorWindow(a);

            bool? result = win.ShowDialog();

            if (result.HasValue)
            {
                if (result.Value == true)
                {
                    // accept changes to author 

                    a.au_address = win.TextBoxAddress.Text;
                    a.au_city = win.TextBoxCity.Text;
                    a.au_contract = Convert.ToInt32(win.TextBoxContract.Text);
                    a.au_fname = win.TextBoxUserName.Text;
                    a.au_lname = win.TextBoxLastName.Text;
                    a.au_phone = win.TextBoxPhoneNum.Text;
                    a.au_state = win.TextBoxState.Text;
                    a.au_zip = win.TextBoxZIP.Text;

                    _service._auRepo.Update(a);

                    MessageBox.Show("Changes successfully made!");
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
		{
            if (AuthorsGrid.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select an author");
                return;
            }

            //AuthorViewModel x = AuthorsGrid.SelectedItem as AuthorViewModel;

            Author a = _service.FindAuthor(txtID.Text.ToString());

            MessageBoxResult results = MessageBox.Show("Are you sure you want to delete this author?", "DELETE", MessageBoxButton.YesNo);

            if(results == MessageBoxResult.Yes)
			{
                _service._auRepo.Delete(a);
			}
            else
			{
                return;
			}
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            Books b = new Books();

            b.ShowDialog();
		}
    }
}
