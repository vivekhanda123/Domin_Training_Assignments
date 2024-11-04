using System.ComponentModel.DataAnnotations;

namespace Code_First_Assignment.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        // Foreign Key to Doctor
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        // Foreign Key to Patient
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
