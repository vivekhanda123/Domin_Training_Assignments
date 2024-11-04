using System.ComponentModel.DataAnnotations;

namespace Code_First_Assignment.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        // Navigation property
        public ICollection<Appointment> Appointments { get; set; }
    }
}
