using CMD.DTO.Appointments;
using System.Collections.Generic;

namespace CMD.Business.Appointments.Interfaces
{
    public interface IAppointmentService
    {
        ConfirmedAppointmentDTO CreateAppointment(AppointmentFormDTO appointmentDTO);
        ICollection<AppointmentBasicInfoDTO> GetAllAppointment(int doctorId, PaginationParams pagination);
        ICollection<AppointmentBasicInfoDTO> GetAllAppointmentFiltered(int doctorId, string status, PaginationParams pagination);
        int GetAppointmentCount(int doctorId);
        int GetAppointmentCountBasedOnStatus(int doctorId, string status);
        Dictionary<string, int> DashboardSummary(int doctorId);
        bool UpdateAppointmentComment(int appointmentId, AppointmentCommentDTO appointmentComment);
        AppointmentCommentDTO GetAppointmentComment(int appointmentId);
        bool ChangeAppointmentStatus(AppointmentStatusDTO statusDTO, int doctorId);
        IdsListViewDetailsDTO GetIdsAssociatedWithAppointment(int appointmentId);
        bool CloseAppointment(int appointmentId);
    }
}
