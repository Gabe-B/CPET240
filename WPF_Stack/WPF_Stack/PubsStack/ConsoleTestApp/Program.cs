using System;

using Microsoft.Extensions.Configuration;
using System.Collections.Generic; 

using PubsServiceBus; 
using Repositories;
using ViewModel; 
using Model;

namespace ConsoleTestApp
{
    public static class helper
    {
        public static int ToInt(this string input)
        {
            return Convert.ToInt32(input);
        }
    }

    class Program
    {

        static string GetConnection()
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

        static void test()
        {
            string x = "20";
            int n = x.ToInt();

            string y = $"Hello {x}"; 

            Console.WriteLine(y); 
            
        }

        static void Main(string[] args)
        {
            string connectionString = GetConnection();

            BookRepoDB bookRepo = new BookRepoDB(connectionString);

            List<Book> books = (List<Book>)bookRepo.FindFor(new Author() { au_id = "213-46-8915" });  

            Book bk = new Book()
            {
                title = "STILL",
                title_id = "BU1333",
                type = "business",
                //price = 80.40m, // deciMal
                //pub_id = "1389",
                pubdate = DateTime.Now


            };

           // bookRepo.Add(bk); 


            foreach(Book book in books)
            {
                Console.WriteLine(book.title);

                decimal price = book.price.GetValueOrDefault();

                price = book.price.HasValue ? book.price.Value : default(decimal); 
            }


            AuthorRepoDB AuthorRepo = new AuthorRepoDB(connectionString);

            //PubsService service = new PubsService(AuthorRepo);

            //List<AuthorViewModel> authors = service.FindAllAuthors();  

            /*foreach(AuthorViewModel au in authors)
            {
                Console.WriteLine(String.Format(
                    "{0}: {1} {2}", 
                    au.ID, au.FirstName, au.LastName)); 
            }*/

            Console.WriteLine(""); // newline 

            //Author author = service.FindAuthor("172-32-1176");

            //Console.WriteLine(author.au_fname); 
        }
    }
}
