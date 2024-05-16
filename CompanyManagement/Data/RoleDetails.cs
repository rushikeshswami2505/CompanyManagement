using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Data
{
    public class RoleDetails
    {
        [Key]
        public int roleId { get; set; }
        public string roleName { get; set; }
    }
}
