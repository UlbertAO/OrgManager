using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using OrgManager.DTOs.Department;
using OrgManager.Services;

namespace OrgManager.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")] // use this only when using UrlSegmentApiVersionReader in ApiVersionReader, need to setup swagger to show version selector dropdown
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly DepartmentService departmentService;

        public DepartmentController(ILogger<DepartmentController> logger, DepartmentService departmentService)
        {
            _logger = logger;
            this.departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentGetAllResponse>>> GetAll()
        {
            var departments = await departmentService.GetAllDepartmentsAsync();

            return Ok(departments);
        }

        [HttpGet("{Id:Guid}")]
        public async Task<ActionResult<DepartmentGetByIdResponse>> GetById([FromRoute] Guid Id)
        {
            var department = await departmentService.GetDepartmentByIdAsync(Id);

            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentGetByIdResponse>> Create([FromBody] DepartmentCreateRequest departmentDto)
        {
            var department = await departmentService.CreateDepartmentAsync(departmentDto);

            if (departmentDto == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { Id = department.Id }, department);
        }

        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult<DepartmentGetByIdResponse>> Update([FromRoute] Guid Id, [FromBody] DepartmentUpdateRequest departmentDto)
        {
            var department = await departmentService.UpdateDepartmentAsync(Id, departmentDto);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult<DepartmentGetByIdResponse>> Delete([FromRoute] Guid Id)
        {
            var department = await departmentService.DeleteDepartmentAsync(Id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
    }
}
