using program.dbClass;
using System.Data.SQLite;

namespace program.Repositories
{
    public class PatientRepository : BaseRepository
    {
        public List<PatientModel> Search(string query)
        {
            var list = new List<PatientModel>();

            if (string.IsNullOrWhiteSpace(query))
            {
                return GetRecentPatients();
            }

            string sql = "SELECT * FROM Patients";

            try
            {
                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = new PatientModel
                            {
                                PatientID = Convert.ToInt32(reader["PatientID"]),
                                FullName = reader["FullName"].ToString(),
                                DateOfBirth = DateTime.TryParse(reader["DateOfBirth"].ToString(), out DateTime dt) ? dt : DateTime.MinValue,
                                Contacts = reader["Contacts"].ToString(),
                                CreatedDate = reader["CreatedDate"].ToString()
                            };

                            if (p.FullName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                p.Contacts.Contains(query))
                            {
                                list.Add(p);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка пошуку: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return list.Take(50).ToList();
        }

        private List<PatientModel> GetRecentPatients()
        {
            var list = new List<PatientModel>();
            string sql = "SELECT * FROM Patients ORDER BY PatientID DESC LIMIT 50";
            try
            {
                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(sql, connection))
                {
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
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}");
            }
            return list;
        }

        public void Add(string fullName, DateTime dateOfBirth, string contacts)
        {
            string sql = "INSERT INTO Patients (FullName, DateOfBirth, Contacts, CreatedDate) VALUES (@name, @dob, @phone, @date)";
            try
            {
                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", fullName);
                    command.Parameters.AddWithValue("@dob", dateOfBirth.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@phone", contacts);
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка додавання: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<PatientModel> GetAllPatients()
        {
            var list = new List<PatientModel>();
            string sql = "SELECT PatientID, FullName FROM Patients ORDER BY FullName";

            try
            {
                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PatientModel
                            {
                                PatientID = Convert.ToInt32(reader["PatientID"]),
                                FullName = reader["FullName"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження пацієнтів: {ex.Message}");
            }
            return list;
        }
    }
}