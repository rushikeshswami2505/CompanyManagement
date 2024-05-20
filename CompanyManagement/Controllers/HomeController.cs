using CompanyManagement.Models;
using CompanyManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanyManagement.Controllers
{
    public class HomeController : Controller
    {   
        private readonly IEmployeeDetails employeeDetailsServices;
        public HomeController(IEmployeeDetails employeeDetailsServices)
        {
            this.employeeDetailsServices = employeeDetailsServices;
        }
        public IActionResult Index()
        {
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
