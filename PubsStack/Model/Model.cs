using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Model
{
	public class Author
	{
		[Display(Name = "ID")]
		[Required(ErrorMessage = "Required: Must put in first name")]
		[RegularExpression(@"^[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]$", ErrorMessage = "XXX-XX-XXXX")]
		public string au_id { get; set; }

		[Display(Name = "First")]
		[Required(ErrorMessage = "Required: Must put in first name")]
		public string au_fname { get; set; }

		[Display(Name = "Last")]
		[Required(ErrorMessage = "Required: Must put in last name")]
		public string au_lname { get; set; }

		//Other Fields

		[Display(Name = "Phone #")]
		[Required(ErrorMessage = "Must input phone number")]
		[RegularExpression(@"^[0-9][0-9][0-9] [0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$", ErrorMessage = "XXX XXX-XXXX")]
		public string au_phone { get; set; }

		[Display(Name = "Street")]
		[Required(ErrorMessage = "Required: Must put in street name")]
		public string au_address { get; set; }

		[Display(Name = "City")]
		[Required(ErrorMessage = "Required: Must put in city name")]
		public string au_city { get; set; }

		[Display(Name = "State")]
		[Required(ErrorMessage = "Required: Must put in state abbreviation")]
		[RegularExpression(@"^[A-Z][A-Z]$", ErrorMessage = "XX (Examples: GA, NH, OK)")]
		public string au_state { get; set; }

		[Display(Name = "Zip Code")]
		[Required(ErrorMessage = "Required: Must put in zip code")]
		[RegularExpression(@"^[0-9][0-9][0-9][0-9][0-9]$", ErrorMessage = "XXXXX")]
		public string au_zip { get; set; }

		[Display(Name = "Contract")]
		[Required(ErrorMessage = "Required: Must put in contract ('0' for no, '1' for yes)")]
		[RegularExpression(@"^[0-1]$", ErrorMessage = "Contract not a proper value")]
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
		public decimal? price { get; set; }
		public int? ytd_sales { get; set; }
		public DateTime pubdate { get; set; }
    }
}
