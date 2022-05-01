using CMD.Model.Appointments;
using System.Collections.Generic;

namespace CMD.Repository.Appointments.Interfaces
{
    public interface IVitalRepository
    {
        ICollection<Vital> getAllVitals();
        Vital getVitalById(int id);
        Vital updateVital(Vital v);
    }
}
