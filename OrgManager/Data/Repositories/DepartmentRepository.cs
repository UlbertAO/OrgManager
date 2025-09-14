using Microsoft.EntityFrameworkCore;
using OrgManager.Data.Repositories.Interfaces;
using OrgManager.Entities;

namespace OrgManager.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly OrgDbContext orgDbContext;

        public DepartmentRepository(OrgDbContext orgDbContext)
        {
            this.orgDbContext = orgDbContext;
        }
        public async Task<Department> AddAsync(Department department)
        {
            await orgDbContext.Departments.AddAsync(department);
            await orgDbContext.SaveChangesAsync();
            return department;
        }

        public async Task<Department?> DeleteAsync(Guid id)
        {
            var departmentDoamin = await GetByIdAsync(id);
            if (departmentDoamin == null)
            {
                return null;
            }

            orgDbContext.Departments.Remove(departmentDoamin);
            await orgDbContext.SaveChangesAsync();

            return departmentDoamin;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await orgDbContext.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(Guid id)
        {
            return await orgDbContext.Departments.FindAsync(id);
            //return await orgDbContext.Departments.Where(department => department.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<Department?> UpdateAsync(Guid id, Department department)
        {
            var departmentDoamin = await GetByIdAsync(id);
            if (departmentDoamin == null)
            {
                return null;
            }

            departmentDoamin.Description = department.Description;

            await orgDbContext.SaveChangesAsync();
            return departmentDoamin;
        }
    }
}
