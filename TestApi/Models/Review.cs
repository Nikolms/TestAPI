using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApi.Models
{
    public class Review
    {
        public int ID { get; set; }
        public int rating { get; set; }
        public string Comment { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}