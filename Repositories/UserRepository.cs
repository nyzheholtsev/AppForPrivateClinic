using System.Data.SQLite;
using program.dbClass;        
using program.dbClass.Models;

namespace program.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserModel ValidateUser(string username, string password)
        {
            string passwordHash = PasswordHelper.ComputeHash(password);

            string sql = @"
            SELECT u.UserID, u.FullName, u.Specialization, r.RoleName 
            FROM Users u JOIN Roles r ON u.RoleID = r.RoleID
            WHERE u.Username = @user AND u.PasswordHash = @pass AND u.IsActive = 1;";

            try
            {
                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@user", username);
                    command.Parameters.AddWithValue("@pass", passwordHash);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserModel
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                FullName = reader["FullName"].ToString(),
                                Specialization = reader["Specialization"].ToString(),
                                RoleName = reader["RoleName"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при вході: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}