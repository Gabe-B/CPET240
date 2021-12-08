using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_UI.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly PubsServiceBus.ServiceBus _service;

		public IEnumerable<ViewModels.AuthorViewModel> Authors { get; set; }

		public IndexModel(ILogger<IndexModel> logger, PubsServiceBus.ServiceBus service)
		{
			_logger = logger;
			_service = service;
		}

		public void OnGet()
		{
			Authors = _service.findAllAuthors();
		}
	}
}
