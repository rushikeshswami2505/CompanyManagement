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
    }
}
