using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Migrations
{
    /// <inheritdoc />
    public partial class addedEmailPassword1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDetailsModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeDetailsModel",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empBloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empCity = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    empContact = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    empCountry = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    empDob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    empPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    empState = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetailsModel", x => x.empId);
                });
        }
    }
}
