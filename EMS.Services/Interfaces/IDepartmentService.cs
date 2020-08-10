using EMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetDepartments();
        string GetDepartmentName(int id);
    }
}
