using API_DBF_Demo.Data;
using API_DBF_Demo.Models;

namespace API_DBF_Demo.Repositories
{
    public class DepartmentService : IDepartmentService
    {
        private readonly MyDbContext _context;
        public DepartmentService(MyDbContext context)
        {
            _context = context;
        }

        // Get all departments data
        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        // Add a new department
        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        // Delete department data
        public string DeleteDepartment(int id)
        {
            if (id != null)
            {
                var department = _context.Departments.FirstOrDefault(d => d.Id == id);
                if (department != null)
                {
                    _context.Departments.Remove(department);
                    _context.SaveChanges();
                    return "The given Department id " + id + " Removed Successfully";
                }
                else
                    return "Something went wrong with delete";
            }
            return "Id Should not be null or zero";
        }

        // Get the department by id
        public Department GetDepartmentById(int id)
        {
            return _context.Departments.FirstOrDefault(d => d.Id == id);
        }

        // Update department data
        public string UpdateDepartment(Department department)
        {
            var existingDepartment = _context.Departments.FirstOrDefault(d => d.Id == department.Id);
            if (existingDepartment != null)
            {
                existingDepartment.Name = department.Name;
                _context.SaveChanges();
                return "Record Updated Successfully";
            }
            else
                return "Something went wrong while updating";
        }
    }
}
