using EMS.Data;
using EMS.Data.Dtos;
using EMS.Data.Entities;
using EMS.Data.Repository;
using EMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IDepartmentService _departmentService;

        public EmployeeService(IRepository<Employee> repository, IDepartmentService departmentService)
        {
            _repository = repository;
            _departmentService = departmentService;
        }

        public int Add(Employee employee)
        {
            return _repository.Insert(employee);
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            List<EmployeeDto> employees = new List<EmployeeDto>();
            List<Employee> allEmployees = _repository.GetAll().ToList();

            foreach (var empl in allEmployees)
            {
                string department = _departmentService.GetDepartmentName(empl.DepartmentId);
                EmployeeDto dto = new EmployeeDto
                {
                    Id = empl.Id,
                    EmployeeName = empl.EmployeeName,
                    Department = department,
                    EmployeeAddress = empl.EmployeeAddress,
                    HireDate = empl.HireDate,
                    JobTitle = empl.JobTitle,
                    LineManager = empl.LineManager,
                    Salary = empl.Salary
                };

                employees.Add(dto);
            }
            return employees;
        }

        public EmployeeDto GetEmployeeById(int? id)
        {
            return GetAllEmployees().FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Employee> GetManagers()
        {
            return _repository.GetAll().Where(x => x.LineManager == null && x.isActive).ToList();
        }
    }
}
