using Asp.Versioning;
using AutoMapper;
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
        private readonly ILogger<DepartmentController> _logger;
        private readonly OrgDbContext orgDbContext;
        private readonly IMapper mapper;

        public DepartmentController(ILogger<DepartmentController> logger, OrgDbContext orgDbContext, IMapper mapper)
        {
            _logger = logger;
            this.orgDbContext = orgDbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await orgDbContext.Departments.ToListAsync();

            var departmentsDto = mapper.Map<List<DepartmentGetAllResponse>>(departments);

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
            var departmentDto = mapper.Map<DepartmentGetByIdResponse>(department); 

            return Ok(departmentDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateRequest departmentDto)
        {
            if (departmentDto == null)
            {
                return BadRequest();
            }
           
            var department = mapper.Map<Department>(departmentDto);

            await orgDbContext.Departments.AddAsync(department);
            await orgDbContext.SaveChangesAsync();

            var departmentResponseDto = mapper.Map<DepartmentGetByIdResponse>(department);

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

            mapper.Map(departmentDto, department);

            await orgDbContext.SaveChangesAsync();

            var departmentResponseDto = mapper.Map<DepartmentGetByIdResponse>(department);

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

            var departmentResponseDto = mapper.Map<DepartmentGetByIdResponse>(department);

            return Ok(department);
        }
    }
}
