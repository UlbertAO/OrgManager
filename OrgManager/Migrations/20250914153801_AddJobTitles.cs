using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrgManager.Migrations
{
    /// <inheritdoc />
    public partial class AddJobTitles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MinSalary = table.Column<decimal>(type: "numeric", nullable: false),
                    MaxSalary = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "Id", "Description", "MaxSalary", "MinSalary", "Title" },
                values: new object[,]
                {
                    { new Guid("15f7d068-66d9-4b83-a0b9-4f4db8ffd5a2"), "Provides technical leadership and architecture guidance", 200000m, 120000m, "Technical Lead" },
                    { new Guid("2da23649-4f66-4ec4-8623-e9d009aecbd1"), "Develops and maintains software applications", 150000m, 75000m, "Software Engineer" },
                    { new Guid("4622e91c-8569-43ce-bcb0-3b417cee0d77"), "Leads software development projects and mentors junior developers", 180000m, 100000m, "Senior Software Engineer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobTitles");
        }
    }
}
