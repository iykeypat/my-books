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
    public class PublisherController : ControllerBase
    {
        private PublishersService _publishersservice;

        public PublisherController(PublishersService publishersservice)
        {
            _publishersservice = publishersservice;
        }

        //service endpoint to add a new publisheer
        [HttpPost("add-publisher")]
        public IActionResult AddAuthor([FromBody] PublisherVM publisher)
        {
            _publishersservice.AddPublisher(publisher);
            return Ok();
        }

        //service endpoint to get publisher along with books published and authors
        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersservice.GetPublisherData(id);
            return Ok(Response);
        }

    }
}
