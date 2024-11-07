using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_DBF_Demo.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public int? DeptId { get; set; }
    }
}
