using OrgManager.Entities;

namespace OrgManager.Data.Repositories.Interfaces
{
    public interface IJobTitleRepository
    {
        Task<JobTitle> AddAsync(JobTitle jobTitle);
        Task<JobTitle?> DeleteAsync(Guid id);
        Task<List<JobTitle>> GetAllAsync();
        Task<JobTitle?> GetByIdAsync(Guid id);
        Task<JobTitle?> UpdateAsync(Guid id, JobTitle jobTitle);
    }
}