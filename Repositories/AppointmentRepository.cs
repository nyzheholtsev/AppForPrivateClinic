using program.dbClass;
using System.Data.SQLite;
    
namespace program.Repositories
{
    public class AppointmentRepository : BaseRepository
    {
        public List<AppointmentModel> GetAppointments(int doctorId, DateTime date)
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
                using (var connection = GetConnection())
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
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження записів: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public void Create(int patientId, int doctorId, DateTime date, string time)
        {
            string sql = @"INSERT INTO Appointments (PatientID, UserID, AppointmentDate, AppointmentTime, Status) 
                           VALUES (@pid, @uid, @date, @time, 'Scheduled')";
            try
            {
                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@pid", patientId);
                    command.Parameters.AddWithValue("@uid", doctorId);
                    command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@time", time);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка створення запису: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}