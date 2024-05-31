using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Services.Interfaces
{
    public interface IProjectDetails
    {
        Task AddEmployeeToProject(int projectId, int empId);
        Task AddNewProject(ProjectDetailsModel model);
        Task DeleteProject(int id);
        Task EditProject(ProjectDetailsModel model);
        Task<List<ProjectDetails>> GetAllProjects();
        Task<List<ProjectDetails>> GetProjectDetailsByEmployeeId(int empId);
        Task<ProjectDetailsModel> GetProjectDetailsById(int id);
        Task RemoveEmployeeFromProject(int projectId, int empId);
    }
}
