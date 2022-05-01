using CMD.Model.Appointments;

namespace CMD.Business.Appointments.Interfaces
{
    public interface IFeedbackService
    {
        FeedBack GetFeedback(int id);
    }
}
