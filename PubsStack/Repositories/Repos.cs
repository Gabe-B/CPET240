using System;
using System.Collections.Generic;
using Model;
using System.Data.SqlClient;

namespace Repositories
{
	public interface IRepository<T>
	{
		IList<T> FindAll();

		T Find(string id);

		bool Create(T x);

		bool Update(T x);

		bool Delete(T x);
	}


	public class authorDBRepo : IRepository<Author>
	{
		private string _connectionString;

		public authorDBRepo(string connection)
		{
			_connectionString = connection;
		}

		public bool Create(Author x)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Author x)
		{
			throw new NotImplementedException();
		}

		public Author Find(string id)
		{
			throw new NotImplementedException();
		}

		public IList<Author> FindAll()
		{
			//string connection = "Itegrated Security=true;Initial Catalog=pubs;Data Source=(local);";
			string sql = "SELECT * FROM authors";

			List<Author> authors = new List<Author>();

			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Author au = new Author()
							{
								au_id = reader["au_id"].ToString(),
								au_fname = reader["au_fname"].ToString(),
								au_lname = reader["au_lname"].ToString()
							};

							authors.Add(au);
						}
					}
				}
			}

			return authors;
		}

		public bool Update(Author x)
		{
			throw new NotImplementedException();
		}
	}
}
