using EMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Models
{
    public class SearchModel
    {
        public SearchModel()
        {
            this.Departments = new List<Department>();
            this.Titles = new List<string>();
            this.Managers = new List<Employee>();
        }
        public List<Department> Departments { get; set; }
        public List<string> Titles { get; set; }
        public List<Employee> Managers { get; set; }
    }
}
