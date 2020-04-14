using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api {
    public class CustomersController : ApiController {
        private ApplicationDbContext _context;
        public CustomersController() {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetCustomers(string query = null) {
            var customerQuery = _context.Customers
                .Include(m => m.MembershipType);
            if (!string.IsNullOrEmpty(query))
                customerQuery = customerQuery.Where(x => x.Name.Contains(query));

            var queryDto = customerQuery.ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(queryDto);
        }

        [HttpGet]
        public IHttpActionResult GetCustomers(int id) {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto) {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return NotFound();

            Mapper.Map(customerDto, customer);
            _context.SaveChanges();

            return Ok(customer);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id) {
            var temp = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (temp == null)
                return NotFound();

            _context.Customers.Remove(temp);
            _context.SaveChanges();

            return Ok("Deleted");
        }
    }
}
