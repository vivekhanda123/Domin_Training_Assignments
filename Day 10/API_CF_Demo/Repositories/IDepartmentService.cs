using API_CF_Demo.Models;

namespace API_CF_Demo.Repositories
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById (int id);
        List<Department> SearchByName(string name);
        int AddNewDepartment(Department department);
        string UpdateDepartment(Department department);
        string DeleteDepartment(int id);
    }
}
