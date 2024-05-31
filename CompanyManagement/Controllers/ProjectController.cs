using CompanyManagement.Data;
using CompanyManagement.Models;
using CompanyManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace CompanyManagement.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectDetails projectDetailsServices;
        private readonly IEmployeeDetails employeeDetailsServices;
        public ProjectController(IProjectDetails projectDetailsServices,IEmployeeDetails employeeDetailsServices)
        {
            this.projectDetailsServices = projectDetailsServices;
            this.employeeDetailsServices = employeeDetailsServices;
        }
        public async Task<IActionResult> Index()
        {
            var userRole = HttpContext.Session.GetString("currentUserRole");
            ViewBag.UserRole = userRole;
            if (userRole == "Employee" || userRole == "Junior" || userRole == "Senior" || userRole == "Manager")
            {
                var empId =  HttpContext.Session.GetInt32("currentUserEmpId");
                var data = await projectDetailsServices.GetProjectDetailsByEmployeeId((int)empId);
                return View(data);
            }
            else
            {
                var data = await projectDetailsServices.GetAllProjects();
                return View(data);
            }
        }

        public IActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectDetailsModel model)
        {
            model.projectNumResource = 0;
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

        public async Task<IActionResult> ResourcesProject(int id)
        {
            ProjectDetailsModel project = await projectDetailsServices.GetProjectDetailsById(id);
            var employees = await employeeDetailsServices.GetAllEmployeesByProjectId(id);

            var viewModel = new ProjectWithEmployees
            {
                Project = project,
                Employees = employees
            };
            // ViewBag.userRole = HttpContext.Session.GetString("currentUserRole");
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewEmployeeToProject(int projectId, int empId)
        {
            if (ModelState.IsValid)
            {
                await projectDetailsServices.AddEmployeeToProject(projectId,empId);
            }

            ProjectDetailsModel project = await projectDetailsServices.GetProjectDetailsById(projectId);
            var employees = await employeeDetailsServices.GetAllEmployeesByProjectId(projectId);

            var viewModel = new ProjectWithEmployees
            {
                Project = project,
                Employees = employees
            };
            ViewBag.projectId = projectId;
            ViewBag.empId = empId;

            return View("ResourcesProject", viewModel);
        }

        public async Task<IActionResult> RemoveEmployeeFromProject(int projectId, int empId)
        {
            await projectDetailsServices.RemoveEmployeeFromProject(projectId, empId);

            ProjectDetailsModel project = await projectDetailsServices.GetProjectDetailsById(projectId);
            var employees = await employeeDetailsServices.GetAllEmployeesByProjectId(projectId);

            var viewModel = new ProjectWithEmployees
            {
                Project = project,
                Employees = employees
            };
            ViewBag.projectId = projectId;
            ViewBag.empId = empId;

            return View("ResourcesProject", viewModel);
        }

    }
}
