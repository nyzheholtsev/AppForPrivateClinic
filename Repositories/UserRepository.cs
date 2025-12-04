using System.Data.SQLite;
using program.dbClass;
using program.dbClass.Models;
using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace program.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserModel ValidateUser(string username, string password)
        {
            string passwordHash = PasswordHelper.ComputeHash(password);

            string sql = @"
            SELECT u.UserID, u.FullName, u.Specialization, r.RoleName, u.IsActive 
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
                                RoleName = reader["RoleName"].ToString(),
                                IsActive = Convert.ToInt32(reader["IsActive"]) == 1
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

        // --- ИЗМЕНЕННЫЙ МЕТОД ---
        public List<UserModel> GetAllUsers()
        {
            var list = new List<UserModel>();
            // Добавили WHERE u.IsActive = 1
            string sql = @"
                SELECT u.UserID, u.FullName, u.Specialization, u.Username, u.IsActive, r.RoleName
                FROM Users u 
                JOIN Roles r ON u.RoleID = r.RoleID
                WHERE u.IsActive = 1
                ORDER BY u.FullName";

            try
            {
                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new UserModel
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                FullName = reader["FullName"].ToString(),
                                Specialization = reader["Specialization"].ToString(),
                                RoleName = reader["RoleName"].ToString(),
                                Username = reader["Username"].ToString(),
                                IsActive = Convert.ToInt32(reader["IsActive"]) == 1
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження користувачів: {ex.Message}");
            }
            return list;
        }

        public List<UserModel> GetAllDoctors()
        {
            var list = new List<UserModel>();
            string sql = @"
                SELECT u.UserID, u.FullName, u.Specialization, u.IsActive 
                FROM Users u 
                JOIN Roles r ON u.RoleID = r.RoleID 
                WHERE r.RoleName = 'Doctor' AND u.IsActive = 1";

            try
            {
                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new UserModel
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                FullName = reader["FullName"].ToString(),
                                Specialization = reader["Specialization"].ToString(),
                                RoleName = "Doctor",
                                IsActive = Convert.ToInt32(reader["IsActive"]) == 1
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження лікарів: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public void UpdateUserStatus(int userId, bool isActive)
        {
            string sql = "UPDATE Users SET IsActive = @active WHERE UserID = @uid";
            try
            {
                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@active", isActive ? 1 : 0);
                    command.Parameters.AddWithValue("@uid", userId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення статусу: {ex.Message}");
            }
        }

        public bool CheckUsernameExists(string username)
        {
            string sql = "SELECT COUNT(1) FROM Users WHERE Username = @user";
            try
            {
                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@user", username);
                    long count = (long)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch { return false; }
        }

        public void AddUser(string fullName, string username, string password, string roleName, string specialization)
        {
            string passHash = PasswordHelper.ComputeHash(password);

            string roleSql = "SELECT RoleID FROM Roles WHERE RoleName = @rname";
            int roleId = 0;

            using (var connection = GetConnection())
            {
                using (var cmd = new SQLiteCommand(roleSql, connection))
                {
                    cmd.Parameters.AddWithValue("@rname", roleName);
                    object res = cmd.ExecuteScalar();
                    if (res != null) roleId = Convert.ToInt32(res);
                }

                if (roleId == 0) throw new Exception("Role not found");

                string insertSql = @"
                    INSERT INTO Users (RoleID, FullName, Specialization, Username, PasswordHash, IsActive)
                    VALUES (@rid, @name, @spec, @user, @pass, 1)";

                using (var cmd = new SQLiteCommand(insertSql, connection))
                {
                    cmd.Parameters.AddWithValue("@rid", roleId);
                    cmd.Parameters.AddWithValue("@name", fullName);
                    cmd.Parameters.AddWithValue("@spec", specialization);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", passHash);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}