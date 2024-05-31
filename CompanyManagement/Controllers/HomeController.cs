using CompanyManagement.Models;
using CompanyManagement.Services.Interfaces;
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
        public  IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("currentUserEmpId") != null)
            {
                ViewBag.userRole = HttpContext.Session.GetString("currentUserRole");
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View("Login");
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
                        HttpContext.Session.SetString("currentUserName", user.empName);
                        string userRole = "Employee";
                        List<string> roles = await roleDetailsServices.GetRolesByEmployeeId(user.empId);
                        if (roles.Contains("Employee")) userRole = "Employee";
                        if (roles.Contains("Junior")) userRole = "Junior";
                        if (roles.Contains("Senior")) userRole = "Senior";
                        if (roles.Contains("Manager")) userRole = "Manager";
                        if (roles.Contains("Director")) userRole = "Director";
                        if (roles.Contains("HR")) userRole = "HR";
                        if (roles.Contains("CEO")) userRole = "CEO";
                        HttpContext.Session.SetString("currentUserRole", userRole);
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
