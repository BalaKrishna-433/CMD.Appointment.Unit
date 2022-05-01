using CMD.Model.Appointments;
using CMD.Repository.Appointments.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace CMD.Repository.Appointments.Implementations
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private CMDContext db;

        public FeedbackRepository()
        {
            this.db = new CMDContext();
        }

        public FeedBack GetFeedback(int id)
        {
            var result = db.Appointments.Where(a => a.Id == id).Select(a => a.FeedBack).SelectMany(f => f.Rating).Include(r => r.Question).ToList();
            var feedback = db.Appointments.Where(a => a.Id == id).Select(a => a.FeedBack).FirstOrDefault();
            if (feedback == null)
            {
                return null;
            }
            var x = new FeedBack
            {
                Id = feedback.Id,
                AdditionalComment = feedback.AdditionalComment,
                Rating = result
            };


            return x;
        }
    }
}
