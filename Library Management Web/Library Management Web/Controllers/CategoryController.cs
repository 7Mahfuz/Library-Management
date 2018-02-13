using Library_Management_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_Web.Controllers
{
    public class CategoryController : Controller
    {
        LibraryManagementContext _context = new LibraryManagementContext();
        // GET: Category
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            var model = _context.BookCategory.ToList();
            return View(model);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            Book book = _context.Books.Find(id);
            return View(book);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(BookCategory collection)
        {
            try
            {
                // TODO: Add insert logic here
                _context.BookCategory.Add(collection);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _context.BookCategory.Find(id);
            return View(model);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookCategory collection)
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

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _context.BookCategory.Find(id);
            return View(model);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BookCategory collection)
        {
            try
            {
                // TODO: Add delete logic here
                BookCategory book = _context.BookCategory.Find(id);
                _context.BookCategory.Remove(book);
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
