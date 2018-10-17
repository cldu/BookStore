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
    public class BooksController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public BooksController()
        {

        }

        public IHttpActionResult GetBooks(string query = null)
        {
            var booksQuery = _context.Books.Include(b => b.Category).Where(b => b.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                booksQuery = booksQuery.Where(b => b.Name.Contains(query));

            var bookDtos = booksQuery.ToList().Select(Mapper.Map<Book, BookDto>);

            return Ok(bookDtos);
        }

        public IHttpActionResult GetBook(int id)
        {
            var dbBook = _context.Books.SingleOrDefault(b => b.Id == id);

            if (dbBook == null)
                return NotFound();

            return Ok(Mapper.Map<Book, BookDto>(dbBook));
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bookDto.AddedDate = DateTime.Now;

            var book = Mapper.Map<BookDto, Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();

            bookDto.Id = book.Id;

            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDto);
        }

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dbBook = _context.Books.SingleOrDefault(b => b.Id == id);

            if (dbBook == null)
                return NotFound();

            Mapper.Map(bookDto, dbBook);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult DeleteBook(int id)
        {
            var dbBook = _context.Books.SingleOrDefault(b => b.Id == id);

            if (dbBook == null)
                return NotFound();

            _context.Books.Remove(dbBook);
            _context.SaveChanges();

            return Ok();
        }


    }
}
