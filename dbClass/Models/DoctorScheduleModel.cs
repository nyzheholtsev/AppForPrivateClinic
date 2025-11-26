namespace program.dbClass
{
    public class DoctorScheduleModel
    {
        public int ScheduleID { get; set; }
        public int UserID { get; set; }
        public string WorkDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string LunchStart { get; set; }
        public string LunchEnd { get; set; }
        public string DoctorName { get; set; }
    }
}