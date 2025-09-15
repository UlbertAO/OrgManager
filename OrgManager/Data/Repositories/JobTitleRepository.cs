using Microsoft.EntityFrameworkCore;
using OrgManager.Data.Repositories.Interfaces;
using OrgManager.Entities;

namespace OrgManager.Data.Repositories
{
    public class JobTitleRepository : IJobTitleRepository
    {
        private readonly OrgDbContext orgDbContext;

        public JobTitleRepository(OrgDbContext orgDbContext)
        {
            this.orgDbContext = orgDbContext;
        }

        public Task CustomJobTitleServiceMethod()
        {
            throw new NotImplementedException();
        }
    }
}