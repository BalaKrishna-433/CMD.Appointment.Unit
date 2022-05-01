using System;

namespace CMD.DTO.Appointments
{
    public class AppointmentFormDTO
    {
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Issue { get; set; }
        public string Reason { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
    }
}
