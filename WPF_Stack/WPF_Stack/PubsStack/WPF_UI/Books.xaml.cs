using PubsServiceBus;
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
using ViewModel;
using Repositories;
using Model;
using Microsoft.Extensions.Configuration;

namespace WPF_UI
{
	/// <summary>
	/// Interaction logic for Books.xaml
	/// </summary>
	public partial class Books : Window
	{
		PubsService _service = null;
		List<Book> books;

		public Books(PubsService service)
		{
			InitializeComponent();

			_service = service;

			books = (List<Book>)_service.FindAllBooks();

			BooksGrid.ItemsSource = books;
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
