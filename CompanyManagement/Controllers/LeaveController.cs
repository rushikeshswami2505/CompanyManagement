using CompanyManagement.Models;
using CompanyManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ILeaveDetails leaveDetailsServices;
        public LeaveController(ILeaveDetails leaveDetailsServices)
        {
            this.leaveDetailsServices = leaveDetailsServices;
        }
        public async Task<IActionResult> Index()
        {
            var data = await leaveDetailsServices.GetAllLeaves();
            return View(data);
        }

        public IActionResult AddLeave()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddLeave(LeaveDetailsModel model)
        {
            if(ModelState.IsValid) {
                await leaveDetailsServices.AddNewLeave(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> EditLeave(int id)
        {
            LeaveDetailsModel model = await leaveDetailsServices.GetLeaveDetailsById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditLeave(LeaveDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                await leaveDetailsServices.EditLeave(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteLeave(int id)
        {
            await leaveDetailsServices.DeleteLeave(id);
            return RedirectToAction("Index");
        }
    }
}
