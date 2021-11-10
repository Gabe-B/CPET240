using System;
using System.Collections.Generic;
using Model;
using System.Data.SqlClient;
using System.Data.Common;

namespace Repositories
{
    public static class DataReaderHelper
    {
        public static string SafeGetString(this DbDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);

            if(!reader.IsDBNull(colIndex))
            {
                return reader.GetString(colIndex);
            }
            else
            {
                return null;
            }
        }

        public static Decimal ? SafeGetDecimal(this DbDataReader reader, string colName)
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

        bool Create(T x);

        bool Update(T x);

        bool Delete(T x);
    }

    public interface BookRepo : IRepository<Book>
    {
        List<Book> GetBooksForAuthor(string au_id);
    }

    public interface IItemsByRepo<A, B> : IRepository<A>
    {
        //Books[] items for (author x)
        IList<A> ItemsFor(B x);
    }

    public class authorDBRepo : IRepository<Author>
    {
        private string _connectionString;

        public authorDBRepo(string connection)
        {
            _connectionString = connection;
        }

        public List<Publisher> FindAllPubs()
		{
            string sql = "SELECT * FROM publishers";

            List<Publisher> pubs = new List<Publisher>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Publisher p = new Publisher()
                            {
                                pub_id = reader["pub_id"].ToString(),
                                pub_name = reader["pub_name"].ToString()
                            };

                            pubs.Add(p);
                        }
                    }
                }
            }

            return pubs;
        }

        public bool Create(Author au)
        {
            string sql = "INSERT INTO authors (au_id, au_lname, au_fname, phone, address, city, state, zip, contract) VALUES (@au_id, @au_lname, @au_fname, @phone, @address, @city, @state, @zip, @contract)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@au_id", au.au_id);
                    cmd.Parameters.AddWithValue("@au_lname", au.au_lname);
                    cmd.Parameters.AddWithValue("@au_fname", au.au_fname);
                    cmd.Parameters.AddWithValue("@phone", au.au_phone);
                    cmd.Parameters.AddWithValue("@address", au.au_address);
                    cmd.Parameters.AddWithValue("@city", au.au_city);
                    cmd.Parameters.AddWithValue("@state", au.au_state.Trim());
                    cmd.Parameters.AddWithValue("@zip", au.au_zip);
                    cmd.Parameters.AddWithValue("@contract", au.au_contract);

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

            using (SqlConnection conn = new SqlConnection(_connectionString))
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
            string sql = "SELECT * FROM authors WHERE au_id = @id";

            Author author = default(Author);

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        //cmd.Parameters.Add(new SqlParameter("@id", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                author = new Author()
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
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return default(Author);
            }
            return author;
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

        public bool Update(Author x)
        {
            string sql = "UPDATE authors SET au_lname = @lname, au_fname = @fname, phone = @phone, address = @address, city = @city, state = @state, zip = @zip, contract = @contract WHERE au_id = @id";

            using (SqlConnection conn = new SqlConnection(_connectionString))
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
