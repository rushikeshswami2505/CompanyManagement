using CompanyManagement.Data;

namespace CompanyManagement.Models
{
    public class EmployeesWithRole
    {
        public IEnumerable<EmployeeDetails> Employees { get; set; }
        public IEnumerable<RoleDetails> Roles { get; set; }

    }
}