using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly PubsServiceBus.ServiceBus _service;

		public HomeController(ILogger<HomeController> logger, PubsServiceBus.ServiceBus service)
		{
			_logger = logger;
			_service = service;
		}

		public IActionResult Index()
		{
			List<ViewModels.AuthorViewModel> authors = _service.findAllAuthors();

			return View(authors);
		}

		[HttpGet]
		public IActionResult Edit(string id)
		{
			Model.Author au = _service.FindAuthor(id);

			return View();
		}

		public IActionResult Edit(Model.Author au)
		{
			_service._auRepo.Update(au);

			return RedirectToAction("Index");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
