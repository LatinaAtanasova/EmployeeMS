using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Data.Dtos
{
    public class EmployeeDto
    {

        public int Id { get; set; }
        public DateTime HireDate { get; set; }
        public string EmployeeName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public decimal AnnualSalary => this.Salary * 12;

        public int? LineManager { get; set; }
        public string EmployeeAddress { get; set; }
    }
}
