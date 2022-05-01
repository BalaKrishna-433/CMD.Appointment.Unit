using CMD.DTO.Appointments;
using CMD.Model.Appointments;

namespace CMD.ModelDTO.Converter
{
    public class Converter
    {
        public static Appointment ConvertToAppointment(AppointmentFormDTO dto)
        {
            Appointment appointment = new Appointment
            {
                AppointmentDate = dto.AppointmentDate,
                AppointmentTime = dto.AppointmentTime,
                Issue = dto.Issue,
                Reason = dto.Reason,
                PatientId = dto.PatientId,
                PatientName = dto.PatientName,
                DoctorId = dto.DoctorId,
                DoctorName = dto.DoctorName,
            };
            return appointment;
        }
        public static AppointmentBasicInfoDTO ConvertToAppointmentBasicInfoDTO(Appointment model)
        {
            AppointmentBasicInfoDTO appointment = new AppointmentBasicInfoDTO
            {
                AppointmentId = model.Id,
                AppointmentDate = model.AppointmentDate,
                AppointmentTime = model.AppointmentTime,
                AppointmentStatus = model.Status.ToString(),
                PatientName = model.PatientName,
                Issue = model.Issue,
            };
            return appointment;
        }

        public static ConfirmedAppointmentDTO ConvertToConfirmedAppointmentDTO(Appointment model)
        {
            ConfirmedAppointmentDTO appointment = new ConfirmedAppointmentDTO
            {
                AppointmentId = model.Id,
                AppointmentDate = model.AppointmentDate,
                AppointmentTime = model.AppointmentTime,
                PatientName = model.PatientName,
                IssueName = model.Issue,
                DoctorName = model.DoctorName,
                Reason = model.Reason,
                Status = model.Status.ToString()
            };
            return appointment;
        }
    }
}
