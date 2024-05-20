using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Migrations
{
    /// <inheritdoc />
    public partial class addedEmailPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "empEmail",
                table: "EmployeeDetailsModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "empPassword",
                table: "EmployeeDetailsModel",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "empEmail",
                table: "EmployeeDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "empPassword",
                table: "EmployeeDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "empEmail",
                table: "EmployeeDetailsModel");

            migrationBuilder.DropColumn(
                name: "empPassword",
                table: "EmployeeDetailsModel");

            migrationBuilder.DropColumn(
                name: "empEmail",
                table: "EmployeeDetails");

            migrationBuilder.DropColumn(
                name: "empPassword",
                table: "EmployeeDetails");
        }
    }
}
