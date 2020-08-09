using EMS.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Data.Entities
{
    public class Comment : BaseEntity
    {
        public int EmployeeId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string Author { get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
