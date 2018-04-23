using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.View_Models
{
    public class PostBook
    {
        public string Title { get; set; }
        public string YearPublished { get; set; }
        public string Condition { get; set; }
        public string ISBN { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime DueByDate { get; set; }
        public Genre GenreName { get; set; }
        public Author AuthorName { get; set; }
    }
}