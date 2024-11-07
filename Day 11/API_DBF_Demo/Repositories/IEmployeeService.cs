using API_DBF_Demo.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace API_DBF_Demo.Repositories
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
