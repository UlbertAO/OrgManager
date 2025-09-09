using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrgManager.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1becb0c4-4852-46e8-a05d-d46c7cf8e162"), "need datascience dev only", "Data Science" },
                    { new Guid("6ffc9a92-8266-49a0-8d3d-1b47169be295"), "need fullstack dev only", "Full Stack" },
                    { new Guid("7ffd8a16-eb05-429d-a9a5-672229e74443"), "need backend dev only", "Back End" },
                    { new Guid("c26340d5-41d1-407e-95f3-e970ae41cefe"), "need frontend dev only", "Front End" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("1becb0c4-4852-46e8-a05d-d46c7cf8e162"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("6ffc9a92-8266-49a0-8d3d-1b47169be295"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7ffd8a16-eb05-429d-a9a5-672229e74443"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c26340d5-41d1-407e-95f3-e970ae41cefe"));
        }
    }
}
