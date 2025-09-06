using Microsoft.EntityFrameworkCore;
using OrgManager.Controllers;
using System;

namespace OrgManager
{
    public class OrgDbContext : DbContext
    {
        public OrgDbContext(DbContextOptions<OrgDbContext> options) : base(options)
        {

        }
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
