using Demo_API_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>();
        static EmployeesController()
        {
            employees = new List<Employee>()
            {
                new Employee(){EmployeeId=1,Name="Shivam",DOJ=new DateTime(2024,01,22),Designation="Trainee",Salary=35000M},
                new Employee(){EmployeeId=2,Name="Satyam",DOJ=new DateTime(2024,05,02),Designation="Trainee",Salary=30000M},
                new Employee(){EmployeeId=3,Name="Akshay",DOJ=new DateTime(2024,02,05),Designation="Trainee",Salary=20000M},
                new Employee(){EmployeeId=4,Name="Aditya",DOJ=new DateTime(2024,03,12),Designation="Trainee",Salary=25000M}
            };
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            if (employees.Count > 0)
            {
                return Ok(employees);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult PostEmployee([FromBody]Employee employee)
        {
            if (employee == null)
                return BadRequest();
            else if (employees.Any(e=>e.EmployeeId == employee.EmployeeId))
            {
                return Conflict("An employee with this ID already exists.");
            }
            else
                employees.Add(employee);
            return CreatedAtAction(nameof(GetAllEmployees), new { id = employee.EmployeeId, message = "Employee Added Successfully!" });
        }
        [HttpPut]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest("ID Mismatch");
            }
            var existingEmployee = employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            if (existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Designation = employee.Designation;
            existingEmployee.DOJ = employee.DOJ;
            existingEmployee.Salary = employee.Salary;
            return Ok(new { message = "Employee Updated Successfully!", employee = existingEmployee });
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var existingEmployee = employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            if (existingEmployee == null)
            {
                return NotFound();
            }
            employees.Remove(existingEmployee);
            return Ok(new { message = "Emoloyee Deleted Successfully!", employee = existingEmployee.EmployeeId + "Removed" });
        }
    }
}
