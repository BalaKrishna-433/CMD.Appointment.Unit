using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMD.Model.Appointments
{
    public class Appointment
    {
        public Appointment()
        {
            Prescriptions = new HashSet<Prescription>();
            TestReports = new HashSet<TestReport>();
            Status = AppointmentStatus.OPEN;
            Recommendations = new HashSet<Recommendation>();
            Vital = new Vital();
            CreatedAt = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public AppointmentStatus Status { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public string PatientName { get; set; }
        public string Issue { get; set; }
        public string Comment { get; set; }
        public string Reason { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public Vital Vital { get; set; }
        public ICollection<TestReport> TestReports { get; set; }
        public ICollection<Recommendation> Recommendations { get; set; }
        public FeedBack FeedBack { get; set; }
        [Column(TypeName = "Date")]
        public DateTime CreatedAt { get; private set; }
    }
}
