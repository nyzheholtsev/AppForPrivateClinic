using program.Localization;

namespace program.dbClass
{
    public static class UserRoleExtensions
    {
        public static string GetLocalizedName(this UserRole role)
        {
            return LocalizationManager.GetString($"Role_{role}");
        }
    }
}