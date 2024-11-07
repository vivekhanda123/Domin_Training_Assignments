using API_DBF_Demo.DTO;
using API_DBF_Demo.Models;

namespace API_DBF_Demo.Mappings
{
    public static class MappingExtensions
    {
        // Mapping from Employee entity to EmployeeDTO
        //public static EmployeeDTO ToDTO(this Employee employee)
        //{
        //    return new EmployeeDTO
        //    {
        //        EmployeeId = employee.EmployeeId,
        //        Name = employee.Name
        //    };
        //}

        //// Mapping from EmployeeDTO to Employee entity
        //public static Employee ToEntity(this EmployeeDTO employeeDTO)
        //{
        //    return new Employee
        //    {
        //        EmployeeId = employeeDTO.EmployeeId,
        //        Name = employeeDTO.Name
        //    };
        //}

        //// Mapping from Department entity to DepartmentDTO
        //public static DepartmentDTO ToDTO(this Department department)
        //{
        //    return new DepartmentDTO
        //    {
        //        Id = department.Id,
        //        Name = department.Name
        //    };
        //}

        //// Mapping from DepartmentDTO to Department entity
        //public static Department ToEntity(this DepartmentDTO departmentDTO)
        //{
        //    return new Department
        //    {
        //        Id = departmentDTO.Id,
        //        Name = departmentDTO.Name
        //    };
        //}

        //// Mapping list of Employee entities to list of EmployeeDTOs
        //public static List<EmployeeDTO> ToDTOList(this List<Employee> employees)
        //{
        //    return employees.Select(employee => employee.ToDTO()).ToList();
        //}

        //// Mapping list of Department entities to list of DepartmentDTOs
        //public static List<DepartmentDTO> ToDTOList(this List<Department> departments)
        //{
        //    return departments.Select(department => department.ToDTO()).ToList();
        //}
    }
}
