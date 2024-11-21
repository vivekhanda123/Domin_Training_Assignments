using System;
using System.Collections.Generic;

namespace CustomMiddlewareDemo.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public int? DeptId { get; set; }

        public virtual Department? Dept { get; set; }
    }
}
