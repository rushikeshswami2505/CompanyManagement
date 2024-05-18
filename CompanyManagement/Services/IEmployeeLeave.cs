using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Services
{
    public interface IEmployeeLeave
    {
        Task AddNewLeave(EmployeeLeavesModel model);
        /*Task DeleteEmployee(int id);
        Task EditEmployee(EmployeeDetailsModel model);
        Task<List<EmployeeDetails>> GetAllEmployees();
        Task<IEnumerable<EmployeeDetails>> GetAllEmployeesByProjectId(int id);
        Task<EmployeeDetailsModel> GetEmployeeDetailsById(int id);*/
    }
}
