using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrgManager.DTOs.Department;
using OrgManager.Entities;

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

            var departmentsDto = departments.Select(department => new DepartmentGetAllResponse { Name = department.Name, Description = department.Description });

            //var departmentsDto = new List<DepartmentGetAllResponse>();
            //foreach (var department in departments)
            //{
            //    departmentsDto.Add(new DepartmentGetAllResponse
            //    {
            //        Name = department.Name,
            //        Description = department.Description
            //    });
            //}

            return Ok(departmentsDto);
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
            var departmentDto = new DepartmentGetByIdResponse
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            };
            return Ok(departmentDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateRequest departmentDto)
        {
            if (departmentDto == null)
            {
                return BadRequest();
            }

            var department = new Department
            {
                Name = departmentDto.Name,
                Description = departmentDto.Description
            };

            await orgDbContext.Departments.AddAsync(department);
            await orgDbContext.SaveChangesAsync();

            var departmentResponseDto = new DepartmentGetByIdResponse
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            };

            //return Ok(departmentData);
            return CreatedAtAction(nameof(GetById), new { Id = department.Id }, departmentResponseDto);
        }

        [HttpPut("{Id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] DepartmentUpdateRequest departmentDto)
        {
            var department = await orgDbContext.Departments.FindAsync(Id);
            if (department == null)
            {
                return NotFound();
            }
            department.Description = departmentDto.Description;

            await orgDbContext.SaveChangesAsync();

            var departmentResponseDto = new DepartmentGetByIdResponse
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            };

            return Ok(departmentResponseDto);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var department = await orgDbContext.Departments.FindAsync(Id);
            if (department == null)
            {
                return NotFound();

            }
            var departmentDomain = orgDbContext.Departments.Remove(department);
            await orgDbContext.SaveChangesAsync();

            var departmentResponseDto = new DepartmentGetByIdResponse
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description
            };

            return Ok(department);
        }
    }
}
