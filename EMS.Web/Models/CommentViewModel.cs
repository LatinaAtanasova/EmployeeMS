using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; }
        public string Btn { get; set; }
    }
}
