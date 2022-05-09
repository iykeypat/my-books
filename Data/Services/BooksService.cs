﻿using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook (BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        //service to retrieve all books from db
        public List<Book> GetAllBooks() => _context.Books.ToList();

        //service to retrieve a single book from db given the id
        public Book GetBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            return book;
        }

        //service to update a book given the id
        public Book UpdateBookById(int id, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == id);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;
                    _context.SaveChanges();
            }

            return _book;
        }

        //service method to delete a book given an id
        public void DeleteBookById(int id)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
