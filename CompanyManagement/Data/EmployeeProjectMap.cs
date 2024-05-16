using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Data
{
    public class EmployeeProjectMap
    {
        [Key]
        public int epId { get; set; }
        public int empId { get; set; }
        public int projectId { get; set; }
    }
}
