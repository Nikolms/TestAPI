using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi.Models
{
    public class BookDetailDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public string AuthorName { get; set; }
        
    }
}