using System;
using Repositories;
using Model;
using System.Collections.Generic;
using ViewModels;

namespace PubsServiceBus
{
	public class ServiceBus
	{
		public IRepository<Author> _auRepo;
		public IItemsByRepo<Book, Author> _bRepo;

		public ServiceBus(IRepository<Author> auRepo, IItemsByRepo<Book, Author> bRepo)
		{
			_auRepo = auRepo;
			_bRepo = bRepo;
		}

		public List<BookViewModel> findAllBooksByAuthor(Author x)
        {
			List<BookViewModel> books = new List<BookViewModel>();
			List<Book> bList;

			bList = (List<Book>)_bRepo.ItemsFor(x);

			foreach(Book b in bList)
            {
				BookViewModel bvm = new BookViewModel(b.title_id, b.title, b.type, /*b.pub_id*/b.publisher, b.price, b.ytd_sales, b.pubdate);

				books.Add(bvm);
            }

			return books;
        }

		public List<AuthorViewModel> findAllAuthors()
		{
			List<AuthorViewModel> authors = new List<AuthorViewModel>();
			List<Author> auList;

			auList = (List<Author>)_auRepo.FindAll();

			foreach(Author au in auList)
			{
				AuthorViewModel avm = new AuthorViewModel(au.au_id, au.au_fname, au.au_lname, au.au_phone, 
														  au.au_address, au.au_city, au.au_state, au.au_zip, au.au_contract);

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
