using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OrgManager.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")] // use this only when using UrlSegmentApiVersionReader in ApiVersionReader, need to setup swagger to show version selector dropdown
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private static readonly string[] Departments = new[]
        { "Engineering", "Data Science", "Human Resource"};
        private readonly ILogger<DepartmentController> _logger;
        private readonly OrgDbContext orgDbContext;

        public DepartmentController(ILogger<DepartmentController> logger, OrgDbContext orgDbContext)
        {
            _logger = logger;
            this.orgDbContext = orgDbContext;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await orgDbContext.Departments.ToListAsync();
            return Ok(departments);
        }

        [HttpGet("{Id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var department = await orgDbContext.Departments.FindAsync(Id);
            //var department = await orgDbContext.Departments.Where(department => department.Id == Id).FirstOrDefaultAsync();

            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }
            await orgDbContext.Departments.AddAsync(department);
            await orgDbContext.SaveChangesAsync();

            //return Ok(departmentData);
            return CreatedAtAction(nameof(GetById), new { Id = department.Id }, department);
        }

        [HttpPut("{Id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] Department department)
        {
            var departmentData = await orgDbContext.Departments.FindAsync(Id);
            if (departmentData == null)
            {
                return NotFound();
            }
            departmentData.Name = department.Name;
            departmentData.Description = department.Description;
            await orgDbContext.SaveChangesAsync();

            return Ok(departmentData);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var departmentData = await orgDbContext.Departments.FindAsync(Id);
            if (departmentData == null)
            {
                return NotFound();

            }
            var departmentDomain = orgDbContext.Departments.Remove(departmentData);
            await orgDbContext.SaveChangesAsync();

            return Ok(departmentData);
        }
    }
}
