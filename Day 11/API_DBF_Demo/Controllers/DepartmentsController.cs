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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _service;
        private readonly IMapper _mapper;
        public DepartmentsController(IDepartmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // Get departments data 
        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDTO>> GetAllDepartments()
        {
            var departments = _service.GetAllDepartments();
            var departmentDTOs = _mapper.Map<IEnumerable<DepartmentDTO>>(departments);
            return Ok(departmentDTOs);
        }

        // GET data by id
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartmentById(int id)
        {
            var department = _service.GetDepartmentById(id);
            if (department == null)
                return NotFound();

            var departmentDTO = _mapper.Map<DepartmentDTO>(department);
            return Ok(departmentDTO);
        }

        // POST create department 
        [HttpPost]
        public ActionResult<DepartmentDTO> AddDepartment(DepartmentDTO departmentDTO)
        {
            var department = _mapper.Map<Department>(departmentDTO);
            _service.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, departmentDTO);
        }

        // PUT update department data
        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, DepartmentDTO departmentDTO)
        {
            if (id != departmentDTO.Id)
                return BadRequest("Department ID mismatch");

            var department = _mapper.Map<Department>(departmentDTO);
            _service.UpdateDepartment(department);
            return NoContent();
        }

        // DELETE delete department 
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _service.GetDepartmentById(id);
            if (department == null)
                return NotFound();

            _service.DeleteDepartment(id);
            return NoContent();
        }
    }
}
