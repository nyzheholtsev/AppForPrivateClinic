using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace program.dbClass
{
    public static class DatabaseHelper
    {
        private static string _dbFileName = "clinic.db";
        private static string _connectionString = $"Data Source={_dbFileName};Version=3;";

        public static void InitializeDatabase()
        {
            if (File.Exists(_dbFileName))
            {
                return;
            }

            try
            {
                SQLiteConnection.CreateFile(_dbFileName);
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string sqlCreateRoles = @"
                    CREATE TABLE Roles (
                        RoleID INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoleName TEXT NOT NULL UNIQUE
                    );";
                    using (var command = new SQLiteCommand(sqlCreateRoles, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string sqlCreateUsers = @"
                    CREATE TABLE Users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoleID INTEGER NOT NULL,
                        FullName TEXT NOT NULL,
                        Username TEXT NOT NULL UNIQUE,
                        PasswordHash TEXT NOT NULL,
                        IsActive INTEGER DEFAULT 1,
                        FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
                    );";
                    using (var command = new SQLiteCommand(sqlCreateUsers, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string sqlCreatePatients = @"
                    CREATE TABLE Patients (
                        PatientID INTEGER PRIMARY KEY AUTOINCREMENT,
                        FullName TEXT NOT NULL,
                        DateOfBirth TEXT NOT NULL,
                        Contacts TEXT NOT NULL,
                        CreatedDate TEXT NOT NULL
                    );";
                    using (var command = new SQLiteCommand(sqlCreatePatients, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string[] roles = { "Головний Лікар", "Лікар", "Адміністратор" };
                    string sqlInsertRole = "INSERT INTO Roles (RoleName) VALUES (@roleName);";
                    foreach (string role in roles)
                    {
                        using (var command = new SQLiteCommand(sqlInsertRole, connection))
                        {
                            command.Parameters.AddWithValue("@roleName", role);
                            command.ExecuteNonQuery();
                        }
                    }

                    string adminPassHash = PasswordHelper.ComputeHash("admin");
                    string sqlInsertAdmin = @"
                    INSERT INTO Users (RoleID, FullName, Username, PasswordHash) 
                    VALUES (
                        (SELECT RoleID FROM Roles WHERE RoleName = 'Головний Лікар'), 
                        'Главный Врач (Админ)', 
                        'admin', 
                        @adminHash
                    );";
                    using (var command = new SQLiteCommand(sqlInsertAdmin, connection))
                    {
                        command.Parameters.AddWithValue("@adminHash", adminPassHash);
                        command.ExecuteNonQuery();
                    }

                    string sqlInsertPatient = @"
                    INSERT INTO Patients (FullName, DateOfBirth, Contacts, CreatedDate) 
                    VALUES (@FullName, @DateOfBirth, @Contacts, @CreatedDate);";

                    using (var command = new SQLiteCommand(sqlInsertPatient, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", "Іванов Іван Іванович");
                        command.Parameters.AddWithValue("@DateOfBirth", "1980-05-15");
                        command.Parameters.AddWithValue("@Contacts", "+380501234567");
                        command.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString("yyyy-MM-dd"));
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(sqlInsertPatient, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", "Петренко Петро Петрович");
                        command.Parameters.AddWithValue("@DateOfBirth", "1992-11-30");
                        command.Parameters.AddWithValue("@Contacts", "+380677654321");
                        command.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString("yyyy-MM-dd"));
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критична помилка при створенні БД: {ex.Message}\n\nФайл clinic.db буде видалено.", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (File.Exists(_dbFileName))
                {
                    File.Delete(_dbFileName);
                }
            }
        }


        public static DataTable SearchPatients(string query)
        {
            var dt = new DataTable();
            if (!File.Exists(_dbFileName)) return dt;

            string sql = @"
            SELECT PatientID, FullName, DateOfBirth, Contacts 
            FROM Patients
            WHERE FullName LIKE @query
            LIMIT 50;";

            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    using (var adapter = new SQLiteDataAdapter(sql, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@query", $"%{query}%");
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при пошуку пацієнтів: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }


        public static UserModel ValidateUser(string username, string password)
        {
            if (!File.Exists(_dbFileName))
            {
                MessageBox.Show("Критична помилка: Файл clinic.db не знайдено. База даних не була створена.", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            string passwordHash = PasswordHelper.ComputeHash(password);
            string sql = @"
            SELECT 
                u.UserID, 
                u.FullName, 
                r.RoleName 
            FROM Users u
            JOIN Roles r ON u.RoleID = r.RoleID
            WHERE 
                u.Username = @user AND 
                u.PasswordHash = @pass AND 
                u.IsActive = 1;
            ";

            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
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
                                    RoleName = reader["RoleName"].ToString()
                                };
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при вході: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}