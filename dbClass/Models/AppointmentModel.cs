using program.Localization;

namespace program.dbClass
{
    public class AppointmentModel
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public int UserID { get; set; }
        public string DoctorName { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string Status { get; set; } 

        public string StatusLocalized
        {
            get
            {
                return LocalizationManager.GetString($"Status_{Status}");
            }
        }

        public AppointmentStatus StatusEnum
        {
            get
            {
                if (Enum.TryParse(Status, out AppointmentStatus result))
                {
                    return result;
                }
                return AppointmentStatus.Scheduled;
            }
            set
            {
                Status = value.ToString();
            }
        }
    }
}