using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace program.dbClass
{
    public static class DataSeeder
    {
        private static string _dbFileName = "clinic.db";
        private static string _connectionString = $"Data Source={_dbFileName};Version=3;";

        public static void SeedAllData()
        {
            if (!File.Exists(_dbFileName))
            {
                DbInitializer.Initialize();
            }

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        ExecuteSql(connection, "DELETE FROM MedicalRecords");
                        ExecuteSql(connection, "DELETE FROM Appointments");
                        ExecuteSql(connection, "DELETE FROM DoctorSchedules");
                        ExecuteSql(connection, "DELETE FROM Users");
                        ExecuteSql(connection, "DELETE FROM Patients");
                        ExecuteSql(connection, "DELETE FROM sqlite_sequence");

                        EnsureRoles(connection);


                        AddUser(connection, "ChiefDoctor", "Нижегольцев Владислав", "Хірург", "admin", "admin");
                        AddUser(connection, "Administrator", "Адміністратор Анна", "-", "reg", "reg");
                        var doc1Id = AddUser(connection, "Doctor", "Лікар Хаус", "Діагност", "doc", "doc");
                        var doc2Id = AddUser(connection, "Doctor", "Лікар Ватсон", "Терапевт", "doc2", "doc2");
                        var doc3Id = AddUser(connection, "Doctor", "Лікар Дулітл", "Ветеринар", "doc3", "doc3");

                        var doctorIds = new List<long> { doc1Id, doc2Id, doc3Id };

                        GeneratePatientsWithHistory(connection, doctorIds);

                        transaction.Commit();
                        System.Windows.Forms.MessageBox.Show("Дані успішно згенеровані! Перевірте статистику.", "Успіх");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        System.Windows.Forms.MessageBox.Show($"Помилка генерації: {ex.Message}");
                    }
                }
            }
        }

        private static void EnsureRoles(SQLiteConnection connection)
        {
            string[] roles = { "ChiefDoctor", "Doctor", "Administrator" };
            foreach (var role in roles)
            {
                ExecuteSql(connection, "INSERT OR IGNORE INTO Roles (RoleName) VALUES (@name)", new[] {
                    new SQLiteParameter("@name", role)
                });
            }
        }

        private static long AddUser(SQLiteConnection conn, string roleName, string fullName, string spec, string username, string password)
        {
            string hash = PasswordHelper.ComputeHash(password);
            string sql = @"
                INSERT INTO Users (RoleID, FullName, Specialization, Username, PasswordHash, IsActive) 
                VALUES (
                    (SELECT RoleID FROM Roles WHERE RoleName = @rname), 
                    @fname, @spec, @user, @hash, 1
                ); SELECT last_insert_rowid();";

            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@rname", roleName);
                cmd.Parameters.AddWithValue("@fname", fullName);
                cmd.Parameters.AddWithValue("@spec", spec);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@hash", hash);
                return (long)cmd.ExecuteScalar();
            }
        }

        private static void GeneratePatientsWithHistory(SQLiteConnection connection, List<long> doctorIds)
        {
            var names = new List<string>
            {
                "Бондаренко Іван", "Коваленко Петро", "Шевченко Марія",
                "Бойко Олена", "Кравченко Андрій", "Козак Наталія", "Олійник Дмитро", "Ковальчук Тетяна",
                "Поліщук Сергій", "Ткаченко Ольга", "Савченко Ігор", "Кузьменко Вікторія", "Лисенко Олег",
                "Мельник Юлія", "Гаврилюк Максим", "Павленко Світлана", "Хоменко Денис", "Пономаренко Ірина",
                "Василенко Роман", "Романюк Людмила", "Даниленко Володимир", "Марченко Оксана", "Руденко Євген",
                "Жук Валентина", "Вовк Анатолій", "Гончаренко Катерина", "Мороз Олександр", "Клименко Аліна",
                "Сидоренко Павло", "Кравчук Віра"
            };

            var diagnoses = new[] { "ГРВІ", "Грип", "Бронхіт", "Гастрит", "Мігрень", "Гіпертонія", "Алергія", "Отит" };
            var treatments = new[] { "Спокій, чай", "Антибіотики", "Дієта", "Знеболююче", "Вітаміни" };

            Random rnd = new Random();

            for (int i = 0; i < names.Count; i++)
            {
                string dob = DateTime.Now.AddYears(-rnd.Next(18, 60)).ToString("yyyy-MM-dd");
                string phone = $"+380{rnd.Next(900000000, 999999999)}";

                string insertPatSql = "INSERT INTO Patients (FullName, DateOfBirth, Contacts, CreatedDate) VALUES (@name, @dob, @cont, @date); SELECT last_insert_rowid();";
                long patientId;
                using (var cmd = new SQLiteCommand(insertPatSql, connection))
                {
                    cmd.Parameters.AddWithValue("@name", names[i]);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@cont", phone);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                    patientId = (long)cmd.ExecuteScalar();
                }

                int historyCount = (i < 3) ? 10 : rnd.Next(1, 3);

                for (int j = 0; j < historyCount; j++)
                {
                    long docId = doctorIds[rnd.Next(doctorIds.Count)];

                    DateTime visitDate = DateTime.Now.AddDays(-rnd.Next(0, 60));

                    string diag = diagnoses[rnd.Next(diagnoses.Length)];
                    string treat = treatments[rnd.Next(treatments.Length)];

                    string insertAppSql = @"
                        INSERT INTO Appointments (PatientID, UserID, AppointmentDate, AppointmentTime, Status) 
                        VALUES (@pid, @uid, @date, '10:00', 'Completed');
                        SELECT last_insert_rowid();";

                    long appId;
                    using (var cmd = new SQLiteCommand(insertAppSql, connection))
                    {
                        cmd.Parameters.AddWithValue("@pid", patientId);
                        cmd.Parameters.AddWithValue("@uid", docId);
                        cmd.Parameters.AddWithValue("@date", visitDate.ToString("yyyy-MM-dd"));
                        appId = (long)cmd.ExecuteScalar();
                    }

                    string insertMedSql = @"
                        INSERT INTO MedicalRecords (AppointmentID, Diagnosis, Treatment, Notes) 
                        VALUES (@aid, @diag, @treat, 'Тестовий запис генератора');";

                    using (var cmd = new SQLiteCommand(insertMedSql, connection))
                    {
                        cmd.Parameters.AddWithValue("@aid", appId);
                        cmd.Parameters.AddWithValue("@diag", diag);
                        cmd.Parameters.AddWithValue("@treat", treat);
                        cmd.ExecuteNonQuery();
                    }
                }
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