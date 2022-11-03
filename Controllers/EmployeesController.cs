using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
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
    public class EmployeesController : ControllerBase
    {
        public EmployeesService _employeesService;
        public EmployeesController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        //this is a service endpoint to add a new employee to database
        [HttpPost("add-employee")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeesService.AddEmployee(employee);
            return Ok("Employee added successfully");
        }

        //this is service endpoint to retrieve all employees from the db
        [HttpGet("get-all-employees")]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = _employeesService.GetAllEmployees();
            return Ok(allEmployees);
        }

        //this is service endpoint to retrieve a single employee from the db give the id
        [HttpGet("get-employee-by-id/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeesService.GetEmployeeById(id);
            return Ok(employee);
        }

        //this is a service endpint to update an existing employee given an id
        [HttpPut("update-employee-by-id/{id}")]
        public IActionResult UpdateEmployeeById(int id,Employee employee)
        {
            var updatedEmployee = _employeesService.UpdateEmployeeById(id, employee);
            return Ok(updatedEmployee);
        }

        //this is a service endpoint to delete an employee based on a given id
        [HttpDelete("delete-employee-by-id/{id}")]
        public IActionResult DeleteEmployeeById(int id)
        {
            var result = _employeesService.DeleteEmployeeById(id);
            return Ok(result);
        }
    }
}
