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
                        //SeedDefaultData(connection);
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

        //private static void SeedDefaultData(SQLiteConnection connection)
        //{
        //    string[] roles = { "ChiefDoctor", "Doctor", "Administrator" };
        //    foreach (string role in roles)
        //    {
        //        ExecuteSql(connection, "INSERT INTO Roles (RoleName) VALUES (@name)", new[] {
        //            new SQLiteParameter("@name", role)
        //        });
        //    }

        //    string adminHash = PasswordHelper.ComputeHash("admin");
        //    string sqlAdmin = @"
        //    INSERT INTO Users (RoleID, FullName, Specialization, Username, PasswordHash) 
        //    VALUES (
        //        (SELECT RoleID FROM Roles WHERE RoleName = 'ChiefDoctor'), 
        //        'Нижегольцев Владислав Іванович', 
        //        'Головний лікар', 
        //        'admin', 
        //        @hash
        //    );";
        //    ExecuteSql(connection, sqlAdmin, new[] { new SQLiteParameter("@hash", adminHash) });

        //    string docHash = PasswordHelper.ComputeHash("doc");
        //    string sqlDoc = @"
        //    INSERT INTO Users (RoleID, FullName, Specialization, Username, PasswordHash) 
        //    VALUES (
        //        (SELECT RoleID FROM Roles WHERE RoleName = 'Doctor'), 
        //        'Петренко Петро Сергійович', 
        //        'Терапевт', 
        //        'doc', 
        //        @hash
        //    );";
        //    ExecuteSql(connection, sqlDoc, new[] { new SQLiteParameter("@hash", docHash) });

        //    string regHash = PasswordHelper.ComputeHash("reg");
        //    string sqlReg = @"
        //    INSERT INTO Users (RoleID, FullName, Specialization, Username, PasswordHash) 
        //    VALUES (
        //        (SELECT RoleID FROM Roles WHERE RoleName = 'Administrator'), 
        //        'Сидоренко Анна Василівна', 
        //        'Реєстратура', 
        //        'reg', 
        //        @hash
        //    );";
        //    ExecuteSql(connection, sqlReg, new[] { new SQLiteParameter("@hash", regHash) });


        //    SeedScheduleForDoctor(connection, 2);
        //}

        //private static void SeedScheduleForDoctor(SQLiteConnection connection, int doctorId)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        string date = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd");
        //        string sql = @"
        //        INSERT INTO DoctorSchedules (UserID, WorkDate, StartTime, EndTime, LunchStart, LunchEnd)
        //        VALUES (@uid, @date, '09:00', '17:00', '13:00', '14:00')";

        //        ExecuteSql(connection, sql, new[] {
        //            new SQLiteParameter("@uid", doctorId),
        //            new SQLiteParameter("@date", date)
        //        });
        //    }
        //}

        //public static void SeedPatientHistory(int patientId)
        //{
        //    using (var connection = new SQLiteConnection(_connectionString))
        //    {
        //        connection.Open();
        //        using (var transaction = connection.BeginTransaction())
        //        {
        //            try
        //            {
        //                for (int i = 1; i <= 8; i++)
        //                {
        //                    string pastDate = DateTime.Now.AddMonths(-i).ToString("yyyy-MM-dd");

        //                    string sqlApp = @"
        //                INSERT INTO Appointments (PatientID, UserID, AppointmentDate, AppointmentTime, Status) 
        //                VALUES (@pid, 2, @date, '10:00', 'Completed'); 
        //                SELECT last_insert_rowid();";

        //                    long appointmentId;
        //                    using (var cmd = new SQLiteCommand(sqlApp, connection))
        //                    {
        //                        cmd.Parameters.AddWithValue("@pid", patientId);
        //                        cmd.Parameters.AddWithValue("@date", pastDate);
        //                        appointmentId = (long)cmd.ExecuteScalar();
        //                    }

        //                    string sqlRecord = @"
        //                INSERT INTO MedicalRecords (AppointmentID, Diagnosis, Treatment, Notes) 
        //                VALUES (@aid, @diag, @treat, @note)";

        //                    using (var cmd = new SQLiteCommand(sqlRecord, connection))
        //                    {
        //                        cmd.Parameters.AddWithValue("@aid", appointmentId);
        //                        cmd.Parameters.AddWithValue("@diag", $"Тестовий діагноз №{i} (ГРВІ)");
        //                        cmd.Parameters.AddWithValue("@treat", $"Приймати вітаміни, пити багато води. Курс №{i}");
        //                        cmd.Parameters.AddWithValue("@note", $"Пацієнт скаржився на головний біль. Температура 36.{i}");
        //                        cmd.ExecuteNonQuery();
        //                    }
        //                }
        //                string todayDate = DateTime.Now.ToString("yyyy-MM-dd");
        //                string sqlFuture = @"
        //            INSERT INTO Appointments (PatientID, UserID, AppointmentDate, AppointmentTime, Status) 
        //            VALUES (@pid, 2, @date, '21:00', 'Scheduled')";

        //                using (var cmd = new SQLiteCommand(sqlFuture, connection))
        //                {
        //                    cmd.Parameters.AddWithValue("@pid", patientId);
        //                    cmd.Parameters.AddWithValue("@date", todayDate);
        //                    cmd.ExecuteNonQuery();
        //                }

        //                transaction.Commit();
        //                MessageBox.Show("Тестові дані успішно додано!");
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                MessageBox.Show($"Помилка додавання тестових даних: {ex.Message}");
        //            }
        //        }
        //    }
        //}

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