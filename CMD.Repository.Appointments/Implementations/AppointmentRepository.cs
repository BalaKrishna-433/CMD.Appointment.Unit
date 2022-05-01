using CMD.Model.Appointments;
using CMD.Repository.Appointments.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CMD.Repository.Appointments.Implementations
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly CMDContext db;
        public AppointmentRepository()
        {
            this.db = new CMDContext();
        }

        /// <summary>
        /// Creates a appointment object, store the value in database and returns the newly created object
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns>Appointment</returns>
        public Appointment CreateAppointment(Appointment appointment)
        {
            db.Appointments.Add(appointment);
            db.SaveChanges();
            return appointment;
        }

        public ICollection<Appointment> GetAllAppointment(int doctorId)
        {
            var appointments = db.Appointments.Where(x => x.DoctorId == doctorId).ToList();
            return appointments;
        }

        public ICollection<Appointment> GetAllAppointmentFilterWithStatus(int doctorId, AppointmentStatus status)
        {
            var appointments = db.Appointments.Where(a => a.DoctorId == doctorId && a.Status == status).ToList();
            return appointments;
        }

        public Appointment GetAppointment(int appointmentId)
        {
            var result = db.Appointments
                .Include(a => a.Prescriptions.Select(p => p.Medicine))
                .Include(a => a.TestReports.Select(t => t.Test))
                .Include(a => a.Vital)
                .Include(a => a.Recommendations).Where(a => a.Id == appointmentId).FirstOrDefault();
            return result;
        }

        public bool RejectApppointment(int appointmentId)
        {
            var appointment = db.Appointments.Find(appointmentId);

            appointment.Status = AppointmentStatus.CANCELLED;
            return db.SaveChanges() > 0;
        }

        public bool AcceptApppointment(int appointmentId)
        {
            var appointment = db.Appointments.Find(appointmentId);

            appointment.Status = AppointmentStatus.CONFIRMED;
            return db.SaveChanges() > 0;
        }


        public bool CloseAppointment(int appointmentId)
        {
            var appointment = db.Appointments.Find(appointmentId);
            appointment.Status = AppointmentStatus.CLOSED;
            appointment.FeedBack = new FeedBack();
            return db.SaveChanges() > 0;
        }

        public bool CreateFeedback(int appointmentId)
        {
            var appointment = db.Appointments.Find(appointmentId);
            var questions = db.Questions.ToList();

            if (questions.Count > 0)
            {
                foreach (var item in questions)
                {
                    appointment.FeedBack.Rating.Add(new QuestionRating { Question = item });
                }
            }

            return db.SaveChanges() > 0;
        }


        public int TotalAppointmentCount(int doctorId)
        {
            return db.Appointments.Count();
        }

        public int TotalAppointmentCountBasedOnStatus(int doctorId, AppointmentStatus status)
        {
            return db.Appointments.Where(a => a.Status.CompareTo(status) == 0).Count();
        }

        public List<int> GetIdsAssociatedWithAppointment(int appointmentId)
        {
            return db.Appointments.Where(x => x.Id == appointmentId).Select(x => new List<int>
            {
                x.Id,
                x.PatientId,
                x.DoctorId
            }).FirstOrDefault();
        }

        public IQueryable<AppointmentStatus> GetAppointmentSummary(int doctorId)
        {
            return db.Appointments.Where(a => a.DoctorId == doctorId).Select(x => x.Status).AsQueryable();
        }

        public string GetComment(int appointmentId)
        {
            return db.Appointments.Where(a => a.Id == appointmentId).Select(a => a.Comment).FirstOrDefault();
        }

        public bool EditComment(int appointmentId, string comment)
        {
            var appointment = db.Appointments.Find(appointmentId);
            appointment.Comment = comment;
            db.Entry(appointment).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public int AppointmentCount(int doctorId)
        {
            return db.Appointments.Where(a => a.DoctorId == doctorId).Count();
        }

        public int AppointmentCount(int doctorId, string status)
        {
            return db.Appointments.Where(a => a.DoctorId == doctorId && a.Status.ToString().ToLower().Equals(status.ToLower())).Count();
        }

    }
}
