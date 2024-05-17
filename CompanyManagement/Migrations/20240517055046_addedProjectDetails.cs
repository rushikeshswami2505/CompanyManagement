using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Migrations
{
    /// <inheritdoc />
    public partial class addedProjectDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeDetailsModel",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    empDob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    empCity = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    empState = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    empCountry = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    empBloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empContact = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetailsModel", x => x.empId);
                });

            migrationBuilder.CreateTable(
                name: "employeeProjectMaps",
                columns: table => new
                {
                    epId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empId = table.Column<int>(type: "int", nullable: false),
                    projectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeProjectMaps", x => x.epId);
                });

            migrationBuilder.CreateTable(
                name: "employeeRoleMaps",
                columns: table => new
                {
                    erId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empId = table.Column<int>(type: "int", nullable: false),
                    roleId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeRoleMaps", x => x.erId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveDetails",
                columns: table => new
                {
                    leaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empId = table.Column<int>(type: "int", nullable: false),
                    leavePaidRemain = table.Column<int>(type: "int", nullable: false),
                    leavePaidTaken = table.Column<int>(type: "int", nullable: false),
                    leaveLOP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveDetails", x => x.leaveId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDetails",
                columns: table => new
                {
                    projectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projectDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projectNumResource = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDetails", x => x.projectId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDetailsModel");

            migrationBuilder.DropTable(
                name: "employeeProjectMaps");

            migrationBuilder.DropTable(
                name: "employeeRoleMaps");

            migrationBuilder.DropTable(
                name: "LeaveDetails");

            migrationBuilder.DropTable(
                name: "ProjectDetails");
        }
    }
}
