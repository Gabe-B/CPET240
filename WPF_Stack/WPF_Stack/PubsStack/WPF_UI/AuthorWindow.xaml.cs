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
using System.Windows.Shapes;
using Microsoft.Extensions.Configuration;
using Model;
using PubsServiceBus;
using Repositories;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AuthorWindow : Window
    {
        Author au;
        PubsService _service = null;
        List<Book> books;

        public AuthorWindow(Author a)
        {
            InitializeComponent();

            string database = GetConnection();
            AuthorRepoDB auRepo = new AuthorRepoDB(database);
            BookRepoDB bRepo = new BookRepoDB(database);

            _service = new PubsService(auRepo, bRepo);

            books = (List<Book>)_service._bRepo.FindFor(a);

            au = a;

			DataContext = au;
            AUBooksGrid.ItemsSource = books;
		}

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true; 
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false; 
        }

        public void btnRemove_Click(object sender, RoutedEventArgs e)
		{
            if(AUBooksGrid.SelectedIndex < 0)
			{
                MessageBox.Show("Please select a book");
                return;
			}

            Book b = AUBooksGrid.SelectedItem as Book;

            AUBooksGrid.ItemsSource = null;

            books.Remove(b);

            AUBooksGrid.ItemsSource = books;

            _service._bRepo.DeleteFor(b, au);
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
    }
}
