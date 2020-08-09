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
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            // InsertEmployee();

            List<EmployeeDto> allEmployees = _employeeService.GetAllEmployees().ToList();
            List<EmployeeViewModel> allEmployeesModels = new List<EmployeeViewModel>();


            foreach (var employee in allEmployees)
            {
                EmployeeDto manager = _employeeService.GetEmployeeById(employee.LineManager);
                string managerName = String.Empty;

                if (manager != null)
                {
                    managerName = manager.EmployeeName;
                }

                EmployeeViewModel model = new EmployeeViewModel
                {
                    Id = employee.Id,
                    EmployeeName = employee.EmployeeName,
                    Department = employee.Department,
                    EmployeeAddress = employee.EmployeeAddress,
                    HireDate = employee.HireDate,
                    JobTitle = employee.JobTitle,
                    LineManager = managerName,
                    Salary = employee.Salary,
                    AnnualSalary = employee.AnnualSalary
                };

                allEmployeesModels.Add(model);
            }

            return View(allEmployeesModels);
        }

        private void InsertEmployee()
        {
            var salary = decimal.Parse("1550.00");

            Employee employee = new Employee
            {
                Department = "Sales",
                EmployeeAddress = "Some str.2",
                EmployeeName = "Peter Peterson",
                HireDate = DateTime.ParseExact("26.02.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                JobTitle = "Specialist",
                Salary = salary
            };

            int employeeId = _employeeService.Add(employee);

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
