using API_CF_Demo.Data;
using API_CF_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace API_CF_Demo.Repositories
{
    public class EmployeeService : IEmployeeService
    {
        private readonly MyDbContext _context;
        public EmployeeService(MyDbContext context)
        {
            _context = context;
        }

        // Get all employee data 
        public List<Employee> GetAllEmployees()
        {
            var employees = _context.Employees.ToList();
            if(employees.Count > 0)
            {
                return employees;
            }
            else
            {
                return null;
            }
        }

        // Add new Employee
        public int AddNewEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    return employee.EmployeeId; 
                }
                return 0; 
            }
            catch (Exception e)
            {
                throw new Exception("Error adding new employee: " + e.Message);
            }
        }

        // Delete an Employee by using id
        public string DeleteEmployee(int id)
        {
            if (id > 0)
            {
                var employee = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    return "Employee with ID " + id + " was removed successfully.";
                }
                else
                {
                    return "Employee not found for the given ID.";
                }
            }
            return "ID should not be null or zero.";
        }

        // Get employee by ID
        public Employee GetEmployeeById(int id)
        {
            if (id > 0)
            {
                var employee = _context.Employees.FirstOrDefault(x=>x.EmployeeId == id);
                return employee;
            }
            return null;
        }

        // Update employee details
        public string UpdateEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
            if(existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.Designation = employee.Designation;
                existingEmployee.Email = employee.Email;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.DepartmentId = employee.DepartmentId;

                _context.Entry(existingEmployee).State = EntityState.Modified;
                _context.SaveChanges();
                return "Employeee record updated Successfully.";
            }
            return "Employee not found for given id";
        }
    }
}
