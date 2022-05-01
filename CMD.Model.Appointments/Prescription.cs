namespace CMD.Model.Appointments
{
    public class Prescription
    {
        public int Id { get; set; }
        public Medicine Medicine { get; set; }
        public Intake Intake { get; set; }
        public int Span { get; set; }
        public string TimeOfDay { get; set; }
        public string AdditionalComment { get; set; }
    }
}