using EMS.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Data.Entities
{
    public class Department : BaseEntity
    {
        public string Description { get; set; }
        public bool isActive { get; set; }
    }
}
