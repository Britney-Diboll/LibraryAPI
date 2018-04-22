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
    public class BookFactoryController : ApiController
    {
        public IHttpActionResult Post(Book data)
        {
            var db = new LibraryContext();
            db.Books.Add(data);
            db.SaveChanges();
            return Ok(data);
        }
    }
}
