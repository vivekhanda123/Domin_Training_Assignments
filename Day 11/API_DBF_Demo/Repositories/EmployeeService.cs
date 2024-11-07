using API_DBF_Demo.Data;
using API_DBF_Demo.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_DBF_Demo.Repositories
{
    public class EmployeeService : IEmployeeService
    {
        private readonly MyDbContext _context;

        public EmployeeService(MyDbContext context)
        {
            _context = context;
        }

        // Get all employee data
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        // Add new employee
        public void AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
        }

        // Get employee by id
        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        // Update the employee data
        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.DeptId = employee.DeptId;
                _context.SaveChanges();
            }
        }

        // Delete employee data
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
