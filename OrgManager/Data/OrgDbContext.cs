using Microsoft.EntityFrameworkCore;
using OrgManager.Entities;
using System;

namespace OrgManager
{
    public class OrgDbContext : DbContext
    {
        public OrgDbContext(DbContextOptions<OrgDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }

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

            #region seed data for job titles
            var jobTitles = new List<JobTitle>
            {
                new JobTitle
                {
                    Id = Guid.Parse("2da23649-4f66-4ec4-8623-e9d009aecbd1"),
                    Title = "Software Engineer",
                    Description = "Develops and maintains software applications",
                    MinSalary = 75000M,
                    MaxSalary = 150000M,
                },
                new JobTitle
                {
                    Id = Guid.Parse("4622e91c-8569-43ce-bcb0-3b417cee0d77"),
                    Title = "Senior Software Engineer",
                    Description = "Leads software development projects and mentors junior developers",
                    MinSalary = 100000M,
                    MaxSalary = 180000M,
                },
                new JobTitle
                {
                    Id = Guid.Parse("15f7d068-66d9-4b83-a0b9-4f4db8ffd5a2"),
                    Title = "Technical Lead",
                    Description = "Provides technical leadership and architecture guidance",
                    MinSalary = 120000M,
                    MaxSalary = 200000M,
                }
            };

            modelBuilder.Entity<JobTitle>().HasData(jobTitles);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
