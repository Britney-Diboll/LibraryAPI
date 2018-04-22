using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Library.Controllers
{
    public class BookController : ApiController
    {
        public IEnumerable<Book> Get()
        {
            var db = new LibraryContext();
            return db.Books.ToList();
        }

        public IHttpActionResult Post(string title, string yearpublished, string condition, string isbn, bool ischeckedout, DateTime duebackdate, int genreid, int authorid)
        {
            var newBook = new Book
            {
                Title = title,
                YearPublished = yearpublished,
                Condition = condition,
                ISBN = isbn,
                IsCheckedOut = ischeckedout,
                DueBackDate = duebackdate
            };

            var db = new LibraryContext();
            db.Books.Add(newBook);
            db.SaveChanges();
            return Ok(newBook);
        }
    }
}
