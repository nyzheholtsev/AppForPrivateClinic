using System;
using program.dbClass; // Нужно для доступа к UserRole и расширениям

namespace program.dbClass.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string RoleName { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }

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

        // Новое свойство для отображения в таблице
        public string RoleLocalized
        {
            get
            {
                return Role.GetLocalizedName();
            }
        }
    }
}