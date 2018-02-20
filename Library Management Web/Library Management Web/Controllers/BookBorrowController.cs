using Library_Management_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_Web.Controllers
{
    public class BookBorrowController : Controller
    {
        LibraryManagementContext _context = new LibraryManagementContext();
        // GET: BookBorrow
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }

            var model = _context.Borrow.OrderByDescending(x => x.BorrowDate).ToList();
            return View(model);
        }

        // GET: BookBorrow/Details/5
        public ActionResult Details(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            BookBorrow borrow = _context.Borrow.Find(id);
            return View(borrow);
        }

        // GET: BookBorrow/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            List<Book> Booklist = _context.Books.ToList();
            ViewBag.Booklist = new SelectList(Booklist, "BookName", "BookName");

            List<RegisteredPerson> Personlist = _context.Person.ToList();
            ViewBag.Personlist = new SelectList(Personlist, "Name", "Name");

            return View();
        }

        // POST: BookBorrow/Create
        [HttpPost]
        public ActionResult Create(BookBorrow collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.BorrowDate = DateTime.Today;
                collection.ReturnDate = "--";
                _context.Borrow.Add(collection);
                _context.SaveChanges();

                int BookId = _context.Books.FirstOrDefault(x => x.BookName == collection.BookName).Id;
                Book Book = _context.Books.Find(BookId);
                Book.NumberOfBooksIsBorrowed += 1;
                _context.Entry(Book).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookBorrow/Return
        public ActionResult Return(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            DateTime tt = DateTime.Today;

            BookBorrow borrow = _context.Borrow.Find(id);

            TimeSpan D = tt - borrow.BorrowDate;
            var days = D.TotalDays;
            
            ViewBag.Days = days;
           
            return View(borrow);
        }

        // POST: BookBorrow/Return
        [HttpPost]
        public ActionResult Return(int id, BookBorrow collection)
        {
            try
            {
                // TODO: Add update logic here
                BookBorrow borrow = _context.Borrow.Find(id);
                borrow.ReturnDate = DateTime.Today.ToString("MM/dd/yyyy");

                _context.Entry(borrow).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
