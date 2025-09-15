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

        public Task CustomDepartmentServiceMethod()
        {
            throw new NotImplementedException();
        }
    }
}
