using CompanyManagement.Models;
using CompanyManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeDetails employeeDetailsServices;
        private readonly IRoleDetails roleDetailsServices;
        public EmployeeController(IEmployeeDetails employeeDetailsServices,IRoleDetails roleDetailsServices)
        {
            this.employeeDetailsServices = employeeDetailsServices;
            this.roleDetailsServices = roleDetailsServices;
        }

        public async Task<IActionResult> Index()
        {
            // var data = await employeeDetailsServices.GetAllEmployees();
            var data = await employeeDetailsServices.GetAllEmployeesWithRoles();
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

        [HttpGet]
        public async Task<IActionResult> GetRolesByEmployeeId(int empId)
        {
            List<string> roles = await roleDetailsServices.GetRolesByEmployeeId(empId);
            return Json(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(int empId, int roleId)
        {
            try
            {
                await roleDetailsServices.AssignRoleToEmployee(empId, roleId);
                return Ok("Role assigned successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while assigning the role: " + ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveRole(int empId,int roleId)
        {
            try
            {
                await roleDetailsServices.RemoveRoleFromEmployee(empId, roleId);
                return Ok("Role assigned successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the role: " + ex.Message);
            }
        }

    }
}
