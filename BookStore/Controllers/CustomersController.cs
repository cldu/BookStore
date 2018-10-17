using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using BookStore.ViewModels;

namespace BookStore.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            if (User.IsInRole("Administrator"))
                return View("Index");

            return View("IndexGuest");
        }
        
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }


            return View(customer);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var customerViewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", customerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var dbCustomer = _context.Customers.Single(c => c.Id == customer.Id);
                dbCustomer.Name = customer.Name;
                dbCustomer.Birthday = customer.Birthday;
                dbCustomer.MembershipTypeId = customer.MembershipTypeId;
                dbCustomer.IsStudent = customer.IsStudent;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
        
    }
}