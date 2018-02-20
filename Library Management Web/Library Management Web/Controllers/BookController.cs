using Library_Management_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_Web.Controllers
{
    public class BookController : Controller
    {
        LibraryManagementContext _context = new LibraryManagementContext();
        // GET: Book
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            var model = _context.Books.ToList();
            return View(model);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            Book book = _context.Books.Find(id);
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            List<BookCategory> Categorylist = _context.BookCategory.ToList();
            ViewBag.Categorylist = new SelectList(Categorylist, "CategoryName", "CategoryName");
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.NumberOfBooksIsBorrowed = 0;
                _context.Books.Add(collection);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            Book book = _context.Books.Find(id);
            List<BookCategory> Categorylist = _context.BookCategory.ToList();
            ViewBag.Categorylist = new SelectList(Categorylist, "CategoryName", "CategoryName");
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book collection)
        {
            try
            {
                // TODO: Add update logic here
                _context.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            Book book = _context.Books.Find(id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book collection)
        {
            try
            {
                // TODO: Add delete logic here
                Book book = _context.Books.Find(id);
                _context.Books.Remove(book);
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
