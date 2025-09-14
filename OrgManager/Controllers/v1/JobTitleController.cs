using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using OrgManager.DTOs.JobTitle;
using OrgManager.Entities;
using OrgManager.Services;

namespace OrgManager.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class JobTitleController : ControllerBase
    {
        private readonly ILogger<JobTitleController> _logger;
        private readonly JobTitleService jobTitleService;

        public JobTitleController(ILogger<JobTitleController> logger, JobTitleService jobTitleService)
        {
            _logger = logger;
            this.jobTitleService = jobTitleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobTitleGetAllResponse>>> GetAll()
        {
            var jobTitles = await jobTitleService.GetAllJobTitlesAsync();
            return Ok(jobTitles);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<JobTitleGetByIdResponse>> GetById([FromRoute]Guid id)
        {
            var jobTitle = await jobTitleService.GetJobTitleByIdAsync(id);
            if (jobTitle == null)
            {
                return NotFound();
            }
            return Ok(jobTitle);
        }

        [HttpPost]
        public async Task<ActionResult<JobTitleGetByIdResponse>> Create([FromBody] JobTitleCreateRequest jobTitleDto)
        {
            var jobTitle = await jobTitleService.CreateJobTitleAsync(jobTitleDto);
            if (jobTitle == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new { id = jobTitle.Id }, jobTitle);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<JobTitleGetByIdResponse>> Update(Guid id, JobTitleUpdateRequest jobTitleDto)
        {
            var jobTitle = await jobTitleService.UpdateJobTitleAsync(id, jobTitleDto);
            if (jobTitle == null)
            {
                return NotFound();
            }

            return Ok(jobTitle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<JobTitleGetByIdResponse>> Delete(Guid id)
        {
            var jobTitle = await jobTitleService.DeleteJobTitleAsync(id);
            if (jobTitle == null)
            {
                return NotFound();
            }
            return Ok(jobTitle);
        }
    }
}