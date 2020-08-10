using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Data.Dtos;
using EMS.Data.Entities;
using EMS.Services.Interfaces;
using EMS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICommentService _commentService;

        public EmployeeController(IEmployeeService employeeService, ICommentService commentService)
        {
            _employeeService = employeeService;
            _commentService = commentService;
        }


        public IActionResult Index()
        {
            // var partialView = "_Employee.cshtml";
            // var employee = _employeeService.GetAllEmployees().FirstOrDefault(x => x.Id == 1);

            // var employeeModel = new EmployeeViewModel
            // {
            //     Id = employee.Id,
            //     EmployeeName = employee.EmployeeName + id
            // };


            return View();

        }

        public IActionResult GetEmployee(int id)
        {
            EmployeeDto employee = _employeeService.GetEmployeeById(id);
            List<Comment> comments = _commentService.GetActiveCommentsByEmployeeId(id).ToList();

            EmployeeDto manager = _employeeService.GetEmployeeById(employee.LineManager);
            string managerName = String.Empty;

            if (manager != null)
            {
                managerName = manager.EmployeeName;
            }


            var employeeModel = new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeName = employee.EmployeeName,
                EmployeeAddress = employee.EmployeeAddress,
                Department = employee.Department,
                AnnualSalary = employee.AnnualSalary,
                HireDate = employee.HireDate,
                JobTitle = employee.JobTitle,
                LineManager = managerName,
                Salary = employee.Salary,
            };

            List<CommentViewModel> commentsModel = new List<CommentViewModel>();
            foreach (var comment in comments)
            {
                var model = new CommentViewModel
                {
                    Author = comment.Author,
                    CreateDate = comment.CreateDate,
                    Description = comment.Description,
                    EmployeeId = comment.EmployeeId,
                    Id = comment.Id,
                };

                commentsModel.Add(model);
            }

            employeeModel.Comments = commentsModel;

            return View(employeeModel);
        }

        public PartialViewResult GetEmployees(string btn, string name, string departmentName, string title, int monthlySalary, string managerName, DateTime? dateHire)
        {
            var partial = "_Employees";
            List<EmployeeDto> allEmployees = _employeeService.GetAllEmployees().ToList();
            List<EmployeeViewModel> allEmployeesModels = GetEmployeesModel(allEmployees);

            if (btn == "Clear")
            {
                return PartialView(partial, allEmployeesModels);
            }
            else
            {
                var employees = allEmployeesModels;

                if (departmentName != null)
                {
                    employees = employees.Where(x => x.Department == departmentName).ToList();
                }
                if (name != null)
                {
                    employees = employees.Where(x => x.EmployeeName.Contains(name.Trim())).ToList();
                }
                if (title != null)
                {
                    employees = employees.Where(x => x.JobTitle == title).ToList();
                }
                if (monthlySalary > 0)
                {
                    decimal ammount = (decimal)monthlySalary;
                    employees = employees.Where(x => x.Salary == ammount).ToList();
                }
                if (managerName != null)
                {
                    employees = employees.Where(x => x.LineManager == managerName).ToList();
                }
                if (dateHire != null)
                {
                    employees = employees.Where(x => x.HireDate == dateHire).ToList();
                }

                return PartialView(partial, employees);
            }
        }

        private List<EmployeeViewModel> GetEmployeesModel(List<EmployeeDto> allEmployees)
        {
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

            return allEmployeesModels;
        }
    }
}