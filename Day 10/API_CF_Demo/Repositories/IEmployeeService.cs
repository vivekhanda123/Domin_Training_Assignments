using API_CF_Demo.Models;

namespace API_CF_Demo.Repositories
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        int AddNewEmployee(Employee employee);
        string UpdateEmployee(Employee employee);
        string DeleteEmployee(int id);
    }
}
