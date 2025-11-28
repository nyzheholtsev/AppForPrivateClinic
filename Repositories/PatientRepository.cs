using program.dbClass;
using System.Data.SQLite;

namespace program.Repositories
{
    public class PatientRepository : BaseRepository
    {
        public List<PatientModel> Search(string query)
        {
            var list = new List<PatientModel>();
            string sql = @"SELECT * FROM Patients WHERE FullName LIKE @query LIMIT 50;";

            try
            {
                using (var connection = GetConnection())
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
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка пошуку: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}