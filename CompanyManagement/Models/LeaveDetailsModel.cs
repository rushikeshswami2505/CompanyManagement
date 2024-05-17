using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Models
{
    public class LeaveDetailsModel
    {
        [Key]
        public int leaveId { get; set; }
        [Required]
        public int empId { get; set; }
        [Required]
        public int leavePaidRemain { get; set; }
        [Required]
        public int leavePaidTaken { get; set; }
        [Required]
        public int leaveLOP { get; set; }
    }
}
