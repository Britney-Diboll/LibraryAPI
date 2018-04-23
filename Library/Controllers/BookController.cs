using Library.Data;
using Library.Models;
using Library.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;



namespace Library.Controllers
{
    public class BookController : ApiController
    {
        public IEnumerable<BookViewModel> Get()
        {
            var db = new LibraryContext();
            var data = db.Books
                            .Include(x => x.Author)
                            .Include(x => x.Genre)
                            .ToList();

            var result = data.Select(book => new BookViewModel
                {
                BookName = book.Title,
                AuthorName = book.Author.Name,
                GenreName = book.Genre.Name,
                YearPublished = book.YearPublished

                });
            return result;
        }

        



    }
}
