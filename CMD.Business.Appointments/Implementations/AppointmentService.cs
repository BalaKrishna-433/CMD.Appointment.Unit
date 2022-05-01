using CMD.Business.Appointments.Interfaces;
using CMD.DTO.Appointments;
using CMD.Model.Appointments;
using CMD.ModelDTO.Converter;
using CMD.Repository.Appointments.Implementations;
using CMD.Repository.Appointments.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMD.Business.Appointments.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository repo;
        public AppointmentService(AppointmentRepository repo)
        {
            this.repo = repo;
        }

        public ConfirmedAppointmentDTO CreateAppointment(AppointmentFormDTO appointmentDTO)
        {
            var appointment = Converter.ConvertToAppointment(appointmentDTO);

            ConfirmedAppointmentDTO result = Converter.ConvertToConfirmedAppointmentDTO(repo.CreateAppointment(appointment));

            return result;
        }

        public ICollection<AppointmentBasicInfoDTO> GetAllAppointment(int doctorId, PaginationParams pagination)
        {
            ICollection<Appointment> appointments = repo.GetAllAppointment(doctorId).Skip((pagination.Page - 1) * pagination.ItemsPerPage).Take(pagination.ItemsPerPage).ToList();
            ICollection<AppointmentBasicInfoDTO> result = new List<AppointmentBasicInfoDTO>();
            foreach (var appointment in appointments)
            {
                result.Add(Converter.ConvertToAppointmentBasicInfoDTO(appointment));
            }
            return result;

        }

        public ICollection<AppointmentBasicInfoDTO> GetAllAppointmentFiltered(int doctorId, string status, PaginationParams pagination)
        {
            AppointmentStatus appStatus = (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), status.ToUpper());
            ICollection<Appointment> appointments = repo.GetAllAppointmentFilterWithStatus(doctorId, appStatus).Skip((pagination.Page - 1) * pagination.ItemsPerPage).Take(pagination.ItemsPerPage).ToList();
            ICollection<AppointmentBasicInfoDTO> result = new List<AppointmentBasicInfoDTO>();
            foreach (var appointment in appointments)
            {
                result.Add(Converter.ConvertToAppointmentBasicInfoDTO(appointment));
            }
            return result;
        }

        public bool ChangeAppointmentStatus(AppointmentStatusDTO statusDTO, int doctorId)
        {
            var status = (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), statusDTO.Status.ToUpper());
            var result = false;
            if (status == AppointmentStatus.CONFIRMED)
            {
                result = repo.AcceptApppointment(statusDTO.AppointmentId);
            }
            else if (status == AppointmentStatus.CANCELLED)
            {
                result = repo.RejectApppointment(statusDTO.AppointmentId);
            }
            return result;
        }

        public bool CloseAppointment(int appointmentId)
        {
            var success = repo.CloseAppointment(appointmentId);
            if (success)
            {
                repo.CreateFeedback(appointmentId);
            }
            return success;
        }

        public AppointmentCommentDTO GetAppointmentComment(int appointmentId)
        {
            return new AppointmentCommentDTO { Id = appointmentId, Comment = repo.GetComment(appointmentId) };
        }

        public bool UpdateAppointmentComment(int appointmentId, AppointmentCommentDTO appointmentComment)
        {
            return repo.EditComment(appointmentId, appointmentComment.Comment);
        }

        public Dictionary<string, int> DashboardSummary(int doctorId)
        {
            var statuses = repo.GetAppointmentSummary(doctorId);
            int[] summary = { 0, 0, 0 };//accepted,total,cancelled
            foreach (var str in statuses)
            {
                if (str == AppointmentStatus.CONFIRMED)//CONFIRMED
                {
                    summary[0]++;
                }
                else if (str == AppointmentStatus.CANCELLED)//CANCELLED
                {
                    summary[2]++;
                }
                else
                {
                    summary[1]++;
                }
            }
            summary[1] = summary.Sum();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            keyValuePairs.Add("Accepted", summary[0]);
            keyValuePairs.Add("Total", summary[1]);
            keyValuePairs.Add("Cancelled", summary[2]);
            return keyValuePairs;
        }

        public int GetAppointmentCount(int doctorId)
        {
            return repo.AppointmentCount(doctorId);
        }
        public int GetAppointmentCountBasedOnStatus(int doctorId, string status)
        {
            return repo.AppointmentCount(doctorId, status);
        }

        public IdsListViewDetailsDTO GetIdsAssociatedWithAppointment(int appointmentId)
        {
            IdsListViewDetailsDTO idsListViewDetailsDTO = new IdsListViewDetailsDTO();
            var temp = repo.GetAppointment(appointmentId);
            idsListViewDetailsDTO.AppointmentId = temp.Id;
            idsListViewDetailsDTO.PatientId = temp.PatientId;
            idsListViewDetailsDTO.DoctorId = temp.DoctorId;
            return idsListViewDetailsDTO;
        }

    }
}
