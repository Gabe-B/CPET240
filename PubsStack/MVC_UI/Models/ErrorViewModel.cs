using System;

namespace MVC_UI.Models
{
	/// <summary>
	/// error view model class
	/// </summary>
	public class ErrorViewModel
	{
		/// <summary>
		/// get and set for id
		/// </summary>
		public string RequestId { get; set; }

		/// <summary>
		/// returns id
		/// </summary>
		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}
