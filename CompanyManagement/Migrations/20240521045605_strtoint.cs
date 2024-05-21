﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Migrations
{
    /// <inheritdoc />
    public partial class strtoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "roleId",
                table: "EmployeeRoleMaps",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "roleId",
                table: "EmployeeRoleMaps",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
