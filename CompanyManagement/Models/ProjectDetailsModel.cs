using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Models
{
    public class ProjectDetailsModel
    {
        [Key]
        public int projectId { get; set; }

        [Required(ErrorMessage = "Project Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Project Name must be between 3 and 20 characters")]
        public string projectName { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.Date)]
        public DateTime projectStartDate { get; set; }

        [Required(ErrorMessage = "Due Date is required")]
        [DataType(DataType.Date)]
        public DateTime projectDueDate { get; set; }

        [Required(ErrorMessage = "Number of Resources is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of Resources must be a positive number")]
        public int projectNumResource { get; set; }
    }
}
