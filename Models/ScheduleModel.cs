using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public string PatientId { get; set; } // Foreign Key to Patient's ID
        public string PhoneNumber { get; set; } // Foreign Key to Patient's ID
        public string DoctorId { get; set; }  // Foreign Key to Doctor's ID (optional)
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        //public string Status { get; set; } // E.g., "Booked", "Completed"
    }
}