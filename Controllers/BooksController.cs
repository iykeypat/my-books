using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _bookService;
        public BooksController(BooksService booksService)
        {
            _bookService = booksService;
        }

        //this is a service endpoint to add a new book to database
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        //this is servicce endpoint to retrieve all books from the db
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        //this is service endpoint to retrieve a single book from the db give the id
        [HttpGet("get-all-books/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }
    }
}
