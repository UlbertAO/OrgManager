using AutoMapper;
using OrgManager.Data.Repositories.Interfaces;
using OrgManager.DTOs.JobTitle;
using OrgManager.Entities;

namespace OrgManager.Services
{
    public class JobTitleService
    {
        private readonly ILogger<JobTitleService> logger;
        private readonly IJobTitleRepository jobTitleRepository;
        private readonly IMapper mapper;

        public JobTitleService(ILogger<JobTitleService> logger, IJobTitleRepository jobTitleRepository, IMapper mapper)
        {
            this.logger = logger;
            this.jobTitleRepository = jobTitleRepository;
            this.mapper = mapper;
        }

        public async Task<JobTitleGetByIdResponse?> CreateJobTitleAsync(JobTitleCreateRequest jobTitleDto)
        {
            try
            {
                var jobTitle = mapper.Map<JobTitle>(jobTitleDto);
                var createdJobTitle = await jobTitleRepository.AddAsync(jobTitle);
                var jobTitleResponseDto = mapper.Map<JobTitleGetByIdResponse>(createdJobTitle);
                return jobTitleResponseDto;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while creating JobTitle");
                return null;
            }
        }

        public async Task<JobTitleGetByIdResponse?> DeleteJobTitleAsync(Guid id)
        {
            try
            {
                var deletedJobTitle = await jobTitleRepository.DeleteAsync(id);

                var jobTitleResponseDto = mapper.Map<JobTitleGetByIdResponse>(deletedJobTitle);

                return jobTitleResponseDto;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting Jobtitle");
                return null;
            }
        }

        public async Task<List<JobTitleGetAllResponse>?> GetAllJobTitlesAsync()
        {

            try
            {
                var jobTitles = await jobTitleRepository.GetAllAsync();

                var jobTitlesResponseDto = mapper.Map<List<JobTitleGetAllResponse>>(jobTitles);

                return jobTitlesResponseDto;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving all Jobtitle");
                return null;
            }
        }

        public async Task<JobTitleGetByIdResponse> GetJobTitleByIdAsync(Guid id)
        {
            try
            {
                var jobTitle = await jobTitleRepository.GetByIdAsync(id);
                if (jobTitle == null)
                {
                    return null;
                }

                var jobTitleResponseDto = mapper.Map<JobTitleGetByIdResponse>(jobTitle);

                return jobTitleResponseDto;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving jobTitle by Id");
                return null;
            }
        }

        public async Task<JobTitleGetByIdResponse?> UpdateJobTitleAsync(Guid id, JobTitleUpdateRequest jobTitleDto)
        {
            try
            {
                var jobTitle = mapper.Map<JobTitle>(jobTitleDto);

                var updatedJobTitle = await jobTitleRepository.UpdateAsync(id, jobTitle);

                return mapper.Map<JobTitleGetByIdResponse>(updatedJobTitle);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating jobTitle");
                return null;
            }
        }
    }
}