using API_DBF_Demo.DTO;
using API_DBF_Demo.Models;
using AutoMapper;

namespace API_DBF_Demo.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<Department, DepartmentDTO>().ReverseMap();
        }
    }
}
