using EMS.Data;
using EMS.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Middleware
{
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, EMSDbContext dbContext)
        {
            if (!dbContext.Departments.Any())
            {
                await this.SeedDepartments(dbContext);
            }

            if (!dbContext.Employees.Any())
            {
                await this.SeedEmployees(dbContext);
            }

            if (!dbContext.Comments.Any())
            {
                await this.SeedComments(dbContext);
            }
            await this.next(context);
        }

        private async Task SeedComments(EMSDbContext dbContext)
        {
            List<Comment> comments = new List<Comment>();

            comments.AddRange(new List<Comment>
            {
                new Comment {
                     Author = "Peter Jackson",
                     Description = "Promoted for expert",
                      EmployeeId = 2,
                       isDeleted = false
                },
                                new Comment {
                     Author = "Anne Hughes",
                     Description = "Promoted for expert",
                      EmployeeId = 2,
                       isDeleted = false
                },
                                                new Comment {
                     Author = "Kelly Somesmith",
                     Description = "Keep task deadlines",
                      EmployeeId = 4,
                       isDeleted = false
                },
            });

            await dbContext.Comments.AddRangeAsync(comments);
            await dbContext.SaveChangesAsync();
        }

        private async Task SeedEmployees(EMSDbContext dbContext)
        {
            List<Employee> employees = new List<Employee>();

            employees.AddRange(new List<Employee>
            {
                new Employee {
                      EmployeeName = "Peter Peterson",
                      EmployeeAddress = "Some str.2",
                      DepartmentId = 1,
                      HireDate =  DateTime.ParseExact("26.02.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                      JobTitle = "Director",
                      Salary = decimal.Parse("5000.00"),
                      isActive = true
                },
                new Employee
                {
                       EmployeeName = "John Anderson",
                       EmployeeAddress = "Some str.3",
                       DepartmentId = 1,
                       HireDate =  DateTime.ParseExact("01.03.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                       JobTitle = "Specialist",
                       Salary = decimal.Parse("2000.00"),
                       LineManager = 1,
                       isActive = true
                },
                new Employee
                {
                       EmployeeName = "Sara Clarckson",
                       EmployeeAddress = "Some str.4",
                       DepartmentId = 2,
                       HireDate =  DateTime.ParseExact("01.03.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                       JobTitle = "Director",
                       Salary = decimal.Parse("5000.00"),
                       isActive = true
                },

                   new Employee
                {
                       EmployeeName = "Mark Jhon",
                       EmployeeAddress = "Some str.4",
                       DepartmentId = 2,
                       HireDate =  DateTime.ParseExact("01.03.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                       JobTitle = "Specialist",
                       Salary = decimal.Parse("2000.00"),
                       isActive = true,
                         LineManager = 3
                }

            });

            await dbContext.Employees.AddRangeAsync(employees);
            await dbContext.SaveChangesAsync();

        }

        private async Task SeedDepartments(EMSDbContext dbContext)
        {
            List<Department> departments = new List<Department>();

            departments.AddRange(new List<Department>
            {
                new Department {
                     Description = "Marketing",
                      isActive = true
                },

                 new Department {
                     Description = "Sales",
                      isActive = true
                },
                 new Department
                 {
                     Description = "IT Applications",
                      isActive = true
                 },
                 new Department
                 {
                      Description = "Accounting",
                       isActive = true
                 }
            });

            await dbContext.Departments.AddRangeAsync(departments);
            await dbContext.SaveChangesAsync();
        }
    }
}
