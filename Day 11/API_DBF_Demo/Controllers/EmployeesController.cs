using API_DBF_Demo.DTO;
using API_DBF_Demo.Models;
using API_DBF_Demo.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_DBF_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET get all data 
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            var employees = _service.GetAllEmployees();
            var employeeDTOs = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return Ok(employeeDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDTO> GetEmployeeById(int id)
        {
            var employee = _service.GetEmployeeById(id);
            if (employee == null)
                return NotFound();

            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            return Ok(employeeDTO);
        }

        // POST create new employee
        [HttpPost]
        public ActionResult<EmployeeDTO> AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            _service.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employeeDTO);
        }

        // PUT update employee data
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.EmployeeId)
                return BadRequest("Employee ID mismatch");

            var employee = _mapper.Map<Employee>(employeeDTO);
            _service.UpdateEmployee(employee);
            return NoContent();
        }

        // DELETE delete employee
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _service.GetEmployeeById(id);
            if (employee == null)
                return NotFound();

            _service.DeleteEmployee(id);
            return NoContent();
        }
    }
}
