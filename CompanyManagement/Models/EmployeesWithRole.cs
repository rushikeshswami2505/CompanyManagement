using CompanyManagement.Data;

namespace CompanyManagement.Models
{
    public class EmployeesWithRole
    {
        public EmployeeDetailsModel Employee { get; set; }
        public IEnumerable<RoleDetails> Roles { get; set; }

    }
}