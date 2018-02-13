using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_Management_Web.Models
{
    public class BookCategory
    {
        [Key]
        public  int Id { get; set; }
        public string CategoryName { get; set; }
    }
}