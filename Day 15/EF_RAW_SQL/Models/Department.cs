using System;
using System.Collections.Generic;

namespace EF_RAW_SQL.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
