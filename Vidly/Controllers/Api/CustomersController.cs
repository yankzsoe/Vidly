using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<CustomerDto> GetCustomers() {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        [HttpGet]
        public CustomerDto GetCustomers(int id) {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return customerDto;
        }

        [HttpDelete]
        public void UpdateCustomer(int id, CustomerDto customerDto) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var temp = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (temp == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, temp);
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
