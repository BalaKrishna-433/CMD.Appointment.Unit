using System;
using System.Collections.Generic;

namespace CMD.DTO.Appointments
{
    public class PaginationMetaData
    {
        public PaginationMetaData(int totalCount, int currentPage, int itemPerPage, ICollection<AppointmentBasicInfoDTO> appointmentBasicInfoDTO)
        {
            CurrentPage = currentPage;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)itemPerPage);
            AppointmentBasicInfo = appointmentBasicInfoDTO;
        }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasNext => CurrentPage < TotalPages;
        public bool HasPrevious => CurrentPage > 1;
        public ICollection<AppointmentBasicInfoDTO> AppointmentBasicInfo { get; private set; }
    }
}
