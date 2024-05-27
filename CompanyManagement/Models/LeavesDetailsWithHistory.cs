using CompanyManagement.Data;

namespace CompanyManagement.Models
{
    public class LeavesDetailsWithHistory
    {
        public IEnumerable<LeaveDetails> LeavesDetails { get; set; }
        public IEnumerable<EmployeeLeave> LeavesHistory { get; set; }
    }
}
