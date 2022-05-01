using CMD.Model.Appointments;
using CMD.Repository.Appointments.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CMD.Repository.Appointments.Implementations
{
    public class VitalRepository : IVitalRepository
    {
        private readonly CMDContext db;
        public VitalRepository()
        {
            this.db = new CMDContext();
        }

        public ICollection<Vital> getAllVitals()
        {
            return db.Vitals.ToList();
        }

        public Vital getVitalById(int id)
        {
            var item = db.Vitals.Find(id);
            return item;
        }

        public Vital updateVital(Vital v)
        {

            db.Entry(v).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return v;
        }
    }
}
