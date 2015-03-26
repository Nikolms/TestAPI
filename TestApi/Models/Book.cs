using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApi.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}