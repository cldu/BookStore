using BookStore.Models;
using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Books
        public ActionResult Index()
        {
            if (User.IsInRole("Administrator"))
                return View("Index");

            return View("IndexGuest");
        }


        public ActionResult Details(int id)
        {
            var book = _context.Books.Include(b => b.Category).SingleOrDefault(b => b.Id == id);

            if (book == null)
                return HttpNotFound();


            return View(book);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult New()
        {
            var bookViewModel = new BookFormViewModel
            {
                Book = new Book(),
                Categories = _context.Categories.ToList()
        };

            return View("BooksForm", bookViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Save(Book book)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel
                {
                    Book = book,
                    Categories = _context.Categories
                };
                return View("BooksForm", viewModel);
            }

            if (book.Id == 0)
            {
                book.AddedDate = DateTime.Now;
                _context.Books.Add(book);
            }
            else
            {
                var dbBook = _context.Books.Single(b => b.Id == book.Id);

                dbBook.Name = book.Name;
                dbBook.PublishedDate = book.PublishedDate;
                dbBook.AddedDate = book.AddedDate;
                dbBook.NumberInStock = book.NumberInStock;
                dbBook.CategoryId = book.CategoryId;
            }

            _context.SaveChanges();
            
            return RedirectToAction("Index", "Books");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var dbBook = _context.Books.Single(b => b.Id == id);

            if (dbBook == null)
                return HttpNotFound();
 
            var bookViewModel = new BookFormViewModel
            {
                Book = dbBook,
                Categories = _context.Categories.ToList()
            };

            return View("BooksForm", bookViewModel);
        }

    }
}