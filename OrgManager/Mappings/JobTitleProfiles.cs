using AutoMapper;
using OrgManager.DTOs.JobTitle;
using OrgManager.Entities;

namespace OrgManager.Mappings
{
    public class JobTitleProfiles : Profile
    {
        public JobTitleProfiles()
        {
            CreateMap<JobTitle, JobTitleGetAllResponse>();
            CreateMap<JobTitle, JobTitleGetByIdResponse>();
            CreateMap<JobTitleCreateRequest, JobTitle>();
            CreateMap<JobTitleUpdateRequest, JobTitle>();
        }
    }
}
