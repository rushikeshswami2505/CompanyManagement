using CompanyManagement.Models;
using CompanyManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeDetails _employeeDetailsServices;
        public EmployeeController(IEmployeeDetails employeeDetailsServices)
        {
            _employeeDetailsServices = employeeDetailsServices;
        }

        public IActionResult Index()
        {
            var data = _employeeDetailsServices.GetAllEmployees();
            return View(data);
        }

        public IActionResult AddEmployee() {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                _employeeDetailsServices.AddNewEmployee(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteEmployee()
        {
            return View();
        }

        public IActionResult EditEmployee(int id)
        {
            EmployeeDetailsModel model = _employeeDetailsServices.GetEmployeeDetailsById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditEmployee(EmployeeDetailsModel model)
        {
            if (ModelState.IsValid) {
                _employeeDetailsServices.EditEmployee(model);
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}
