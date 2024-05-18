using CompanyManagement.Data;

namespace CompanyManagement.Models
{
    public class ProjectWithEmployees
    {
        public ProjectDetailsModel Project { get; set; }
        public IEnumerable<EmployeeDetails> Employees { get; set; }
    }
}
