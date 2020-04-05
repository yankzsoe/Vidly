using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers {
    public class CustomersController : Controller {
        // GET: Customers
        private ApplicationDbContext _context;
        public CustomersController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        public ActionResult Index() {
            var model = _context.Customers.Include(m => m.MembershipType).ToList();
            return View(model);
        }
        
        // GET: Customers/Details/5
        public ActionResult Details(int id) {
            var model = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }

        // GET: Customers/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id) {
            var model = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id) {
            var model = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
