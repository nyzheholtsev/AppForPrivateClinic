using program.dbClass.Models;
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
        // =================================тестові=================================
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

        public static void Seed50Patients()
        {
            // Проверка: если пацієнтів уже много, не добавляем дубликаты
            if (SearchPatients("").Count > 10) return;

            var patients = new List<(string Name, DateTime Dob, string Phone)>
    {
        ("Вовк Ірина", DateTime.Parse("1980-07-28"), "+380995770750"),
        ("Ковальчук Віктор", DateTime.Parse("1971-11-26"), "+380561758083"),
        ("Лисенко Ольга", DateTime.Parse("1986-10-17"), "+380721159248"),
        ("Василенко Валерія", DateTime.Parse("1997-11-14"), "+380649715267"),
        ("Петренко Уляна", DateTime.Parse("1972-03-25"), "+380572913067"),
        ("Яценко Єлизавета", DateTime.Parse("1967-11-04"), "+380892582087"),
        ("Козак Костянтин", DateTime.Parse("1971-07-09"), "+380515050345"),
        ("Приходько Володимир", DateTime.Parse("1985-11-26"), "+380932332121"),
        ("Ковальчук Єва", DateTime.Parse("1982-02-19"), "+380648158303"),
        ("Кузьменко Поліна", DateTime.Parse("1964-09-16"), "+380795066764"),
        ("Мороз Богдан", DateTime.Parse("1975-09-08"), "+380916612113"),
        ("Барановський Дарина", DateTime.Parse("1977-08-04"), "+380801101552"),
        ("Романюк Матвій", DateTime.Parse("2002-01-11"), "+380929314502"),
        ("Приходько Захар", DateTime.Parse("1994-11-16"), "+380758779800"),
        ("Олійник Ярослав", DateTime.Parse("1996-01-04"), "+380977557481"),
        ("Ткачук Андрій", DateTime.Parse("1972-03-10"), "+380608332767"),
        ("Мельник Юрій", DateTime.Parse("1985-07-11"), "+380658334514"),
        ("Мельничук Марк", DateTime.Parse("1977-07-22"), "+380766083009"),
        ("Барановський Андрій", DateTime.Parse("1999-08-02"), "+380537769380"),
        ("Мельничук Анастасія", DateTime.Parse("1998-11-25"), "+380563396152"),
        ("Мельник Кирило", DateTime.Parse("1992-04-26"), "+380669304777"),
        ("Сидоренко Михайло", DateTime.Parse("1964-06-03"), "+380984865331"),
        ("Захарченко Марк", DateTime.Parse("1978-08-04"), "+380753512886"),
        ("Мороз Варвара", DateTime.Parse("1990-10-24"), "+380694365533"),
        ("Нестеренко Вероніка", DateTime.Parse("1975-07-14"), "+380816245026"),
        ("Попович Вероніка", DateTime.Parse("2002-11-19"), "+380943606065"),
        ("Ковальчук Олексій", DateTime.Parse("1995-06-01"), "+380966939854"),
        ("Шевченко Ярослав", DateTime.Parse("1974-08-28"), "+380569371412"),
        ("Барановський Данило", DateTime.Parse("1977-08-06"), "+380992197472"),
        ("Нестеренко Іван", DateTime.Parse("1971-07-05"), "+380568474614"),
        ("Коваленко Надія", DateTime.Parse("2005-06-13"), "+380829650567"),
        ("Сидоренко Валерія", DateTime.Parse("1973-11-26"), "+380792141556"),
        ("Лисенко Ольга", DateTime.Parse("1995-09-05"), "+380909436135"),
        ("Литвиненко Тимофій", DateTime.Parse("1961-06-07"), "+380679917462"),
        ("Захарченко Поліна", DateTime.Parse("2004-06-10"), "+380776602660"),
        ("Руденко Данило", DateTime.Parse("1979-09-13"), "+380964547357"),
        ("Карпенко Тетяна", DateTime.Parse("1972-08-02"), "+380797583732"),
        ("Даниленко Ксенія", DateTime.Parse("1980-04-12"), "+380602313921"),
        ("Кравченко Олег", DateTime.Parse("2000-05-12"), "+380623507378"),
        ("Шевчук Уляна", DateTime.Parse("1964-05-28"), "+380841944305"),
        ("Жук Денис", DateTime.Parse("1963-09-01"), "+380944920214"),
        ("Бондаренко Костянтин", DateTime.Parse("1964-07-17"), "+380744696011"),
        ("Ткаченко Артем", DateTime.Parse("1966-02-12"), "+380674859513"),
        ("Даниленко Уляна", DateTime.Parse("1973-08-06"), "+380848511430"),
        ("Василенко Катерина", DateTime.Parse("1974-09-04"), "+380605890898"),
        ("Нестеренко Дмитро", DateTime.Parse("1983-04-10"), "+380693061454"),
        ("Козак Артем", DateTime.Parse("1985-05-11"), "+380537093326"),
        ("Клименко Ірина", DateTime.Parse("1965-06-25"), "+380567620425"),
        ("Савченко Данило", DateTime.Parse("1969-01-12"), "+380786251306"),
        ("Савчук Дмитро", DateTime.Parse("1969-11-07"), "+380723395112"),
    };

            foreach (var p in patients)
            {
                AddPatient(p.Name, p.Dob, p.Phone);
            }
        }

        // =================================Patient=================================
        public static List<PatientModel> SearchPatients(string query)
        {
            var list = new List<PatientModel>();
            if (!File.Exists(_dbFileName)) return list;

            string sql = @"SELECT * FROM Patients WHERE FullName LIKE @query LIMIT 50;";

            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@query", $"%{query}%");
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new PatientModel
                                {
                                    PatientID = Convert.ToInt32(reader["PatientID"]),
                                    FullName = reader["FullName"].ToString(),
                                    DateOfBirth = DateTime.TryParse(reader["DateOfBirth"].ToString(), out DateTime dt) ? dt : DateTime.MinValue,
                                    Contacts = reader["Contacts"].ToString(),
                                    CreatedDate = reader["CreatedDate"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Помилка пошуку: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return list;
        }

        public static void AddPatient(string fullName, DateTime dateOfBirth, string contacts)
        {
            string sql = "INSERT INTO Patients (FullName, DateOfBirth, Contacts, CreatedDate) VALUES (@name, @dob, @phone, @date)";
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", fullName);
                        command.Parameters.AddWithValue("@dob", dateOfBirth.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@phone", contacts);
                        command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Помилка додавання: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        // =================================Appointments=================================
        public static List<AppointmentModel> GetAppointments(int doctorId, DateTime date)
        {
            var list = new List<AppointmentModel>();
            string sql = @"
                SELECT A.*, P.FullName AS PatientName, U.FullName AS DoctorName
                FROM Appointments A
                JOIN Patients P ON A.PatientID = P.PatientID
                JOIN Users U ON A.UserID = U.UserID
                WHERE A.UserID = @docId AND A.AppointmentDate = @date
                ORDER BY A.AppointmentTime";

            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@docId", doctorId);
                        command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new AppointmentModel
                                {
                                    AppointmentID = Convert.ToInt32(reader["AppointmentID"]),
                                    PatientID = Convert.ToInt32(reader["PatientID"]),
                                    PatientName = reader["PatientName"].ToString(),
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    DoctorName = reader["DoctorName"].ToString(),
                                    AppointmentDate = reader["AppointmentDate"].ToString(),
                                    AppointmentTime = reader["AppointmentTime"].ToString(),
                                    Status = reader["Status"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Помилка завантаження записів: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return list;
        }

        public static void CreateAppointment(int patientId, int doctorId, DateTime date, string time)
        {
            string sql = @"INSERT INTO Appointments (PatientID, UserID, AppointmentDate, AppointmentTime, Status) 
                           VALUES (@pid, @uid, @date, @time, 'Scheduled')";
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@pid", patientId);
                        command.Parameters.AddWithValue("@uid", doctorId);
                        command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@time", time);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Помилка створення запису: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        // =================================Schedules=================================
        public static DoctorScheduleModel GetDoctorSchedule(int doctorId, DateTime date)
        {
            string sql = "SELECT * FROM DoctorSchedules WHERE UserID = @uid AND WorkDate = @date";
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@uid", doctorId);
                        command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new DoctorScheduleModel
                                {
                                    ScheduleID = Convert.ToInt32(reader["ScheduleID"]),
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    WorkDate = reader["WorkDate"].ToString(),
                                    StartTime = reader["StartTime"].ToString(),
                                    EndTime = reader["EndTime"].ToString(),
                                    LunchStart = reader["LunchStart"].ToString(),
                                    LunchEnd = reader["LunchEnd"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Помилка розкладу: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return null;
        }


        // =================================Users=================================
        public static UserModel ValidateUser(string username, string password)
        {
            if (!File.Exists(_dbFileName))
            {
                MessageBox.Show("Критична помилка: Файл clinic.db не знайдено.", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            string passwordHash = PasswordHelper.ComputeHash(password);
            string sql = @"
            SELECT u.UserID, u.FullName, u.Specialization, r.RoleName 
            FROM Users u JOIN Roles r ON u.RoleID = r.RoleID
            WHERE u.Username = @user AND u.PasswordHash = @pass AND u.IsActive = 1;";

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
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Помилка при вході: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return null;
        }
    }
}