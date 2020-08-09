using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Models
{
    public class EmployeeViewModel
    {

        public EmployeeViewModel()
        {
            this.Comments = new List<CommentViewModel>();
        }
        public int Id { get; set; }
        public DateTime HireDate { get; set; }
        public string EmployeeName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public decimal AnnualSalary {get; set;}
        public string LineManager { get; set; }
        public string EmployeeAddress { get; set; }

        public List<CommentViewModel> Comments { get; set; }
    }
}
