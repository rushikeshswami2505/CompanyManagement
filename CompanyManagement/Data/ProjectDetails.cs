using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Data
{
    public class ProjectDetails
    {
        [Key]
        public int projectId { get; set; }
        public string projectName { get; set; }
        public DateTime projectStartDate { get; set; }
        public DateTime projectDueDate { get; set; }
        public int projectNumResource { get; set; }
    }
}
