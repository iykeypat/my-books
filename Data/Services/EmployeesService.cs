using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class EmployeesService
    {
        private AppDbContext _context;
        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }

        //service to add a new employee
        public void AddEmployee(/*Employee _employee*/int id, string name, string position, DateTime dob, int salary, string email, string password)
        {
            var _employee = new Employee()
            {
                Id = id,
                Name = name,
                Position = position,
                Dob = dob,
                Salary = salary,
                Email = email,
                Password = password
            };
            _context.Employees.Add(_employee);
            _context.SaveChanges();

        }

        //service to retrieve all employees from db
        public List<Employee> GetAllEmployees() => _context.Employees.ToList();

        //service to retrieve a single employee from db given the id
        public Employee GetEmployeeById(int id)
        {
            try
            {
                var _employee = _context.Employees.Where(x => x.Id == id).Single();
                return _employee;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //service to update an employee detail given the id
        public string UpdateEmployeeById(int id, Employee employee)
        {
            try
            {
                var _employee = _context.Employees.Single(x => x.Id == id);

                _employee.Id = employee.Id;
                _employee.Name = employee.Name;
                _employee.Position = employee.Position;
                _employee.Dob = employee.Dob;
                _employee.Salary = employee.Salary;
                _employee.Email = employee.Email;
                _employee.Password = employee.Password;

                _context.SaveChanges();

            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Employee detail succesfully modified";
        }

        //service method to delete an employee given an id
        public string DeleteEmployeeById(int id)
        {
            try
            {
                var _employee = _context.Employees.Single(x => x.Id == id);
                _context.Employees.Remove(_employee);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                return e.Message;
            }

            return "Employee ${id} was deleted successfully";
        }
    }
}
