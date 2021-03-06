﻿using EMS.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Data.Entities
{
    public class Employee :BaseEntity
    {
        public DateTime HireDate { get; set; }
        public string EmployeeName { get; set; }
        public string JobTitle { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public int? LineManager { get; set; }
        public string EmployeeAddress { get; set; }
        public bool isActive { get; set; } = true;
    }
}
