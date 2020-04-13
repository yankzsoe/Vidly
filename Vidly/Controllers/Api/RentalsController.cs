using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api {
    public class RentalsController : ApiController {
        private ApplicationDbContext _context;
        public RentalsController() {
            _context = new ApplicationDbContext();
        }
        // GET api/<controller>
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id) {
            return "value";
        }

        [HttpPost]
        public IHttpActionResult NewRentals(RentalDto rental) {
            var customer = _context.Customers.Single(x => x.Id == rental.CustomerId);
            var movies = _context.Movies.Where(x => rental.MovieIds.Contains(x.Id));

            foreach (var item in movies) {
                if (item.NumberInStock == 0)
                    return BadRequest("Movie is not available.");

                var rent = new Rental() {
                    Customer = customer,
                    Movie = item,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rent);
            }
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/<controller>/5
        public void Delete(int id) {
        }
    }
}