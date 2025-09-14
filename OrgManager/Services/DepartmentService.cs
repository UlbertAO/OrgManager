using AutoMapper;
using OrgManager.Data.Repositories.Interfaces;
using OrgManager.DTOs.Department;
using OrgManager.Entities;

namespace OrgManager.Services
{
    public class DepartmentService
    {
        private readonly ILogger<DepartmentService> logger;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;

        public DepartmentService(ILogger<DepartmentService> logger, IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this.logger = logger;
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }

        public async Task<Department?> CreateDepartmentAsync(DepartmentCreateRequest departmentDto)
        {
            try
            {
                var department = mapper.Map<Department>(departmentDto);
                var createdDepartment = await departmentRepository.AddAsync(department);
                return createdDepartment;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while creating department");
                return null;
            }
        }

        public async Task<DepartmentGetByIdResponse?> DeleteDepartmentAsync(Guid id)
        {
            try
            {
                var deletedDepartment = await departmentRepository.DeleteAsync(id);

                var departmentResponseDto = mapper.Map<DepartmentGetByIdResponse>(deletedDepartment);

                return departmentResponseDto;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting department");
                return null;
            }
        }

        public async Task<List<DepartmentGetAllResponse>?> GetAllDepartmentsAsync()
        {
            try
            {
                var departments = await departmentRepository.GetAllAsync();

                var departmentsDto = mapper.Map<List<DepartmentGetAllResponse>>(departments);

                return departmentsDto;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving all departments");
                return null;
            }
        }

        public async Task<DepartmentGetByIdResponse?> GetDepartmentByIdAsync(Guid id)
        {
            try
            {
                var department = await departmentRepository.GetByIdAsync(id);
                if (department == null)
                {
                    return null;
                }

                var departmentDto = mapper.Map<DepartmentGetByIdResponse>(department);

                return departmentDto;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving department by Id");
                return null;
            }
        }

        public async Task<DepartmentGetByIdResponse?> UpdateDepartmentAsync(Guid id, DepartmentUpdateRequest departmentDto)
        {
            try
            {
                var department = mapper.Map<Department>(departmentDto);

                var updatedDepartment = await departmentRepository.UpdateAsync(id, department);
                
                return mapper.Map<DepartmentGetByIdResponse>(updatedDepartment);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating department");
                return null;
            }
        }

    }
}
