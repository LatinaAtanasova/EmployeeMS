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
    }
}