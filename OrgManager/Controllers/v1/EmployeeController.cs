using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OrgManager.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> logger;
        private readonly OrgDbContext orgDbContext;

        public EmployeeController(ILogger<EmployeeController> logger,OrgDbContext orgDbContext)
        {
            this.logger = logger;
            this.orgDbContext = orgDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("ok");
        }
    }
}
