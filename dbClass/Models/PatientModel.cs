using System;

namespace program.dbClass
{
    public class PatientModel
    {
        public int PatientID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Contacts { get; set; }
        public string CreatedDate { get; set; }
    }
}