using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Migrations
{
    /// <inheritdoc />
    public partial class changesCapilized : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_employeeRoleMaps",
                table: "employeeRoleMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employeeProjectMaps",
                table: "employeeProjectMaps");

            migrationBuilder.RenameTable(
                name: "employeeRoleMaps",
                newName: "EmployeeRoleMaps");

            migrationBuilder.RenameTable(
                name: "employeeProjectMaps",
                newName: "EmployeeProjectMaps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRoleMaps",
                table: "EmployeeRoleMaps",
                column: "erId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeProjectMaps",
                table: "EmployeeProjectMaps",
                column: "epId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRoleMaps",
                table: "EmployeeRoleMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeProjectMaps",
                table: "EmployeeProjectMaps");

            migrationBuilder.RenameTable(
                name: "EmployeeRoleMaps",
                newName: "employeeRoleMaps");

            migrationBuilder.RenameTable(
                name: "EmployeeProjectMaps",
                newName: "employeeProjectMaps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeeRoleMaps",
                table: "employeeRoleMaps",
                column: "erId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeeProjectMaps",
                table: "employeeProjectMaps",
                column: "epId");
        }
    }
}
