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
    public class AuthorController : ApiController
    {
        public IEnumerable<Author> Get()
        {
            var db = new LibraryContext();
            return db.Authors.ToList();
        }

        public IHttpActionResult Post(string name, int born, int died)
        {
            var newAuthor = new Author
            {
                Name = name,
                Born = born,
                Died = died
            };

            var db = new LibraryContext();
            db.Authors.Add(newAuthor);
            db.SaveChanges();
            return Ok(newAuthor);
        }
    }
}
