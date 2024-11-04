using System.ComponentModel.DataAnnotations;

namespace Code_First_Assignment.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // Navigation property
        public ICollection<Doctor> Doctors { get; set; }
    }
}
