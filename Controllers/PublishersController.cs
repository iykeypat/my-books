using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using my_books.Exceptions;
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

        [HttpGet("get-all-publishers")]
        public IActionResult GetALlPublishers()
        {
            var _publishers = _publishersservice.GetAllPublishers();
            return Ok(_publishers);
        }
        //service endpoint to add a new publisheer
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var _publisher = _publishersservice.AddPublisher(publisher);
                //return Ok();
                return Created(nameof(AddPublisher), _publisher);
            }
            catch (PublisherNameException ex)
            {

                return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
            }

            
        }

        //service endpoint to get publisher along with books published and authors
        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            throw new Exception("This is an exception that will be handled by middleware");

            var _response = _publishersservice.GetPublisherData(id);
            return Ok(Response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
          
            try
            {
                _publishersservice.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
