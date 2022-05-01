using CMD.Model.Appointments;
using CMD.Repository.Appointments.Interfaces;

namespace CMD.Repository.Appointments.Implementations
{
    public class RecommendationRepository : IRecommendationRepository
    {
        private CMDContext db;

        public RecommendationRepository()
        {
            this.db = new CMDContext();
        }

        public Recommendation AddRecommendtaion(Recommendation reco)
        {
            Appointment appointment = db.Appointments.Find(reco.AppointmentId);
            appointment.Recommendations.Add(reco);
            db.SaveChanges();
            return reco;
        }

        public bool RemoveRecommendation(int id)
        {
            var r = db.Recommendations.Find(id);
            if (r == null) return false;
            db.Recommendations.Remove(r);
            return db.SaveChanges() > 0;
        }

        //    public List<DoctorInfoDTO> GetDoctors()
        //    {
        //        List<DoctorInfoDTO> list = new List<DoctorInfoDTO>();
        //        List<Doctor> doctors = db.Doctors.ToList();
        //        foreach (Doctor doctor in doctors)
        //        {
        //            DoctorInfoDTO temp = new DoctorInfoDTO();
        //            temp.Id = doctor.Id;
        //            temp.Name = doctor.Name;
        //            list.Add(temp);
        //        }
        //        return list;
        //    }
        //}
    }
}
