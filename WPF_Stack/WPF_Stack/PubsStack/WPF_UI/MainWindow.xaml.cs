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

using System.Text.RegularExpressions;

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

        private void Edit_Click(object sender, RoutedEventArgs e)
		{
            if (AuthorsGrid.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select an author");
                return;
            }

            AuthorViewModel x = AuthorsGrid.SelectedItem as AuthorViewModel;

            Author a = _service.FindAuthor(x.ID);

            AuthorWindow win = new AuthorWindow(a, _service);

            win.StateComboBox.Text = a.au_state;

            bool? result = win.ShowDialog();

            if (result.HasValue)
            {
                if (result.Value == true)
                {
                    // accept changes to author

                    Regex phoneRX = new Regex(@"\d{3}? *\d{3}-? *-?\d{4}");
                    Regex zipRX = new Regex(@"(^([0]|[0-9]{5})$)");

                    Match phone = phoneRX.Match(win.TextBoxPhoneNum.Text);
                    Match zip = phoneRX.Match(win.TextBoxZIP.Text);

                    a.au_address = win.TextBoxAddress.Text;
                    a.au_city = win.TextBoxCity.Text;
                    a.au_contract = Convert.ToInt32(win.TextBoxContract.Text);
                    a.au_fname = win.TextBoxUserName.Text;
                    a.au_lname = win.TextBoxLastName.Text;

                    if (phone.Success)
                    {
                        a.au_phone = win.TextBoxPhoneNum.Text;
                    }
                    else
                    {
                        MessageBox.Show("Phone number was input incorrectly. Must be number in the format of XXX XXX-XXXX");
                        return;
                    }

                    a.au_state = win.StateComboBox.Text;
                    a.au_zip = win.TextBoxZIP.Text;

                    _service.UpdateAuthor(a);

                    AuthorsGrid.ItemsSource = null;

                    authors = _service.FindAllAuthors();

                    AuthorsGrid.ItemsSource = authors;

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
                if (_service.DeleteAuthor(a))
                {
                    MessageBox.Show("Author successfully deleted!", "SUCCESS", MessageBoxButton.OK);

                    AuthorsGrid.ItemsSource = null;

                    authors = _service.FindAllAuthors();

                    AuthorsGrid.ItemsSource = authors;
                }
                else
				{
                    MessageBox.Show("Something went wrong! Check if the author still has books.", "ERROR", MessageBoxButton.OK);
                }
			}
            else
			{
                return;
			}
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            Books b = new Books(_service);

            b.ShowDialog();
		}

		private void CreateButton_Click(object sender, RoutedEventArgs e)
		{
            Create win = new Create(_service);

            Author newAuth = new Author();

            bool? result = win.ShowDialog();

            if (result.HasValue)
            {
                if (result.Value == true)
                {
                    // accept changes to author 

                    Regex phoneRX = new Regex(@"\(?\d{3}\)? ? *\d{3}-? *-?\d{4}");
                    Regex zipRX = new Regex(@"^\d{ 5 }");

                    Match phone = phoneRX.Match(win.TextBoxPhoneNumC.Text);
                    Match zip = phoneRX.Match(win.TextBoxZIPC.Text);

                    newAuth.au_address = win.TextBoxAddressC.Text;
                    newAuth.au_city = win.TextBoxCityC.Text;
                    newAuth.au_contract = Convert.ToInt32(win.TextBoxContractC.Text);
                    newAuth.au_fname = win.TextBoxUserNameC.Text;
                    newAuth.au_lname = win.TextBoxLastNameC.Text;
                    newAuth.au_state = win.StateComboBoxC.Text;

                    if (phone.Success)
					{
                        newAuth.au_phone = win.TextBoxPhoneNumC.Text;
                    }
                    else
					{
                        MessageBox.Show("Phone number was input incorrectly. Must be number in the format of XXX XXX-XXXX");
                        return;
					}

                    newAuth.au_zip = win.TextBoxZIPC.Text;
                    newAuth.au_id = win.TextBoxIDC.Text;

                    if(_service.CreateNewAuthor(newAuth))
					{
                        AuthorsGrid.ItemsSource = null;

                        authors = _service.FindAllAuthors();

                        AuthorsGrid.ItemsSource = authors;

                        MessageBox.Show("Changes successfully made!");
                    }
                    else
					{
                        MessageBox.Show("Something went wrong. Check that all information was input properly.");
					}
                }
            }
        }
	}
}
