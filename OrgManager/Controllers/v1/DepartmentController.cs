using Asp.Versioning;
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
        public IActionResult Get()
        {
            return Ok(Departments);
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
    }
}
