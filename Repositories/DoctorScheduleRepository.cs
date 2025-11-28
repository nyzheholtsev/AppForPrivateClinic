using program.dbClass;
using program.dbClass.Models; // Для DoctorScheduleModel
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace program.Repositories
{
    public class DoctorScheduleRepository : BaseRepository
    {
        public DoctorScheduleModel GetSchedule(int doctorId, DateTime date)
        {
            string sql = "SELECT * FROM DoctorSchedules WHERE UserID = @uid AND WorkDate = @date";
            try
            {
                using (var connection = GetConnection())
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
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка розкладу: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}