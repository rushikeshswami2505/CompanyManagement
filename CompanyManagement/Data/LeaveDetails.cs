using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Data
{
    public class LeaveDetails
    {
        [Key]
        public int leaveId { get; set; }
        public int empId { get; set; }
        public int leavePaidRemain { get; set; }
        public int leavePaidTaken { get; set; }
        public int leaveLOP { get; set; }
    }
}