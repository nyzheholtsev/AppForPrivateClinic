using System.Data.SQLite;
using program.Repositories;

namespace program.dbClass
{
    public static class DbInitializer
    {
        private static string _dbFileName = "clinic.db";
        private static string _connectionString = $"Data Source={_dbFileName};Version=3;";

        public static void Initialize()
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

                SeedPatients();
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
            string[] roles = { "ChiefDoctor", "Doctor", "Administrator" };
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
                (SELECT RoleID FROM Roles WHERE RoleName = 'ChiefDoctor'), 
                'Нижегольцев Владислав Іванович', 
                'Головний лікар', 
                'admin', 
                @hash
            );";
            ExecuteSql(connection, sqlAdmin, new[] { new SQLiteParameter("@hash", adminHash) });

            string docHash = PasswordHelper.ComputeHash("doc");
            string sqlDoc = @"
            INSERT INTO Users (RoleID, FullName, Specialization, Username, PasswordHash) 
            VALUES (
                (SELECT RoleID FROM Roles WHERE RoleName = 'Doctor'), 
                'Петренко Петро Сергійович', 
                'Терапевт', 
                'doc', 
                @hash
            );";
            ExecuteSql(connection, sqlDoc, new[] { new SQLiteParameter("@hash", docHash) });

            SeedScheduleForDoctor(connection, 2);
        }

        private static void SeedScheduleForDoctor(SQLiteConnection connection, int doctorId)
        {
            for (int i = 0; i < 3; i++)
            {
                string date = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd");
                string sql = @"
                INSERT INTO DoctorSchedules (UserID, WorkDate, StartTime, EndTime, LunchStart, LunchEnd)
                VALUES (@uid, @date, '09:00', '17:00', '13:00', '14:00')";

                ExecuteSql(connection, sql, new[] {
                    new SQLiteParameter("@uid", doctorId),
                    new SQLiteParameter("@date", date)
                });
            }
        }

        private static void SeedPatients()
        {
            var repo = new PatientRepository();
            if (repo.Search("").Count > 10) return;

            var patients = new List<(string Name, DateTime Dob, string Phone)>
            {
                ("Вовк Ірина", DateTime.Parse("1980-07-28"), "+380995770750"),
                ("Ковальчук Віктор", DateTime.Parse("1971-11-26"), "+380561758083"),
                ("Лисенко Ольга", DateTime.Parse("1986-10-17"), "+380721159248"),
            };

            foreach (var p in patients)
            {
                repo.Add(p.Name, p.Dob, p.Phone);
            }
        }

        private static void ExecuteSql(SQLiteConnection connection, string sql, SQLiteParameter[] parameters = null)
        {
            using (var command = new SQLiteCommand(sql, connection))
            {
                if (parameters != null) command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
            }
        }
    }
}