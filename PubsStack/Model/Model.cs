using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Model
{
	public class Author
	{
		[Display(Name = "ID")]
		public string au_id { get; set; }

		[Display(Name = "First")]
		[Required(ErrorMessage = "Required: Must put in first name")]
		public string au_fname { get; set; }

		[Display(Name = "Last")]
		public string au_lname { get; set; }

		//Other Fields

		[Display(Name = "Phone #")]
		[Required(ErrorMessage = "Must input phone number")]
		[RegularExpression(@"^[0-9][0-9][0-9] [0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$", ErrorMessage = "XXX XXX-XXXX")]
		public string au_phone { get; set; }

		[Display(Name = "Street")]
		public string au_address { get; set; }

		[Display(Name = "City")]
		public string au_city { get; set; }

		[Display(Name = "State")]
		public string au_state { get; set; }

		[Display(Name = "Zip Code")]
		public string au_zip { get; set; }

		[Display(Name = "Contract")]
		public int au_contract { get; set; }
	}

	public class Publisher
    {
		public string pub_id { get; set; }
		public string pub_name { get; set; }
    }

	public class Book
    {
		public string title_id { get; set; }
		public string title { get; set; }
		public string type { get; set; }
		public Publisher publisher { get; set; }
		//public string pub_id { get; set; }
		public decimal? price { get; set; }
		public int? ytd_sales { get; set; }
		public DateTime pubdate { get; set; }
    }
}
