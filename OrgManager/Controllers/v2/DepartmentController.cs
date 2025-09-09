using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrgManager.Entities;

namespace OrgManager.Controllers.v2
{
    [ApiVersion("2.0")]
    //[Route("api/v{version:apiVersion}/[controller]")] // use this only when using UrlSegmentApiVersionReader in ApiVersionReader, need to setup swagger to show version selector dropdown
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private static readonly string[] Departments = new[]
        { "Engineering", "Data Science", "Human Resource"};
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var departmentList = new List<Department>();
            foreach (var department in Departments)
            {
                departmentList.Add(new Department { Name = department });

            }
            return Ok(departmentList);
        }
    }
}
