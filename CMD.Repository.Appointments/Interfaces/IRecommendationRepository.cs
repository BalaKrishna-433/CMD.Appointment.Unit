using CMD.Model.Appointments;

namespace CMD.Repository.Appointments.Interfaces
{
    public interface IRecommendationRepository
    {
        Recommendation AddRecommendtaion(Recommendation reco);
        bool RemoveRecommendation(int id);
    }
}
