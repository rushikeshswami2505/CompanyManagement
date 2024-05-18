using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Models
{
    public class EmployeeLeavesModel
    {
        [Key]
        public int employeeLeaveId { get; set; }
        [Required]
        public int empId { get; set; }
        [Required]
        public DateTime leaveStartDate { get; set; }
        [Required]
        public DateTime leaveEndDate { get; set; }
        [Required]
        public string leaveReason { get; set; }
    }
}
