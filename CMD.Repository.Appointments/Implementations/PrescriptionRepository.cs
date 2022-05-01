using CMD.Model.Appointments;
using CMD.Repository.Appointments.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CMD.Repository.Appointments.Implementations
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly CMDContext db;
        public PrescriptionRepository()
        {
            this.db = new CMDContext();
        }

        public bool DeletePrescription(int appointmentId, int PrescriptionId)
        {
            Appointment patientDetail = db.Appointments.Include("Prescriptions").Where(p => p.Id == appointmentId).FirstOrDefault();
            Prescription pres = null;
            foreach (Prescription p in patientDetail.Prescriptions)
            {
                if (p.Id == PrescriptionId)
                {
                    pres = p;
                    break;
                }
            }
            if (pres != null)
            {
                patientDetail.Prescriptions.Remove(pres);
                db.Prescriptions.Remove(pres);
                db.Appointments.Append(patientDetail);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public ICollection<Prescription> GetPrescriptions(int appointmentId)
        {
            ICollection<Prescription> prescriptions1 = new List<Prescription>();
            ICollection<Prescription> prescriptions = db.Appointments.Include("Prescriptions").Where(p => p.Id == appointmentId).Select(p => p.Prescriptions).FirstOrDefault();
            foreach (Prescription p in prescriptions)
            {
                //p.Medicine=db.Medicines.Find(p.Medicine.Id);
                Prescription temp = db.Prescriptions.Include("Medicine").Where(s => s.Id == p.Id).FirstOrDefault();
                temp.Medicine = db.Medicines.Find(temp.Medicine.Id);
                prescriptions1.Add(temp);
            }
            return prescriptions1;
        }


        //Add and Update Prescription

        public Prescription AddPrescription(int appointmentId, Prescription prescriptionId)
        {
            var p = db.Appointments.Find(appointmentId);

            p.Prescriptions.Add(prescriptionId);

            db.SaveChanges();
            return prescriptionId;
        }

        public Medicine GetMedicine(string name)
        {
            var result = db.Medicines.Where(m => m.Name == name).FirstOrDefault();
            return result;
        }

        public ICollection<Medicine> GetAllMedicine()
        {
            return db.Medicines.ToList();
        }

        public Prescription UpdatePrescription(Prescription prescription)
        {
            db.Entry(prescription).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return prescription;
        }
    }
}
