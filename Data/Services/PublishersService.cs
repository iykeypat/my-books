﻿using my_books.Data.Models;
using my_books.Data.Paging;
using my_books.Data.ViewModels;
using my_books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        //this service method adds a new publisher to the publishers table
        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartWithNumber(publisher.Name)) throw new PublisherNameException(
                "Name starts with a number", publisher.Name);

            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public List<Publisher> GetAllPublishers(string sortBy, string searchString, int? pageNumber)
        {
            var _allPublishers = _context.Publishers.OrderBy(n=>n.Name).ToList(); //this line sorts in ascending order by default
            
            //the code below will sort according to the requested order
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        _allPublishers = _allPublishers.OrderByDescending(n => n.Name).ToList();
                        break;
                    default:
                        break;
                }
            }

            //the code below will filter the result according to the provided serachString
            if (!string.IsNullOrEmpty(searchString))
            {
                _allPublishers = _allPublishers.Where(n => n.Name.Contains(searchString,StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            //paging
            int pageSize = 5;
            _allPublishers = PaginatedList<Publisher>.Create(_allPublishers.AsQueryable(), pageNumber ?? 1, pageSize);


                return _allPublishers;
        }

        //this service gets the publisher along with the books and authors
        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n=>n.Id==publisherId).Select(
                n=>new PublisherWithBooksAndAuthorsVM(){
                Name = n.Name,
                BookAuthors = n.Books.Select(n=>new BookAuthorVM()
                {
                    BookName = n.Title,
                    BookAuthors = n.Book_Authors.Select(n=>n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();

            return _publisherData;
        }

        //service to delete a publisher
        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher with id {id} does not exist.");
            }
        }

        private bool StringStartWithNumber(string name)
        {
            if (Regex.IsMatch(name, @"^\d")) return true;
            return false;
        }
    }
}
