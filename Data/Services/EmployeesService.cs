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
        public void AddEmployee(Employee emp)
        {
            var _employee = new Employee()
            {
                Id = emp.Id,
                Name = emp.Name,
                Position = emp.Position,
                Dob = emp.Dob,
                Salary = emp.Salary,
                Email = emp.Email,
                Password = emp.Password
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

            return "Success";
        }
    }
}
