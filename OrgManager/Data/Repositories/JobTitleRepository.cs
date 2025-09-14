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
        public async Task<JobTitle> AddAsync(JobTitle jobTitle)
        {
            await orgDbContext.JobTitles.AddAsync(jobTitle);
            await orgDbContext.SaveChangesAsync();
            return jobTitle;
        }

        public async Task<JobTitle?> DeleteAsync(Guid id)
        {
            var jobTitle = await orgDbContext.JobTitles.FindAsync(id);
            if (jobTitle == null)
            {
                return null;
            }
            orgDbContext.JobTitles.Remove(jobTitle);
            await orgDbContext.SaveChangesAsync();
            return jobTitle;
        }

        public async Task<List<JobTitle>> GetAllAsync()
        {
            return await orgDbContext.JobTitles.ToListAsync();
        }

        public async Task<JobTitle?> GetByIdAsync(Guid id)
        {
            return await orgDbContext.JobTitles.FindAsync(id);
        }


        public async Task<JobTitle?> UpdateAsync(Guid id, JobTitle jobTitle)
        {
            var existingJobTitle = await GetByIdAsync(id);
            if (existingJobTitle == null)
            {
                return null;
            }

            existingJobTitle.Title = jobTitle.Title;
            existingJobTitle.Description = jobTitle.Description;

            await orgDbContext.SaveChangesAsync();
            return existingJobTitle;
        }

    }
}