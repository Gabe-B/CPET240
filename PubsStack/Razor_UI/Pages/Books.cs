using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_UI.Pages
{
    public class BooksModel : PageModel
    {
		private readonly PubsServiceBus.ServiceBus _service;

		[BindProperty]
		public Model.Author Author { get; set; }

		[BindProperty]
		public Model.Book Book { get; set; }

		public IEnumerable<ViewModels.BookViewModel> Books { get; set; }

		public BooksModel(PubsServiceBus.ServiceBus service)
		{
			_service = service;
		}

		public void OnGet(string auid)
		{
			Author = _service.FindAuthor(auid);
			Books = _service.findAllBooksByAuthor(Author);
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
    }
}
