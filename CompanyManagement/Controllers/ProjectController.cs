using CompanyManagement.Models;
using CompanyManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectDetails projectDetailsServices;
        public ProjectController(IProjectDetails projectDetailsServices)
        {
            this.projectDetailsServices = projectDetailsServices;
        }
        public async Task<IActionResult> Index()
        {
            var data = await projectDetailsServices.GetAllProjects();
            return View(data);
        }

        public IActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                await projectDetailsServices.AddNewProject(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<IActionResult> DeleteProject(int id)
        {
            await projectDetailsServices.DeleteProject(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditProject(int id)
        {
            ProjectDetailsModel model = await projectDetailsServices.GetProjectDetailsById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProject(ProjectDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                await projectDetailsServices.EditProject(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
