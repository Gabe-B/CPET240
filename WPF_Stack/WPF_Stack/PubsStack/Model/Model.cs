using System;

namespace Model
{
    public class Author
    {
		public string au_id { get; set; }
		public string au_fname { get; set; }
		public string au_lname { get; set; }

		//Other Fields
		public string au_phone { get; set; }
		public string au_address { get; set; }
		public string au_city { get; set; }
		public string au_state { get; set; }
		public string au_zip { get; set; }
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
