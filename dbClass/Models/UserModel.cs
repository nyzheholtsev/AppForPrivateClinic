using System;

namespace program.dbClass.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string RoleName { get; set; } 

        public UserRole Role
        {
            get
            {
                return RoleName switch
                {
                    "Головний Лікар" => UserRole.ChiefDoctor,
                    "Лікар" => UserRole.Doctor,
                    "Адміністратор" => UserRole.Administrator,
                    _ => UserRole.Doctor
                };
            }
        }
    }
}