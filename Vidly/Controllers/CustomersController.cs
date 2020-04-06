using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

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

        public ActionResult Details(int id) {
            var model = _context.Customers.Include(m => m.MembershipType).FirstOrDefault(x => x.Id == id);
            if (model == null)
                return HttpNotFound();
            return View(model);
        }

        public ActionResult Create() {
            var membershipType = _context.MembershipTypes.ToList();
            var model = new CustomerFormViewModel() {
                MembershipTypes = membershipType
            };
            return View("CustomerForm", model);
        }

        public ActionResult Edit(int id) {
            var model = _context.Customers.FirstOrDefault(x => x.Id == id);
            var viewModel = new CustomerFormViewModel() {
                Customer = model,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer) {
            try {
                if (!ModelState.IsValid) {
                    var model = new CustomerFormViewModel() {
                        Customer = customer,
                        MembershipTypes = _context.MembershipTypes.ToList()
                    };
                    return View("CustomerForm", model);
                }

                if (customer.Id == 0) {
                    _context.Customers.Add(customer);
                } else {
                    var temp = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                    if (temp == null)
                        return HttpNotFound();
                    temp.Name = customer.Name;
                    temp.BirthofDate = customer.BirthofDate;
                    temp.MembershipTypeId = customer.MembershipTypeId;
                    temp.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                }
                _context.SaveChanges();
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
