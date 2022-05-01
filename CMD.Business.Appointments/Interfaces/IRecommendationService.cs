using CMD.DTO.Appointments;

namespace CMD.Business.Appointments.Interfaces
{
    public interface IRecommendationService
    {
        bool RemoveRecommendation(int id);
        RecommendationDTO AddRecommendtaion(RecommendationDTO reco);
    }
}
