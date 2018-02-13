using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library_Management_Web.Models
{
    public class LibraryManagementContext :DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<RegisteredPerson> Person { get; set; }
        public DbSet<BookBorrow> Borrow { get; set; }
    }
}