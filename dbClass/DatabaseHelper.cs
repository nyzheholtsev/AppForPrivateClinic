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
            if (File.Exists(_dbFileName)) return;

            try
            {
                SQLiteConnection.CreateFile(_dbFileName);

                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        CreateTables(connection);
                        SeedDefaultData(connection);
                        
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критична помилка при створенні БД: {ex.Message}\n\nФайл буде видалено.",
                                "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (File.Exists(_dbFileName)) File.Delete(_dbFileName);
            }
        }

        private static void CreateTables(SQLiteConnection connection)
        {
            ExecuteSql(connection, @"
            CREATE TABLE Roles (
                RoleID INTEGER PRIMARY KEY AUTOINCREMENT,
                RoleName TEXT NOT NULL UNIQUE
            );");

            ExecuteSql(connection, @"
            CREATE TABLE Users (
                UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                RoleID INTEGER NOT NULL,
                FullName TEXT NOT NULL,
                Specialization TEXT,
                Username TEXT NOT NULL UNIQUE,
                PasswordHash TEXT NOT NULL,
                IsActive INTEGER DEFAULT 1,
                FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
            );");

            ExecuteSql(connection, @"
            CREATE TABLE Patients (
                PatientID INTEGER PRIMARY KEY AUTOINCREMENT,
                FullName TEXT NOT NULL,
                DateOfBirth TEXT NOT NULL,
                Contacts TEXT NOT NULL,
                CreatedDate TEXT NOT NULL
            );");

            ExecuteSql(connection, @"
            CREATE TABLE DoctorSchedules (
                ScheduleID INTEGER PRIMARY KEY AUTOINCREMENT,
                UserID INTEGER NOT NULL,
                WorkDate TEXT NOT NULL,
                StartTime TEXT NOT NULL,
                EndTime TEXT NOT NULL,
                LunchStart TEXT NOT NULL,
                LunchEnd TEXT NOT NULL,
                FOREIGN KEY (UserID) REFERENCES Users(UserID)
            );");

            ExecuteSql(connection, @"
            CREATE TABLE Appointments (
                AppointmentID INTEGER PRIMARY KEY AUTOINCREMENT,
                PatientID INTEGER NOT NULL,
                UserID INTEGER NOT NULL,
                AppointmentDate TEXT NOT NULL,
                AppointmentTime TEXT NOT NULL,
                Status TEXT NOT NULL,
                FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
                FOREIGN KEY (UserID) REFERENCES Users(UserID)
            );");

            ExecuteSql(connection, @"
            CREATE TABLE MedicalRecords (
                MedicalRecordID INTEGER PRIMARY KEY AUTOINCREMENT,
                AppointmentID INTEGER NOT NULL,
                Diagnosis TEXT NOT NULL,
                Treatment TEXT NOT NULL,
                Notes TEXT NOT NULL,
                FOREIGN KEY (AppointmentID) REFERENCES Appointments(AppointmentID)
            );");
        }

        private static void SeedDefaultData(SQLiteConnection connection)
        {
            string[] roles = { "Головний Лікар", "Лікар", "Адміністратор" };
            foreach (string role in roles)
            {
                ExecuteSql(connection, "INSERT INTO Roles (RoleName) VALUES (@name)", new[] {
            new SQLiteParameter("@name", role)
        });
            }

            string adminHash = PasswordHelper.ComputeHash("admin");
            string sqlAdmin = @"
            INSERT INTO Users (RoleID, FullName, Specialization, Username, PasswordHash) 
            VALUES (
                (SELECT RoleID FROM Roles WHERE RoleName = 'Головний Лікар'), 
                'Нижегольцев Владислав Іванович', 
                'Організація охорони здоров''я',
                'admin', 
                @hash
            );";
            ExecuteSql(connection, sqlAdmin, new[] { new SQLiteParameter("@hash", adminHash) });

            string docHash = PasswordHelper.ComputeHash("doc");
            string sqlDoc = @"
            INSERT INTO Users (RoleID, FullName, Specialization, Username, PasswordHash) 
            VALUES (
                (SELECT RoleID FROM Roles WHERE RoleName = 'Лікар'), 
                'Петренко Петро Сергійович', 
                'Терапевт', 
                'doc', 
                @hash
            );";
            ExecuteSql(connection, sqlDoc, new[] { new SQLiteParameter("@hash", docHash) });

            SeedScheduleForDoctor(connection, 2);

            SeedPatient(connection, "Тестовий Пацієнт", "1980-05-15", "+380501234567");
            SeedPatient(connection, "Іванов Іван", "1992-11-30", "+380677654321");
        }


        private static void SeedPatient(SQLiteConnection connection, string name, string dob, string phone)
        {
            string sql = "INSERT INTO Patients (FullName, DateOfBirth, Contacts, CreatedDate) VALUES (@name, @dob, @phone, @date)";
            ExecuteSql(connection, sql, new[] {
        new SQLiteParameter("@name", name),
        new SQLiteParameter("@dob", dob),
        new SQLiteParameter("@phone", phone),
        new SQLiteParameter("@date", DateTime.Now.ToString("yyyy-MM-dd"))
    });
        }

        private static void SeedScheduleForDoctor(SQLiteConnection connection, int doctorId)
        {
            for (int i = 0; i < 3; i++)
            {
                string date = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd");

                string sql = @"
                INSERT INTO DoctorSchedules (UserID, WorkDate, StartTime, EndTime, LunchStart, LunchEnd)
                VALUES (@uid, @date, @start, @end, @lStart, @lEnd)";

                ExecuteSql(connection, sql, new[] {
                new SQLiteParameter("@uid", doctorId),
                new SQLiteParameter("@date", date),
                new SQLiteParameter("@start", "09:00"),
                new SQLiteParameter("@end", "17:00"),
                new SQLiteParameter("@lStart", "13:00"),
                new SQLiteParameter("@lEnd", "14:00")
            });
            }
        }


        private static void ExecuteSql(SQLiteConnection connection, string sql, SQLiteParameter[] parameters = null) // - лишние дублирование
        {
            using (var command = new SQLiteCommand(sql, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                command.ExecuteNonQuery();
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
                                    Specialization = reader["Specialization"].ToString(),
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