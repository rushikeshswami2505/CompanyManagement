using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Services
{
    public interface IRoleDetails
    {
        Task AddNewRole(RoleDetailsModel model);
        Task AssignRoleToEmployee(int empId, int roleId);
        Task DeleteRole(int id);
        Task EditRole(RoleDetailsModel model);
        Task<List<RoleDetails>> GetAllRole();
        Task<RoleDetailsModel> GetRoleDetailsById(int id);
        Task<List<string>> GetRolesByEmployeeId(int empId);
        Task RemoveRoleFromEmployee(int empId, int roleId);
    }
}
