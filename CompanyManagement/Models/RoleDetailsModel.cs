using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Models
{
    public class RoleDetailsModel
    {
        [Key]
        public int roleId { get; set; }
        [Required]
        public string roleName { get; set; }
    }
}
