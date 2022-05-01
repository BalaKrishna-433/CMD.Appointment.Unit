using System.ComponentModel.DataAnnotations.Schema;

namespace CMD.Model.Appointments
{
    public class TestReport
    {
        public int Id { get; set; }

        [ForeignKey("Test")]
        public int? TestId { get; set; }
        public Test Test { get; set; }
        public string Report { get; set; }
        public float Value { get; set; }
    }
}