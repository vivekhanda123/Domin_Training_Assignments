using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CF_Demo.Models
{
    [Table("tblDepartment")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Department Name")]
        public string Name { get; set; }
        [DisplayName("DepartmentHead")]
        public string DepartmentHead { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
