using AutoMapper;
using Server.API.Models;
using Server.Core.Models;

namespace Server.API.Mapping
{
    public class PostModelsMappingProfile : Profile
    {
        public PostModelsMappingProfile() 
        {
            CreateMap<AdminPostModel, Admin>();
            CreateMap<EmployeePostModel, Employee>();
            CreateMap<JobPositionPostModel, JobPosition>();
        }
    }
}
