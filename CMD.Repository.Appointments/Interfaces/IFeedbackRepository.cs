using CMD.Model.Appointments;

namespace CMD.Repository.Appointments.Interfaces
{
    public interface IFeedbackRepository
    {
        FeedBack GetFeedback(int id);
    }
}
