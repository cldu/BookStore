using BookStore.DTOs;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Controllers.API
{
    public class RentController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public RentController()
        {

        }

        [HttpPost]
        public IHttpActionResult CreateRentals(RentalDto rentalDto)
        {
            var dbCustomer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);

            var dbBooks = _context.Books.Where(b => rentalDto.BookIds.Contains(b.Id)).ToList();

            foreach (var book in dbBooks)
            {
                if (book.NumberAvailable == 0)
                    return BadRequest("Book is out of stock.");

                book.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = dbCustomer,
                    Book = book,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
