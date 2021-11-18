using System;
using System.Collections.Generic;

using Model;
using System.Data.SqlClient;
using System.Data.Common;

namespace Repositories
{
	public static class DataReaderHelper
	{
		// https://blog.bitscry.com/2017/07/27/sqldatareader-null-handling/

		public static string SafeGetString(this DbDataReader reader, string colName)
		{
			int colIndex = reader.GetOrdinal(colName);

			if (!reader.IsDBNull(colIndex))
			{
				return reader.GetString(colIndex);
			}
			else
			{
				return null;
			}
		}

		public static Decimal? SafeGetDecimal(this DbDataReader reader, string colName)
		{
			int colIndex = reader.GetOrdinal(colName);

			if (!reader.IsDBNull(colIndex))
			{
				return reader.GetDecimal(colIndex);
			}
			else
			{
				return null;
			}
		}

		public static int? SafeGetInt(this DbDataReader reader, string colName)
		{
			int colIndex = reader.GetOrdinal(colName);

			if (!reader.IsDBNull(colIndex))
			{
				return reader.GetInt32(colIndex);
			}
			else
			{
				return null;
			}
		}
	}

	public interface IRepository<T>
	{
		IList<T> FindAll();
		T Find(string id);

		bool Add(T x);

		bool Update(T x);

		bool Delete(T x);
	}

	public interface IItemsForRepository<I, J> : IRepository<I>
	{
		IList<I> FindFor(J i);
		bool AddFor(I a, J b);
		bool DeleteFor(I a, J b);
	}

	public class AuthorRepoDB : IRepository<Author>
	{
		private string _connection;

		public AuthorRepoDB(string connection)
		{
			_connection = connection;
		}

		public IList<Author> FindAll()
		{
			//string connection = "Itegrated Security=true;Initial Catalog=pubs;Data Source=(local);";
			string sql = "SELECT * FROM authors";

			List<Author> authors = new List<Author>();

			using (SqlConnection conn = new SqlConnection(_connection))
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
								au_lname = reader["au_lname"].ToString(),
								au_phone = reader["phone"].ToString(),
								au_address = reader["address"].ToString(),
								au_city = reader["city"].ToString(),
								au_state = (reader["state"]).ToString(),
								au_zip = reader["zip"].ToString(),
								au_contract = Convert.ToInt32(reader["contract"])
							};

							authors.Add(au);
						}
					}
				}
			}

			return authors;
		}

		public bool Add(Author x)
		{
			string sql = "INSERT INTO authors (au_id, au_lname, au_fname, phone, address, city, state, zip, contract) VALUES (@au_id, @au_lname, @au_fname, @phone, @address, @city, @state, @zip, @contract)";

			using (SqlConnection conn = new SqlConnection(_connection))
			{

				conn.Open();

				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					//cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@au_id", x.au_id);
					cmd.Parameters.AddWithValue("@au_lname", x.au_lname);
					cmd.Parameters.AddWithValue("@au_fname", x.au_fname);
					cmd.Parameters.AddWithValue("@phone", x.au_phone);
					cmd.Parameters.AddWithValue("@address", x.au_address);
					cmd.Parameters.AddWithValue("@city", x.au_city);
					cmd.Parameters.AddWithValue("@state", x.au_state.Trim());
					cmd.Parameters.AddWithValue("@zip", x.au_zip);
					cmd.Parameters.AddWithValue("@contract", x.au_contract);

					try
					{
						cmd.ExecuteNonQuery();

						conn.Close();

						return true;
					}
					catch (SqlException ex)
					{
						Console.WriteLine(ex.Message);
						return false;
					}
				}
			}
		}

		public bool Delete(Author x)
		{
			string sql = "DELETE FROM authors WHERE au_id = @id";

			using (SqlConnection conn = new SqlConnection(_connection))
			{
				conn.Open();

				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@id", x.au_id);

					try
					{
						cmd.ExecuteNonQuery();

						conn.Close();

						return true;
					}
					catch (SqlException ex)
					{
						Console.WriteLine(ex.Message);
						return false;
					}
				}
			}
		}

		public Author Find(string id)
		{
			string sql = "SELECT * FROM authors WHERE au_id = @auid";

			Author author = default(Author);

			try
			{
				using (SqlConnection connection = new SqlConnection(_connection))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("@auid", id);


						using (SqlDataReader dataReader = command.ExecuteReader())
						{
							if (dataReader.Read()) // foward only and readonly
							{
								author = new Author()
								{
									au_id = dataReader["au_id"].ToString(),
									au_fname = dataReader["au_fname"].ToString(),
									au_lname = dataReader["au_lname"].ToString(),
									au_phone = dataReader["phone"].ToString(),
									au_address = dataReader["address"].ToString(),
									au_city = dataReader["city"].ToString(),
									au_contract = Convert.ToInt32(dataReader["contract"]),
									au_state = dataReader["state"].ToString(),
									au_zip = dataReader["zip"].ToString()
									// add other author fields 
								};
							}
						}// end use reader
					}// end use command
				}// end use connection 
			}
			catch (SqlException ex)
			{
				return default(Author);
			}

			return author;
		}

		public bool Update(Author x)
		{
			string sql = "UPDATE authors SET au_lname = @lname, au_fname = @fname, phone = @phone, address = @address, city = @city, state = @state, zip = @zip, contract = @contract WHERE au_id = @id";

			using (SqlConnection conn = new SqlConnection(_connection))
			{
				conn.Open();

				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@id", x.au_id);
					cmd.Parameters.AddWithValue("@lname", x.au_lname);
					cmd.Parameters.AddWithValue("@fname", x.au_fname);
					cmd.Parameters.AddWithValue("@phone", x.au_phone);
					cmd.Parameters.AddWithValue("@address", x.au_address);
					cmd.Parameters.AddWithValue("@city", x.au_city);
					cmd.Parameters.AddWithValue("@state", x.au_state);
					cmd.Parameters.AddWithValue("@zip", x.au_zip);
					cmd.Parameters.AddWithValue("@contract", x.au_contract);

					try
					{
						cmd.ExecuteNonQuery();

						conn.Close();

						return true;
					}
					catch (SqlException ex)
					{
						Console.WriteLine(ex.Message);
						return false;
					}

				}
			}
		}
	}
}
