using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_DBF_Demo.Models
{
    [Table("Department")]
    public partial class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
