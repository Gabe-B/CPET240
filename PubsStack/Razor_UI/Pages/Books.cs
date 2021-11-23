using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Model;
using Repositories;

namespace Razor_UI.Pages
{
    public class BooksModel : PageModel
    {
		private PubsServiceBus.ServiceBus _service;

		[BindProperty]
		public Model.Author Author { get; set; }

		[BindProperty]
		public Model.Book Book { get; set; }

		[BindProperty]
		public IEnumerable<Model.Book> AllBooks { get; set; }

		public IEnumerable<ViewModels.BookViewModel> Books { get; set; }

		public BooksModel(PubsServiceBus.ServiceBus service)
		{
			_service = service;
		}

		public void OnGet(string auid)
		{
			Author = _service.FindAuthor(auid);
			Books = _service.findAllBooksByAuthor(Author);
			AllBooks = _service._bRepo.FindAll();
		}

		public IActionResult Delete(string bid)
		{
			Book = _service._bRepo.Find(bid);

			if (ModelState.IsValid)
			{
				_service._bRepo.Delete(Book);

				return RedirectToPage("Books");
			}

			return Page();
		}

		public IActionResult AddToAuthor(string bid, Author au)
		{
			BookRepoDB bdb = new BookRepoDB(GetConnection());

			Book = _service._bRepo.Find(bid);

			if (ModelState.IsValid)
			{
				bdb.Update(Book, au.au_id);

				return RedirectToPage("Books");
			}

			return Page();
		}

		static string GetConnection()
		{
			IConfiguration Configuration;

			var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

			Configuration = builder.Build();

			string con = Configuration["Configuration:pubsDBSConnectionString"];

			return con;
		}
	}
}
