using CompanyManagement.Models;
using CompanyManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleDetails roleDetailsServices;
        public RoleController(IRoleDetails roleDetailsServices) {
            this.roleDetailsServices = roleDetailsServices;
        }
        public async Task<IActionResult> Index()
        {
            var data = await roleDetailsServices.GetAllRole();
            return View(data);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                await roleDetailsServices.AddNewRole(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            await roleDetailsServices.DeleteRole(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditRole(int id)
        {
            RoleDetailsModel model = await roleDetailsServices.GetRoleDetailsById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(RoleDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                await roleDetailsServices.EditRole(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
