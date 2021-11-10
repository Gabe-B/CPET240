using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

using Model;
using Repositories;
using PubsServiceBus;
using ViewModels;

namespace TestApp
{
	class Program
	{
		static string GetConnection()
        {
			IConfiguration Configuration;

			var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

			Configuration = builder.Build();

			string con = Configuration["Configuration:pubsDBSConnectionString"];

			return con;
        }

		static void Main(string[] args)
		{
			string connection = GetConnection();

			BookRepoDB BookRepo = new BookRepoDB(connection);

			List<Book> books = (List<Book>)BookRepo.FindAll();

			authorDBRepo auRepo = new authorDBRepo(connection);

			ServiceBus service = new ServiceBus(auRepo);

			List<AuthorViewModel> authors = service.findAllAuthors();

			/*foreach(AuthorViewModel au in authors)
			{
				Console.WriteLine(
					String.Format("{0} {1} {2}", au.ID, au.FirstName, au.LastName)
					);
			}*/

			foreach(Book b in books)
            {
				Console.WriteLine(
					String.Format("{0} {1}", b.title_id, b.title)
					);
            }

			Console.WriteLine(" ");

			/*Author sAuthor = service.FindAuthor("172-32-1176");

			Console.WriteLine(
					String.Format("{0} {1} {2}", sAuthor.au_id, sAuthor.au_fname, sAuthor.au_lname)
					);*/
		}
	}
}
