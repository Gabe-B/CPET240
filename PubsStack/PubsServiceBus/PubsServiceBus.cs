using System;
using Repositories;
using Model;
using System.Collections.Generic;
using ViewModels;

namespace PubsServiceBus
{
	public class ServiceBus
	{
		private IRepository<Author> _auRepo;

		public ServiceBus(IRepository<Author> auRepo)
		{
			_auRepo = auRepo;
		}

		public List<AuthorViewModel> findAllAuthors()
		{
			List<AuthorViewModel> authors = new List<AuthorViewModel>();
			List<Author> auList;

			auList = (List<Author>)_auRepo.FindAll();

			foreach(Author au in auList)
			{
				AuthorViewModel avm = new AuthorViewModel(au.au_id, au.au_fname, au.au_lname);

				authors.Add(avm);
			}

			return authors;
		}

		public Author FindAuthor(string auid)
        {
			return _auRepo.Find(auid);
        }
	}
}
