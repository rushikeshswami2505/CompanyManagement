using Microsoft.EntityFrameworkCore;
using CompanyManagement.Models;

namespace CompanyManagement.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){}
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<ProjectDetails> ProjectDetails { get; set; }
        public DbSet<LeaveDetails> LeaveDetails { get; set; }
        public DbSet<EmployeeProjectMap> employeeProjectMaps { get; set; }
        public DbSet<EmployeeRoleMap> employeeRoleMaps { get; set;}
        public DbSet<CompanyManagement.Models.EmployeeDetailsModel> EmployeeDetailsModel { get; set; } = default!;
    }
}