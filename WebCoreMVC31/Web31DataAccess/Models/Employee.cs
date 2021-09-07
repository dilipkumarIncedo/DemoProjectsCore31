using System;
using System.Collections.Generic;

#nullable disable

namespace Web31DataAccess.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public int DeptId { get; set; }
        public string Designation { get; set; }
        public string UserId { get; set; }

        public virtual Department Dept { get; set; }
        public virtual User User { get; set; }
    }
}
