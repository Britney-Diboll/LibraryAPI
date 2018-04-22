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
    public class SearchController : ApiController
    {
        [HttpGet]
        public IEnumerable<Book> Search([FromUri]SearchParams param)
        {
            using (var db = new Data.LibraryContext())
            {
                var query = db.Books.Include(x => x.Author).Include(x => x.Genre);

                if (!string.IsNullOrEmpty(param.Title))
                {
                    query = query.Where(x => x.Title == param.Title);
                }
                if (param.Genre != null)
                {
                    query = query.Where(x => x.Genre.Name == param.Genre);
                }
                if (param.Author != null)
                {
                    query = query.Where(x => x.Author.Name == param.Author);
                }


            return query.ToList();

            }
        }
    }
}
