using System.ComponentModel.DataAnnotations;

namespace Code_first_demo.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required(ErrorMessage ="Enter a Name")]
        [StringLength(20,ErrorMessage ="Name should not more than 20 characters.")]
        [MinLength(3,ErrorMessage ="Name should contain atleast 3 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the Gender")]
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Gender must be male, female or others.")]
        public string Gender { get; set; }
        [Required(ErrorMessage ="Enter Email")]
        [EmailAddress(ErrorMessage ="Enter valid email address.")]
        public string Email { get; set; }
        public string Designation { get; set; }
        [Range(0,double.MaxValue,ErrorMessage ="Salary must be a positive number.")]
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
    }
}
