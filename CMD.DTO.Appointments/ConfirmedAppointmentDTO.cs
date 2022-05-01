using System;

namespace CMD.DTO.Appointments
{
    public class ConfirmedAppointmentDTO
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string PatientName { get; set; }
        public string IssueName { get; set; }
        public string DoctorName { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
    }
}
