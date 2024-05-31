using CompanyManagement.Data;
using CompanyManagement.Models;
using CompanyManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ILeaveDetails leaveDetailsServices;
        private readonly IEmployeeLeave employeeLeaveServices;
        public LeaveController(ILeaveDetails leaveDetailsServices, IEmployeeLeave employeeLeaveServices)
        {
            this.leaveDetailsServices = leaveDetailsServices;
            this.employeeLeaveServices = employeeLeaveServices;
        }
        public async Task<IActionResult> Index()
        {
            LeavesDetailsWithHistory data = new LeavesDetailsWithHistory();
            var userRole = HttpContext.Session.GetString("currentUserRole");
            ViewBag.userRole = userRole;
            if (userRole == "Employee" || userRole == "Junior" || userRole == "Senior" || userRole == "Manager")
            {
                var empId = HttpContext.Session.GetInt32("currentUserEmpId");
                var leaveHistory = await employeeLeaveServices.GetAllLeaveHistoryById((int)empId);
                LeaveDetailsModel leaveInfoById = await leaveDetailsServices.GetLeaveDetailsByEmpId((int)empId);
                if(leaveInfoById!=null) ViewBag.leaveInfo = leaveInfoById;
                data.LeavesHistory = leaveHistory;
            }
            else
            {
                var leaveDetails = await leaveDetailsServices.GetAllLeavesDetails();
                data.LeavesDetails = leaveDetails;
            }
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
            LeaveDetailsModel model = await leaveDetailsServices.GetLeaveDetailsByLeaveId(id);
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

        public IActionResult ApplyLeave()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ApplyLeave(EmployeeLeavesModel model)
        {
            var empId = HttpContext.Session.GetInt32("currentUserEmpId");
            model.empId = (int)empId;

            if (ModelState.IsValid)
            {
                await employeeLeaveServices.AddNewLeave(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
