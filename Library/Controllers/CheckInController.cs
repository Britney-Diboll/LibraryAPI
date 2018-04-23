using Library.Data;
using Library.Models;
using Library.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Controllers
{
    public class CheckInController : ApiController
    {
        [HttpPut]
        [Route("api/book/{bookid}/checkin")]
        public CheckInMessage Put([FromUri] int bookID, [FromBody] CheckOutViewModel data)
        {
            var db = new LibraryContext();
            var book = db.Books.Single(x => x.ID == bookID);

            if (book.IsCheckedOut)
            {
                book.IsCheckedOut = true;
                book.DueBackDate = DateTime.Now;

                var newCheckout = new CheckOut()
                {
                    TimeStamp = DateTime.Now,
                    Email = data.Email,
                    BookID = book.ID,
                    Book = book
                };
                db.Checkouts.Add(newCheckout);
                db.SaveChanges();


            }
            return new CheckInMessage
            {
                Message = $"You have successfully checked in this book. Thank you and have a wonderful day! "
            };
        }
    }
}
