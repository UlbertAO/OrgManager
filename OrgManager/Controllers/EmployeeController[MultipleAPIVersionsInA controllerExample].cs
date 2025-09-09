//using Asp.Versioning;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace OrgManager.Controllers
//{
//    [Route("api/[controller]")]
//    //[Route("api/v{version:apiVersion}/[controller]")] // use this only when using UrlSegmentApiVersionReader in ApiVersionReader, need to setup swagger to show version selector dropdown
//    [ApiVersion("1.0")]
//    [ApiVersion("2.0")]
//    [ApiController]
//    public class EmployeeController : ControllerBase
//    {
//        private static readonly string[] Employees = new[]
//        { "ulbert", "ainz", "ooan"};
//        private readonly ILogger<EmployeeController> _logger;

//        public EmployeeController(ILogger<EmployeeController> logger)
//        {
//            _logger = logger;
//        }

//        [MapToApiVersion("1.0")]
//        [HttpGet]
//        public IActionResult Get()
//        {
//            return Ok(Employees);
//        }

//        [MapToApiVersion("2.0")]
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var employeesList = new List<Employee>();
//            foreach (var employee in Employees)
//            {
//                employeesList.Add(new Employee { Name = employee });

//            }
//            return Ok(employeesList);
//        }
//    }
//}
