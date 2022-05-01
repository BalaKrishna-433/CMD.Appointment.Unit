using CMD.DTO.Appointments;
using System.Collections.Generic;

namespace CMD.Business.Appointments.Interfaces
{
    public interface IVitalService
    {
        ICollection<VitalDTO> GetAllVitalsDTO();
        VitalDTO GetVitalDTOByVitalId(int vital_id);
        VitalDTO UpdateVital(VitalDTO v);
    }
}
