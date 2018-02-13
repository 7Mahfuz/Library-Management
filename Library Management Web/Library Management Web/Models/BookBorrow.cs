using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_Management_Web.Models
{
    public class BookBorrow
    {
        [Key]
        public int Id { get; set; }
        public string BookName { get; set; }
        public string PersonName { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }
        
        public string ReturnDate { get; set; }
    }
}