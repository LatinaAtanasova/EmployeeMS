using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EMS.Web.Models;
using EMS.Data.Repository;
using EMS.Data.Entities;
using System.Globalization;
using EMS.Services.Interfaces;
using EMS.Data.Dtos;

namespace EMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _logger = logger;
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            SearchModel model = new SearchModel();

            model.Departments = _departmentService.GetDepartments().ToList();
            model.Titles = _employeeService.GetAllEmployees().Select(x => x.JobTitle).Distinct().ToList();
            model.Managers = _employeeService.GetManagers().ToList();


            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
