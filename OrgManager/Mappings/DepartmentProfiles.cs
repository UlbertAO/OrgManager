using AutoMapper;
using OrgManager.DTOs.Department;
using OrgManager.Entities;

namespace OrgManager.Mappings
{
    public class DepartmentProfiles : Profile
    {
        public DepartmentProfiles()
        {
            CreateMap<Department, DepartmentGetAllResponse>();
            CreateMap<Department, DepartmentGetByIdResponse>();
            CreateMap<DepartmentCreateRequest, Department>();
            CreateMap<DepartmentUpdateRequest, Department>();
        }
    }
}
