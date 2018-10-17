using AutoMapper;
using BookStore.DTOs;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace BookStore.Controllers.API
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public CustomersController()
        {

        }
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customerQuery = _context.Customers.Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
                customerQuery = customerQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customerQuery.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var dbCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (dbCustomer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(dbCustomer));
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dbCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (dbCustomer == null)
                return NotFound();

            Mapper.Map(customerDto, dbCustomer);

            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var dbCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (dbCustomer == null)
                return NotFound();

            _context.Customers.Remove(dbCustomer);
            _context.SaveChanges();

            return Ok();
        }
        
    }
}
