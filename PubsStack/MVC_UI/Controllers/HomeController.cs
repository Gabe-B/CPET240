using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Model;
using MVC_UI.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UI.Controllers
{
	/// <summary>
	/// Class for controller
	/// </summary>
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly PubsServiceBus.ServiceBus _service;

		/// <summary>
		/// List of book view models
		/// </summary>
		public List<ViewModels.BookViewModel> books = new List<ViewModels.BookViewModel>();

		/// <summary>
		/// Specific book
		/// </summary>
		[BindProperty]
		public Model.Book Book { get; set; }

		/// <summary>
		/// Constructor for class
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="service"></param>
		public HomeController(ILogger<HomeController> logger, PubsServiceBus.ServiceBus service)
		{
			_logger = logger;
			_service = service;
		}

		/// <summary>
		/// Index Page
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
			List<ViewModels.AuthorViewModel> authors = _service.findAllAuthors();

			return View(authors);
		}

		/// <summary>
		/// HttpGet for create author page
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Create()
		{
			Author au = new Author();

			return View(au);
		}

		/// <summary>
		/// HttpPost for create author page
		/// </summary>
		/// <param name="author"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Create(Author author)
		{
			_service._auRepo.Create(author);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// HttpGet for edit author page
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Edit(string id)
		{
			Author au = _service.FindAuthor(id);

			return View(au);
		}

		/// <summary>
		/// HttpPost for edit author page
		/// </summary>
		/// <param name="au"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Edit(Author au)
		{
			_service._auRepo.Update(au);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Deletes author from repo
		/// </summary>
		/// <param name="auid"></param>
		/// <param name="confirm"></param>
		/// <returns></returns>
		public ActionResult DeleteAuthor(string auid, bool confirm)
		{
			if(confirm)
			{
				authorDBRepo auRepo = new authorDBRepo(GetConnection());

				Author author = _service.FindAuthor(auid);

				auRepo.Delete(author);

				return RedirectToAction("Index");
			}

			return RedirectToAction("Index");
		}

		/// <summary>
		/// HttpGet for books page
		/// </summary>
		/// <param name="auid"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Books(string auid)
		{
			BookAndAuthorModel ba = new BookAndAuthorModel(_service);

			ba.au_id = auid;

			Author author = _service.FindAuthor(ba.au_id);

			books = _service.findAllBooksByAuthor(author);

			ba.books = books;

			return View(ba);
		}

		/// <summary>
		/// Deletes book from author in repo
		/// </summary>
		/// <param name="bid"></param>
		/// <param name="au"></param>
		/// <returns></returns>
		public ActionResult DeleteBookFromAuthor(string bid, string au)
		{
			BookRepoDB bdb = new BookRepoDB(GetConnection());

			Author author = _service.FindAuthor(au);

			Book = _service._bRepo.Find(bid);

			bdb.Delete(Book, author);

			return RedirectToAction("Books", new { auid = author.au_id });
		}

		/// <summary>
		/// Adds book to author in repo
		/// </summary>
		/// <param name="bid"></param>
		/// <param name="auid"></param>
		/// <returns></returns>
		public ActionResult AddBookToAuthor(string bid, string auid)
		{
			BookRepoDB bdb = new BookRepoDB(GetConnection());
			Book = _service._bRepo.Find(bid);

			bdb.Update(Book, auid);

			return RedirectToAction("Books", new { auid = auid });
		}

		/// <summary>
		/// privacy
		/// </summary>
		/// <returns></returns>
		public IActionResult Privacy()
		{
			return View();
		}

		/// <summary>
		/// Error handler
		/// </summary>
		/// <returns></returns>
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
