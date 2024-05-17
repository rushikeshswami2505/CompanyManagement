using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Services
{
    public interface IEmployeeDetails
    {
        Task AddNewEmployee(EmployeeDetailsModel employeeDetailsModel);
        Task DeleteEmployee(int id);
        Task EditEmployee(EmployeeDetailsModel model);
        Task<List<EmployeeDetails>> GetAllEmployees();
        Task<EmployeeDetailsModel> GetEmployeeDetailsById(int id);
    }
}
