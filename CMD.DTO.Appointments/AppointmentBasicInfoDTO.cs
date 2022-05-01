using System;

namespace CMD.DTO.Appointments
{
    public class AppointmentBasicInfoDTO
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string AppointmentStatus { get; set; }
        public string PatientName { get; set; }
        public string Issue { get; set; }
    }
}
