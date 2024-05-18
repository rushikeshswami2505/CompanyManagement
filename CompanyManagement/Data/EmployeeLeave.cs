using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Data
{
    public class EmployeeLeave
    {
        [Key]
        public int employeeLeaveId { get; set; }
        public int empId { get; set; }
        public DateTime leaveStartDate { get; set; }
        public DateTime leaveEndDate { get; set; }
        public string leaveReason { get; set; }
    }
}
