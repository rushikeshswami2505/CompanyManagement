using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Services
{
    public interface ILeaveDetails
    {
        Task AddNewLeave(LeaveDetailsModel model);
        Task DeleteLeave(int id);
        Task EditLeave(LeaveDetailsModel model);
        Task<List<LeaveDetails>> GetAllLeaves();
        Task<LeaveDetailsModel> GetLeaveDetailsById(int id);
    }
}
