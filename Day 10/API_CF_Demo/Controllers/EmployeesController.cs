using API_CF_Demo.Models;
using API_CF_Demo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace API_CF_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        //Get employees
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> employees = _service.GetAllEmployees();
            return Ok(employees);
        }

        //GET employee by id 
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            Employee employee = _service.GetEmployeeById(id);
            if(employee == null)
            {
                return NotFound($"Employee with id {id} not found.");
            }
            return Ok(employee);
        }

        // POST employee
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            int Result = _service.AddNewEmployee(employee);
            return Ok(Result);
        }

        // PUT Update employee details 
        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            string result = _service.UpdateEmployee(employee);
            return Ok(result);
        }

        // DELETE employee
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteEmployee(id);
            return Ok(result);
        }
    }
}
