using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string YearPublished { get; set; }
        public string Condition { get; set; }
        public string ISBN { get; set; }
        public bool IsCheckedOut { get; set; } = false;
        public DateTime? DueBackDate { get; set; }

        public Genre Genre { get; set; }
        public int GenreID { get; set; }

        public Author Author { get; set; }
        public int AuthorID { get; set; }
    }
}