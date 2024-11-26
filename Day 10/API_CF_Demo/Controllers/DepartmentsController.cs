using API_CF_Demo.Models;
using API_CF_Demo.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_CF_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentsController(IDepartmentService service)
        {
            _service = service;
        }

        [EnableCors("MyPolicy")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Department> departments = _service.GetAllDepartments();
            if (departments == null || departments.Count == 0)
            {
                return NotFound("No departments found.");
            }
            return Ok(departments);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDepartmentById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid department ID.");
            }

            Department department = _service.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound($"Department with ID {id} not found.");
            }
            return Ok(department);
        }

        [HttpGet("name/{name:length(3,12)}")]
        public IActionResult GetDepartmentByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Department name must be provided.");
            }

            var departments = _service.SearchByName(name);
            if (departments == null || departments.Count == 0)
            {
                return NotFound($"No departments found with the name '{name}'.");
            }
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest("Department data is required.");
            }

            int result = _service.AddNewDepartment(department);
            if (result <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while creating the department.");
            }

            return CreatedAtAction(nameof(GetDepartmentById), new { id = result }, department);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Department department)
        {
            if (id <= 0 || department == null || department.Id != id)
            {
                return BadRequest("Invalid department data or ID.");
            }

            string result = _service.UpdateDepartment(department);
            if (result.Contains("not found"))
            {
                return NotFound($"Department with ID {id} not found for update.");
            }

            if (result.Contains("successfully"))
            {
                return Ok(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while updating the department.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid department ID.");
            }

            string result = _service.DeleteDepartment(id);
            if (result.Contains("not found"))
            {
                return NotFound($"Department with ID {id} not found for deletion.");
            }

            return Ok(result);
        }
    }
}
