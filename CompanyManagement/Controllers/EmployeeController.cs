using CompanyManagement.Models;
using CompanyManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeDetails employeeDetailsServices;
        public EmployeeController(IEmployeeDetails employeeDetailsServices)
        {
            this.employeeDetailsServices = employeeDetailsServices;
        }

        public async Task<IActionResult> Index()
        {
            var data = await employeeDetailsServices.GetAllEmployees();
            return View(data);
        }

        public IActionResult AddEmployee() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeDetailsServices.AddNewEmployee(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await employeeDetailsServices.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditEmployee(int id)
        {
            EmployeeDetailsModel model = await employeeDetailsServices.GetEmployeeDetailsById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeDetailsModel model)
        {
            if (ModelState.IsValid) {
                await employeeDetailsServices.EditEmployee(model);
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}
