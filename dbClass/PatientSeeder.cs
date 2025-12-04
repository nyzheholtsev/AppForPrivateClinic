using System;
using System.Collections.Generic;
using System.Data.SQLite;
using program.Repositories; // Чтобы видеть BaseRepository

namespace program.dbClass
{
    public class PatientSeeder : BaseRepository
    {
        public void Seed(int count = 50)
        {
            var random = new Random();

            // Списки для генерации случайных имен
            string[] firstNames = { "Олександр", "Іван", "Михайло", "Андрій", "Дмитро", "Сергій", "Олена", "Марія", "Тетяна", "Юлія", "Наталія", "Світлана", "Вікторія", "Дарина" };
            string[] lastNames = { "Шевченко", "Коваленко", "Бондаренко", "Ткаченко", "Кравченко", "Олійник", "Шевчук", "Коваль", "Поліщук", "Бондар", "Мельник", "Мороз" };

            try
            {
                using (var connection = GetConnection())
                using (var transaction = connection.BeginTransaction())
                {
                    string sql = "INSERT INTO Patients (FullName, DateOfBirth, Contacts, CreatedDate) VALUES (@name, @dob, @phone, @created)";

                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        // Добавляем параметры заранее
                        command.Parameters.Add("@name", System.Data.DbType.String);
                        command.Parameters.Add("@dob", System.Data.DbType.String);
                        command.Parameters.Add("@phone", System.Data.DbType.String);
                        command.Parameters.Add("@created", System.Data.DbType.String);

                        for (int i = 0; i < count; i++)
                        {
                            // Генерация данных
                            string fName = firstNames[random.Next(firstNames.Length)];
                            string lName = lastNames[random.Next(lastNames.Length)];
                            string fullName = $"{lName} {fName}";

                            // Случайная дата рождения (возраст от 18 до 80)
                            DateTime start = new DateTime(1945, 1, 1);
                            int range = (DateTime.Today - start).Days - (18 * 365);
                            DateTime dob = start.AddDays(random.Next(range));

                            // Случайный телефон
                            string phone = $"+380{random.Next(50, 99)}{random.Next(1000000, 9999999)}";

                            // Установка значений
                            command.Parameters["@name"].Value = fullName;
                            command.Parameters["@dob"].Value = dob.ToString("yyyy-MM-dd");
                            command.Parameters["@phone"].Value = phone;
                            command.Parameters["@created"].Value = DateTime.Now.ToString("yyyy-MM-dd");

                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }

                System.Windows.Forms.MessageBox.Show($"Успішно додано {count} пацієнтів!", "Генерація даних");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Помилка генерації: {ex.Message}");
            }
        }
    }
}