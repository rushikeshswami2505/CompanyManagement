using CompanyManagement.Models;
using CompanyManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanyManagement.Controllers
{
    public class HomeController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
    }
}
