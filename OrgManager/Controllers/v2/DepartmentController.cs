using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrgManager.Controllers.v2
{
    [Route("api/v2/[controller]")]
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
