using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_Management_Web.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Arraival { get; set; }
        public string Description { get; set; }

        public int NumberOfBooks { get; set; }
        public int NumberOfBooksIsBorrowed { get; set; }
    }
}