using System.ComponentModel.DataAnnotations;

namespace CMD.Model.Appointments
{
    public class Recommendation
    {
        [Key]
        public int RecommedationId { get; set; }
        public string RecommendedDoctor { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
    }
}