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
                if (Enum.TryParse(RoleName, out UserRole result))
                {
                    return result;
                }
                return UserRole.Doctor;
            }
        }
    }
}