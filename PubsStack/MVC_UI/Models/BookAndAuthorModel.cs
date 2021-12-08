using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UI.Models
{
	/// <summary>
	/// view model class
	/// </summary>
	public class BookAndAuthorModel
	{
		/// <summary>
		/// repo services
		/// </summary>
		public PubsServiceBus.ServiceBus _service;

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="service"></param>
		public BookAndAuthorModel(PubsServiceBus.ServiceBus service)
		{
			_service = service;
		}

		/// <summary>
		/// lits of book view models
		/// </summary>
		public List<ViewModels.BookViewModel> books { get; set; }

		/// <summary>
		/// author id
		/// </summary>
		public string au_id { get; set; }
	}
}
