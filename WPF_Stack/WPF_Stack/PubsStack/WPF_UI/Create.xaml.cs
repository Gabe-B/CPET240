using Microsoft.Extensions.Configuration;
using PubsServiceBus;
using Repositories;
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

namespace WPF_UI
{
	/// <summary>
	/// Interaction logic for Create.xaml
	/// </summary>
	/// 

	public partial class Create : Window
	{
		PubsService _service = null;

		List<string> states = new List<string>();

		public Create(PubsService service)
		{
			InitializeComponent();

            _service = service;

            states.Add("AL");
            states.Add("AK");
            states.Add("AZ");
            states.Add("AR");
            states.Add("CA");
            states.Add("CO");
            states.Add("CT");
            states.Add("DE");
            states.Add("FL");
            states.Add("GA");
            states.Add("HI");
            states.Add("ID");
            states.Add("IL");
            states.Add("IN");
            states.Add("IA");
            states.Add("KS");
            states.Add("KY");
            states.Add("LA");
            states.Add("ME");
            states.Add("MD");
            states.Add("MA");
            states.Add("MI");
            states.Add("MN");
            states.Add("MS");
            states.Add("MO");
            states.Add("MT");
            states.Add("NE");
            states.Add("NV");
            states.Add("NH");
            states.Add("NJ");
            states.Add("NM");
            states.Add("NY");
            states.Add("NC");
            states.Add("ND");
            states.Add("OH");
            states.Add("OK");
            states.Add("OR");
            states.Add("PA");
            states.Add("RI");
            states.Add("SC");
            states.Add("SD");
            states.Add("TN");
            states.Add("TX");
            states.Add("UT");
            states.Add("VT");
            states.Add("VA");
            states.Add("WA");
            states.Add("WV");
            states.Add("WI");
            states.Add("WY");

            StateComboBoxC.ItemsSource = states;
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

		private void StateComboBoxC_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void btnOkC_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		private void btnCancelC_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
		}
	}
}
