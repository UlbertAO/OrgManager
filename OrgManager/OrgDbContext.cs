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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region seed data for department
            var departments = new List<Department>{
                new Department
                {
                    Id = Guid.Parse("1becb0c4-4852-46e8-a05d-d46c7cf8e162"),
                    Name = "Data Science",
                    Description="need datascience dev only"

                },new Department
                {
                    Id = Guid.Parse("6ffc9a92-8266-49a0-8d3d-1b47169be295"),
                    Name = "Full Stack",
                    Description="need fullstack dev only"
                },new Department
                {
                    Id = Guid.Parse("c26340d5-41d1-407e-95f3-e970ae41cefe"),
                    Name = "Front End",
                    Description="need frontend dev only"
                },new Department
                {
                    Id = Guid.Parse("7ffd8a16-eb05-429d-a9a5-672229e74443"),
                    Name = "Back End",
                    Description="need backend dev only"
                }
            };

            modelBuilder.Entity<Department>().HasData(departments);

            #endregion

            base.OnModelCreating(modelBuilder);

        }
    }
}
