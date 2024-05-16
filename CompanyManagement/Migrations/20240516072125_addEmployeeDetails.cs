using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Migrations
{
    /// <inheritdoc />
    public partial class addEmployeeDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empDob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empBloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empContact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.empId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDetails");
        }
    }
}
