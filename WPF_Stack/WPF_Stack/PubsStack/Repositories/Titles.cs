using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using System.Data.SqlClient; 

namespace Repositories
{
    public class BookRepoDB : IItemsForRepository<Book, Author>
    {
        private string _connection;

        public BookRepoDB(string connection)
        {
            _connection = connection;
        }

        public bool Add(Book x)
        {
            List<Book> books = new List<Book>();

            string sql = "INSERT INTO titles (title_id, title, [type], pub_id, price, royalty, ytd_sales, notes, pubdate)" +
                " VALUES (@t_id, @title, @type, @pubid, @price, @royalty, @ytd, @notes, @pdate)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@t_id", x.title_id);
                    cmd.Parameters.AddWithValue("@title", x.title);
                    cmd.Parameters.AddWithValue("@type", x.type);
                    cmd.Parameters.AddWithValue("@pubid", x.publisher.pub_id);
                    cmd.Parameters.AddWithValue("@price", x.price.HasValue ? x.price.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@royalty", DBNull.Value);
                    cmd.Parameters.AddWithValue("@ytd", x.ytd_sales);
                    cmd.Parameters.AddWithValue("@notes", DBNull.Value);
                    cmd.Parameters.AddWithValue("@pdate", x.pubdate);

                    try
                    {
                        cmd.ExecuteNonQuery();

                        connection.Close();

                        return true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool AddForAuthor(Book b, string aid)
        {
            // add to title author table 
                string sql = "INSERT INTO titleauthor (au_id, title_id) VALUES (@auid, @tid)";

                using (SqlConnection conn = new SqlConnection(_connection))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("auid", aid);
                        cmd.Parameters.AddWithValue("tid", b.title_id);

                        try
                        {
                            cmd.ExecuteNonQuery();

                            conn.Close();

                            return true;
                        }
                        catch (SqlException ex)
                        {
                            return false;
                        }
                    }
                }
        }

		public bool AddFor(Book a, Author b)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Book x)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFor(Book a, Author b)
        {
            // remove from title author table 

            string sql = "DELETE FROM titleauthor WHERE title_id = @tid AND au_id = @auid";

            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tid", a.title_id);
                    cmd.Parameters.AddWithValue("@auid", b.au_id);

                    try
                    {
                        cmd.ExecuteNonQuery();

                        conn.Close();

                        return true;
                    }
                    catch (SqlException ex)
                    {
                        return false;
                    }
                }
            }
        }

        public Book Find(string id)
        {
            string sql = "SELECT * FROM titles WHERE title_id = @id";

            Book book = default(Book);

            try
            {
                using (SqlConnection conn = new SqlConnection(_connection))
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
                                Publisher p = new Publisher()
                                {
                                    pub_id = reader["pub_id"].ToString(),
                                    pub_name = reader["pub_name"].ToString()
                                };

                                book = new Book()
                                {
                                    title_id = reader["title_id"].ToString(),
                                    title = reader["title"].ToString(),
                                    type = reader["type"].ToString(),
                                    publisher = p,
                                    price = reader.SafeGetDecimal("price"),
                                    ytd_sales = reader.SafeGetInt("ytd_sales"),
                                    pubdate = (DateTime)reader["pubdate"]
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return default(Book);
            }
            return book;
        }

        public IList<Book> FindAll()
        {
            string sql = "SELECT T.title_id, title, [type], T.pub_id, pub_name, ytd_sales, price, pubdate FROM titles T " +
                "JOIN publishers P " +
                "ON P.pub_id = T.pub_id ";

            List<Book> books = new List<Book>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connection))
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

                                Book book = new Book()
                                {
                                    title_id = reader["title_id"].ToString(),
                                    title = reader["title"].ToString(),
                                    type = reader["type"].ToString(),
                                    //pub_id = reader["pub_id"].ToString(),
                                    publisher = p,
                                    price = reader.SafeGetDecimal("price"),
                                    ytd_sales = reader.SafeGetInt("ytd_sales"),
                                    pubdate = (DateTime)reader["pubdate"]
                                };

                                books.Add(book);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                return default(List<Book>);
            }

            return books;
        }

        public IList<Book> FindFor(Author i)
        {
            List<Book> books = new List<Book>();

            string sql = "SELECT * FROM titles";

            sql = "SELECT T.title_id, title, [type], T.pub_id, pub_name, ytd_sales, price, pubdate FROM titles T " +
                "JOIN publishers P " +
                "ON P.pub_id = T.pub_id " +
                "JOIN titleauthor TA " +
                "ON TA.title_id = T.title_id " +
                "WHERE TA.au_id = @au_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connection))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("au_id", i.au_id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Publisher p = new Publisher()
                                {
                                    pub_id = reader["pub_id"].ToString(),
                                    pub_name = reader["pub_name"].ToString()
                                };

                                Book book = new Book()
                                {
                                    title_id = reader["title_id"].ToString(),
                                    title = reader["title"].ToString(),
                                    type = reader["type"].ToString(),
                                    //pub_id = reader["pub_id"].ToString(),
                                    publisher = p,
                                    price = reader.SafeGetDecimal("price"),
                                    ytd_sales = reader.SafeGetInt("ytd_sales"),
                                    pubdate = (DateTime)reader["pubdate"]
                                };

                                books.Add(book);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return default(List<Book>);
            }

            return books;
        }

        public bool Update(Book x)
        {
            throw new NotImplementedException();
        }
    }
}
