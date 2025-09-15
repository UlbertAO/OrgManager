using Microsoft.EntityFrameworkCore;
using OrgManager.Data.Repositories.Interfaces;

namespace OrgManager.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly OrgDbContext orgDbContext;
        private readonly DbSet<T> dbSet;

        public GenericRepository(OrgDbContext orgDbContext)
        {
            this.orgDbContext = orgDbContext;
            this.dbSet = orgDbContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await orgDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            dbSet.Remove(entity);
            await orgDbContext.SaveChangesAsync();

            return entity;
        }

        public Task<List<T>> GetAllAsync()
        {
            return dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await orgDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
