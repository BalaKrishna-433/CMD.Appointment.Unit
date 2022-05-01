using CMD.Business.Appointments.Interfaces;
using CMD.DTO.Appointments;
using CMD.Model.Appointments;
using CMD.Repository.Appointments.Implementations;
using CMD.Repository.Appointments.Interfaces;
using System.Collections.Generic;

namespace CMD.Business.Appointments.Implementations
{
    public class VitalService : IVitalService
    {
        private IVitalRepository repo;

        public VitalService(VitalRepository repo)
        {
            this.repo = repo;
        }


        public ICollection<VitalDTO> GetAllVitalsDTO()
        {
            List<VitalDTO> list = new List<VitalDTO>();
            ICollection<Vital> vital = repo.getAllVitals();
            foreach (Vital v in vital)
            {
                VitalDTO temp = new VitalDTO();
                temp.id = v.Id;
                temp.diabetes = v.Diabetes;
                temp.ecg = v.ECG;
                temp.temperature = v.Temperature;
                temp.respiration_rate = v.RespirationRate;
                list.Add(temp);
            }
            return list;
        }


        public VitalDTO GetVitalDTOByVitalId(int vital_id)
        {
            VitalDTO vitaldto = new VitalDTO();
            Vital vital = repo.getVitalById(vital_id);
            if (vital != null)
            {
                vitaldto.id = vital.Id;
                vitaldto.diabetes = vital.Diabetes;
                vitaldto.ecg = vital.ECG;
                vitaldto.temperature = vital.Temperature;
                vitaldto.respiration_rate = vital.RespirationRate;
            }
            return vitaldto;
        }

        public VitalDTO UpdateVital(VitalDTO v)
        {
            Vital vital = new Vital()
            {
                Id = v.id,
                Diabetes = v.diabetes,
                Temperature = v.temperature,
                ECG = v.ecg,
                RespirationRate = v.respiration_rate
            };

            Vital vital1 = repo.updateVital(vital);

            v.ecg = vital1.ECG;
            v.respiration_rate = vital1.RespirationRate;
            v.temperature = vital1.Temperature;
            v.diabetes = vital1.Diabetes;

            return v;
        }
    }
}
