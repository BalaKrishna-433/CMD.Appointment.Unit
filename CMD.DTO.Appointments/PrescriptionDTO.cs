namespace CMD.DTO.Appointments
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public string Medicine { get; set; }
        public int Doses { get; set; }
        public bool Intake { get; set; }
        public int Span { get; set; }
        public string TimeOfDay { get; set; }
        public string AdditionalComment { get; set; }
    }
}
