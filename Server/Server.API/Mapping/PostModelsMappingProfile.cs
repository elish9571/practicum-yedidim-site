using AutoMapper;
using Server.API.Models;
using Server.Core.DTOs;
using Server.Core.Models;

namespace Server.API.Mapping
{
    public class PostModelsMappingProfile : Profile
    {
        public PostModelsMappingProfile() 
        {
            CreateMap<AdminPostModel, Admin>().ReverseMap();
            CreateMap<EmployeePostModel, Employee>().ReverseMap();
            CreateMap<JobPositionPostModel, JobPosition>().ReverseMap();
            CreateMap<EmployeeJobPositionPostModel, EmployeeJobPosition>().ReverseMap();
        }
    }
}
