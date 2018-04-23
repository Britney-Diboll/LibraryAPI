using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library.Data;
using Library.Models;
using Library.View_Models;

namespace Library.Controllers
{
    public class CheckOutController : ApiController
    {
        [HttpPut]
        [Route("api/book/{bookid}/checkout")]
        public CheckOutMessage Put([FromUri] int bookID, [FromBody] CheckOutViewModel data)
        {
            var db = new LibraryContext();
            var book = db.Books.Single(x => x.ID == bookID);

            if (!book.IsCheckedOut)
            {
                book.IsCheckedOut = true;
                book.DueBackDate = DateTime.Now.AddDays(7);

                var newCheckout = new CheckOut()
                {
                    TimeStamp = DateTime.Now,
                    Email = data.Email,
                    BookID = book.ID,
                    Book = book
                };
                db.Checkouts.Add(newCheckout);
                db.SaveChanges();

                return new CheckOutMessage
                {
                    Message = $"You have successfully checked out this book. Please return in 7 days! "
                };
            } else
            {
                return new CheckOutMessage
                {
                    Message = $"This book is unavailable at the moment"
                    
                };
            }
        }
    }
}
