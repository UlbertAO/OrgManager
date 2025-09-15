using OrgManager.Entities;

namespace OrgManager.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T?> DeleteAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> UpdateAsync(T entity);
    }
}
