using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Models
{
    public class EmployeeProjectMapModel
    {
        [Key]
        public int epId { get; set; }
        [Required]
        public int empId { get; set; }
        [Required]
        public int projectId { get; set; }
    }
}
