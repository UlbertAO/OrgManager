using OrgManager.Entities;

namespace OrgManager.Data.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> AddAsync(Department department);
        Task<Department?> DeleteAsync(Guid id);
        Task<List<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(Guid id);
        Task<Department?> UpdateAsync(Guid id, Department department);
    }
}
