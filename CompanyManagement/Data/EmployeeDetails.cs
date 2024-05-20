using System.ComponentModel.DataAnnotations;
namespace CompanyManagement.Data
{
    public class EmployeeDetails
    {
        [Key]
        public int empId{ get; set; }
        public string empName { get; set; }
        public string empEmail { get; set; }
        public DateTime empDob { get; set; }
        public string empCity { get; set; }
        public string empState { get; set; }
        public string empCountry { get; set; }
        public string empBloodGroup { get; set; }
        public string empContact { get; set; }
        public string empPassword { get; set; }
    }
}
