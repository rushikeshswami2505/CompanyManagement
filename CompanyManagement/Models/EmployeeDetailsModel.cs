using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Models
{
    public class EmployeeDetailsModel
    {
        [Key]
        public int empId { get; set; }
        [Required]
        public string empName { get; set; }
        [Required]
        public DateTime empDob { get; set; }
        [Required]  
        public string empCity { get; set; }
        [Required]
        public string empState { get; set; }
        [Required]
        public string empCountry { get; set; }
        [Required]
        public string empBloodGroup { get; set; }
        [Required]
        public string empContact { get; set; }
    }
}
