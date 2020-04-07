using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api {
    public class CustomersController : ApiController {
        private ApplicationDbContext _context;
        public CustomersController() {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Customer> GetCustomers() {
            return _context.Customers.ToList();
        }

        public Customer GetCustomers(int id) {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
        
        [HttpDelete]
        public void UpdateCustomer(int id, Customer customer) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var temp = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (temp == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            temp.Name = customer.Name;
            temp.BirthofDate = customer.BirthofDate;
            temp.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            temp.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id) {
            var temp = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (temp == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(temp);
            _context.SaveChanges();
        }
    }
}
