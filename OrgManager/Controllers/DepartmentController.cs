//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace OrgManager.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DepartmentController : ControllerBase
//    {
//        private static readonly string[] Departments = new[]
//        { "Engineering", "Data Science", "Human Resource"};
//        private readonly ILogger<DepartmentController> _logger;

//        public DepartmentController(ILogger<DepartmentController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet]
//        public IActionResult Get()
//        {
//            return Ok(Departments);
//        }
//    }
//}
