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

        [HttpGet("dttm")]
        public IActionResult GetDttm()
        {
            var dttm = orgDbContext.Database
                .SqlQueryRaw<DateTime>("SELECT NOW()")
                .AsEnumerable()
                .FirstOrDefault();
            return Ok(dttm);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = orgDbContext.Departments.ToList();
            return Ok(departments);
        }

        [HttpGet("{Id:Guid}")]
        public IActionResult GetById([FromRoute] Guid Id)
        {
            var department = orgDbContext.Departments.Find(Id);
            //var department = orgDbContext.Departments.Where(department => department.Id == Id).FirstOrDefault();

            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }
            orgDbContext.Departments.Add(department);
            orgDbContext.SaveChanges();

            //return Ok(departmentData);
            return CreatedAtAction(nameof(GetById), new { Id = department.Id }, department);
        }

        [HttpPut("{Id:Guid}")]
        public IActionResult Update([FromRoute] Guid Id, [FromBody] Department department)
        {
            var departmentData = orgDbContext.Departments.Find(Id);
            if (departmentData == null)
            {
                return NotFound();
            }
            departmentData.Name = department.Name;
            departmentData.Description = department.Description;
            orgDbContext.SaveChanges();

            return Ok(departmentData);
        }

        [HttpDelete("{Id:Guid}")]
        public IActionResult Delete([FromRoute] Guid Id)
        {
            var departmentData = orgDbContext.Departments.Find(Id);
            if (departmentData == null)
            {
                return NotFound();

            }
            var departmentDomain = orgDbContext.Departments.Remove(departmentData);
            orgDbContext.SaveChangesAsync();

            return Ok(departmentData);
        }
    }
}
