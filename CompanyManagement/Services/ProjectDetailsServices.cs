using CompanyManagement.Data;
using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Services
{
    public class ProjectDetailsServices : IProjectDetails
    {
        private Context db;

        public ProjectDetailsServices(Context context)
        {
            db = context;
        }
        public async Task AddNewProject(ProjectDetailsModel model)
        {
            ProjectDetails projectDetails = ModelToProjectDetails(model);
            await db.ProjectDetails.AddAsync(projectDetails);
            await db.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            var row = await db.ProjectDetails.FindAsync(id);
            if (row == null) return;
            db.ProjectDetails.Remove(row);
            await db.SaveChangesAsync();
        }

        public async Task EditProject(ProjectDetailsModel model)
        {
            ProjectDetails projectDetails = ModelToProjectDetails(model);
            db.Entry(projectDetails).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<List<ProjectDetails>> GetAllProjects()
        {
            return await db.ProjectDetails.ToListAsync();
        }

        public async Task<ProjectDetailsModel> GetProjectDetailsById(int id)
        {
            var row = await db.ProjectDetails.Where(i => i.projectId == id).FirstOrDefaultAsync();
            if (row == null) return null;
            ProjectDetailsModel model = ProjectDetailsToModel(row);
            return model;

        }

        public async Task AddEmployeeToProject(int projectId, int empId)
        {
            var existingRecord = await db.EmployeeProjectMaps.FirstOrDefaultAsync(e => e.empId == empId && e.projectId == projectId);
            if (existingRecord != null)  return;
            EmployeeProjectMap employeeProjectMap = ValuesToEmployeeProjectMap(projectId,empId);     
            await db.EmployeeProjectMaps.AddAsync(employeeProjectMap);
            /*var project = await db.ProjectDetails.FindAsync(projectId);
            if (project != null)
            {
                project.projectNumResource++;
                db.Entry(project).State = EntityState.Modified;
            }*/
            await db.SaveChangesAsync();
        }


        private EmployeeProjectMap ValuesToEmployeeProjectMap(int projectId,int empId)
        {
            EmployeeProjectMap employeeProjectMap = new EmployeeProjectMap();
            employeeProjectMap.empId = empId;
            employeeProjectMap.projectId = projectId;
            return employeeProjectMap;
        }

        private ProjectDetails ModelToProjectDetails(ProjectDetailsModel model)
        {
            ProjectDetails projectDetails = new ProjectDetails();
            projectDetails.projectId = model.projectId;
            projectDetails.projectName = model.projectName;
            projectDetails.projectStartDate = model.projectStartDate;
            projectDetails.projectDueDate = model.projectDueDate;
            projectDetails.projectNumResource = model.projectNumResource;
            return projectDetails;
        }
        private ProjectDetailsModel ProjectDetailsToModel(ProjectDetails projectDetails)
        {
            ProjectDetailsModel model = new ProjectDetailsModel();
            model.projectId = projectDetails.projectId;
            model.projectName = projectDetails.projectName;
            model.projectStartDate = projectDetails.projectStartDate;
            model.projectDueDate = projectDetails.projectDueDate;
            model.projectNumResource = projectDetails.projectNumResource;
            return model;
        }

        public async Task RemoveEmployeeFromProject(int projectId, int empId)
        {
            var employeeProjectMap = 
                await db.EmployeeProjectMaps.FirstOrDefaultAsync(i => i.projectId == projectId && i.empId == empId);
            if (employeeProjectMap == null) return;
            db.EmployeeProjectMaps.Remove(employeeProjectMap);
            /*var project = await db.ProjectDetails.FindAsync(projectId);
            if (project != null)
            {
                project.projectNumResource--;
                db.Entry(project).State = EntityState.Modified;
            }*/
            await db.SaveChangesAsync();
        }

        public Task<List<ProjectDetails>> GetProjectDetailsByEmployeeId(int empId)
        {
            var data = (from projectMap in db.EmployeeProjectMaps
                   join project in db.ProjectDetails
                   on projectMap.projectId equals project.projectId
                   where projectMap.empId == empId
                   select project).ToListAsync();
            return data;
        }
    }
}
