using CompanyManagement.Models;
using CompanyManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanyManagement.Controllers
{
    public class HomeController : Controller
    {   
        private readonly IEmployeeDetails employeeDetailsServices;
        private readonly IRoleDetails roleDetailsServices;
        public HomeController(IEmployeeDetails employeeDetailsServices,IRoleDetails roleDetailsServices)
        {
            this.employeeDetailsServices = employeeDetailsServices;
            this.roleDetailsServices = roleDetailsServices;
        }
        public async Task<IActionResult> Index()
        {
            var empId = HttpContext.Session.GetInt32("currentUserEmpId");
            List<string> roles = await roleDetailsServices.GetRolesByEmployeeId((int)empId);
            if (roles.Count == 1) HttpContext.Session.SetString("currentUserRole","Partial");
            else HttpContext.Session.SetString("currentUserRole", "Full");
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid) {
                var user = await employeeDetailsServices.GetEmployeeDetailsByEmail(loginModel.empEmail);
                if (user != null)
                {
                    if (user.empPassword == loginModel.empPassword)
                    {
                        HttpContext.Session.SetInt32("currentUserEmpId",user.empId);
                        HttpContext.Session.SetString("currentUserEmpEmail", user.empEmail);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("password", "Incorrect password");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("email", "User does not exist");
                    return View();
                }
            }
            return View();
        }
    }
}
