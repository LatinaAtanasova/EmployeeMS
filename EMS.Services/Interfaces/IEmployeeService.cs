using EMS.Data.Dtos;
using EMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.Interfaces
{
    public interface IEmployeeService
    {
        int Add(Employee employee);
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeById(int? id);
        IEnumerable<Employee> GetManagers();
    }
}
