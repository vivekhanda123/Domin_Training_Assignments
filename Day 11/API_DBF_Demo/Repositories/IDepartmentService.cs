using API_DBF_Demo.Models;

namespace API_DBF_Demo.Repositories
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        void AddDepartment(Department department);
        string UpdateDepartment(Department department);
        string DeleteDepartment(int id);
    }
}
