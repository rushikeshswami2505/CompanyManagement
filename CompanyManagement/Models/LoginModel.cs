using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Employee Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string empEmail { get; set; }

        [Required(ErrorMessage = "Employee Password is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Password must be at least 4 characters long")]
        // [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).+$", ErrorMessage = "Password must have at least one uppercase letter, one lowercase letter, one digit, and one special character")]
        public string empPassword { get; set; }
    }
}
