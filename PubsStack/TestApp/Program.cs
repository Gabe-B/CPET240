using System;
using System.Data.SqlClient;
using System.Collections.Generic;

using Model;
using Repositories;
using PubsServiceBus;
using ViewModels;

namespace TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			string connection = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";

			authorDBRepo auRepo = new authorDBRepo(connection);

			ServiceBus service = new ServiceBus(auRepo);

			List<AuthorViewModel> authors = service.findAllAuthors();

			foreach(AuthorViewModel au in authors)
			{
				Console.WriteLine(
					String.Format("{0} {1} {2}", au.ID, au.FirstName, au.LastName)
					);
			}
		}
	}
}
