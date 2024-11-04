﻿namespace Code_first_demo.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
