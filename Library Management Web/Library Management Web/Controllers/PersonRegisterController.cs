using Library_Management_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_Web.Controllers
{
    public class PersonRegisterController : Controller
    {
        LibraryManagementContext _context = new LibraryManagementContext();
        // GET: PersonRegister
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Status = "Yes";
            }
            var model = _context.Person.ToList();
            return View(model);
        }

        // GET: PersonRegister/Details/5
        public ActionResult Details(int id)
        {
            RegisteredPerson Person = _context.Person.Find(id);
            return View(Person);
        }

        // GET: PersonRegister/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonRegister/Create
        [HttpPost]
        public ActionResult Create(RegisteredPerson collection)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Person.Add(collection);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonRegister/Edit/5
        public ActionResult Edit(int id)
        {
            RegisteredPerson Person = _context.Person.Find(id);
            return View(Person);
        }

        // POST: PersonRegister/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RegisteredPerson collection)
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

        // GET: PersonRegister/Delete/5
        public ActionResult Delete(int id)
        {
            RegisteredPerson Person = _context.Person.Find(id);
            return View(Person);
        }

        // POST: PersonRegister/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,RegisteredPerson collection)
        {
            try
            {
                // TODO: Add delete logic here
                RegisteredPerson person = _context.Person.Find(id);
                _context.Person.Remove(person);
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
