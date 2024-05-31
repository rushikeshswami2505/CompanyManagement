using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Services.Interfaces
{
    public interface ILeaveDetails
    {
        Task AddNewLeave(LeaveDetailsModel model);
        Task DeleteLeave(int id);
        Task EditLeave(LeaveDetailsModel model);
        Task<List<LeaveDetails>> GetAllLeavesDetails();
        Task<LeaveDetailsModel> GetLeaveDetailsByEmpId(int empId);
        Task<LeaveDetailsModel> GetLeaveDetailsByLeaveId(int id);
    }
}
