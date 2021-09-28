using System;

namespace ViewModels
{
	public class AuthorViewModel
	{
		public string ID { get; }

		public string FirstName { get; }

		public string LastName { get; }

		public string Name
		{
			get
			{
				return FirstName + " " + LastName;
			}
		}

		public AuthorViewModel(string id, string fname, string lname)
		{
			ID = id;
			FirstName = fname;
			LastName = lname;
		}
	}
}
