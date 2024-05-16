using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Services
{
    public interface IEmployeeDetails
    {
        void AddNewEmployee(EmployeeDetailsModel employeeDetailsModel);
        void EditEmployee(EmployeeDetailsModel model);
        List<EmployeeDetails> GetAllEmployees();
        EmployeeDetailsModel GetEmployeeDetailsById(int id);
    }
}
