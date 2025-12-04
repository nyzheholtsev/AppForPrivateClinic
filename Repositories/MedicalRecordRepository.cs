using program.dbClass;
using System.Data.SQLite;

namespace program.Repositories
{
    public class MedicalRecordRepository : BaseRepository
    {
        public MedicalRecordModel GetByAppointmentId(int appointmentId)
        {
            string sql = "SELECT * FROM MedicalRecords WHERE AppointmentID = @aid";
            try
            {
                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@aid", appointmentId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new MedicalRecordModel
                            {
                                MedicalRecordID = Convert.ToInt32(reader["MedicalRecordID"]),
                                AppointmentID = Convert.ToInt32(reader["AppointmentID"]),
                                Diagnosis = reader["Diagnosis"].ToString(),
                                Treatment = reader["Treatment"].ToString(),
                                Notes = reader["Notes"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public void SaveOrUpdate(int appointmentId, string diagnosis, string treatment, string notes)
        {
            var existing = GetByAppointmentId(appointmentId);
            string sql;

            if (existing == null)
            {
                sql = @"INSERT INTO MedicalRecords (AppointmentID, Diagnosis, Treatment, Notes) 
                        VALUES (@aid, @diag, @treat, @notes)";
            }
            else
            {
                sql = @"UPDATE MedicalRecords 
                        SET Diagnosis = @diag, Treatment = @treat, Notes = @notes 
                        WHERE AppointmentID = @aid";
            }

            try
            {
                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@aid", appointmentId);
                    command.Parameters.AddWithValue("@diag", diagnosis);
                    command.Parameters.AddWithValue("@treat", treatment);
                    command.Parameters.AddWithValue("@notes", notes);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження медкарти: {ex.Message}");
            }
        }
    }
}