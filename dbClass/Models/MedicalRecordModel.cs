namespace program.dbClass
{
    public class MedicalRecordModel
    {
        public int MedicalRecordID { get; set; }
        public int AppointmentID { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string Notes { get; set; }
    }
}