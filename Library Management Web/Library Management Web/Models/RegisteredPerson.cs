using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_Management_Web.Models
{
    public class RegisteredPerson
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Designation { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
       // [EmailAddress]
        public string Email { get; set; }
    }
}