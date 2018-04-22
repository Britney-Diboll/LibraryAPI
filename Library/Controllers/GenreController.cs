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
    public class GenreController : ApiController
    {
        public IEnumerable<Genre> Get()
        {
            var db = new LibraryContext();
            return db.Genres.ToList();
        }

        public IHttpActionResult Post(string name)
        {
            var newGenre = new Genre
            {
                Name = name
            };

            var db = new LibraryContext();
            db.Genres.Add(newGenre);
            db.SaveChanges();
            return Ok(newGenre);
        }
    }
}
