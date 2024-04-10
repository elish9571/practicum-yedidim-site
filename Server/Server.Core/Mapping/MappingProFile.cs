using AutoMapper;
using Server.Core.DTOs;
using Server.Core.Models;

namespace Server.Core.Mapping
{
    public class MappingProFile : Profile
    {
        public MappingProFile()
        {
            CreateMap<Admin, AdminDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<JobPosition, JobPositionDto>().ReverseMap();
        }
    }
}
