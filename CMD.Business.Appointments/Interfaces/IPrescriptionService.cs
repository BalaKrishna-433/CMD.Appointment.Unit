using CMD.DTO.Appointments;
using System.Collections.Generic;

namespace CMD.Business.Appointments.Interfaces
{
    public interface IPrescriptionService
    {
        bool DeletePrescription(int appointmentId, int PrescriptionId);
        ICollection<PrescriptionDTO> GetPrescriptions(int appointmentId);
        PrescriptionDTO AddPrescription(int appointmentId, PrescriptionDTO prescriptionDto);
        PrescriptionDTO UpdatePrescription(PrescriptionDTO prescriptionDto);
        ICollection<MedicineDTO> GetAllMedicine();
    }
}
