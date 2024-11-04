using System.ComponentModel.DataAnnotations;

namespace Code_First_Assignment.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Phone { get; set; }

        // Foreign Key
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        // Navigation property
        public ICollection<Appointment> Appointments { get; set; }
    }
}
