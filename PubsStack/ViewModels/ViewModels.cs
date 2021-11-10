using System;
using Model;

namespace ViewModels
{
	public class AuthorViewModel
	{
		public string ID { get; }
		public string FirstName { get; }
		public string LastName { get; }
		public string Phone { get; }
		public string Address { get; }
		public string City { get; }
		public string State { get; }
		public string Zip { get; }
		public int Contract { get; }

		public string Name
		{
			get
			{
				return FirstName + " " + LastName;
			}
		}

		public AuthorViewModel(string id, string fname, string lname, string phone, string address, string city, string state, string zip, int contract)
		{
			ID = id;
			FirstName = fname;
			LastName = lname;
			Phone = phone;
			Address = address;
			City = city;
			State = state;
			Zip = zip;
			Contract = contract;
		}
	}

	public class BookViewModel
	{
		public string Title_ID { get; }
		public string Title { get; }
		public string Type { get; }
		public Publisher Pub { get; }
		//public string PubId { get; }
		public decimal? Price { get; }
		public int? YTD_Sales { get; }
		public DateTime PubDate { get; }

		public BookViewModel(string tid, string t, string type, Publisher pub, decimal? price, int? ytd, DateTime pdate)
		{
			Title_ID = tid;
			Title = t;
			Type = type;
			Pub = pub;
			//PubId = pubid;
			Price = price;
			YTD_Sales = ytd;
			PubDate = pdate;
		}
	}
}
