using program.dbClass;
using program.dbClass.Models; // Для DoctorScheduleModel
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace program.Repositories
{
    public class DoctorScheduleRepository : BaseRepository
    {
        public void Save(int doctorId, DateTime date, string start, string end, string lStart, string lEnd)
        {
            // Проверяем, есть ли уже запись
            var existing = GetSchedule(doctorId, date);
            string sql;

            if (existing == null)
            {
                sql = @"INSERT INTO DoctorSchedules (UserID, WorkDate, StartTime, EndTime, LunchStart, LunchEnd)
                VALUES (@uid, @date, @start, @end, @lStart, @lEnd)";
            }
            else
            {
                sql = @"UPDATE DoctorSchedules 
                SET StartTime = @start, EndTime = @end, LunchStart = @lStart, LunchEnd = @lEnd
                WHERE ScheduleID = @id";
            }

            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@uid", doctorId);
                cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                cmd.Parameters.AddWithValue("@lStart", lStart);
                cmd.Parameters.AddWithValue("@lEnd", lEnd);
                if (existing != null) cmd.Parameters.AddWithValue("@id", existing.ScheduleID);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int doctorId, DateTime date)
        {
            string sql = "DELETE FROM DoctorSchedules WHERE UserID = @uid AND WorkDate = @date";
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@uid", doctorId);
                cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
            }
        }

        public void AutoGenerate(int doctorId, int year, int month)
        {
            // Удаляем старое расписание на этот месяц (чтобы не было дублей)
            string deleteSql = @"DELETE FROM DoctorSchedules 
                         WHERE UserID = @uid AND strftime('%Y-%m', WorkDate) = @ym";

            // Стандарт: 09:00-17:00, обед 13:00-14:00
            string insertSql = @"INSERT INTO DoctorSchedules (UserID, WorkDate, StartTime, EndTime, LunchStart, LunchEnd)
                         VALUES (@uid, @date, '09:00', '17:00', '13:00', '14:00')";

            using (var conn = GetConnection())
            using (var trans = conn.BeginTransaction())
            {
                try
                {
                    // 1. Чистка
                    using (var cmdDel = new SQLiteCommand(deleteSql, conn))
                    {
                        cmdDel.Parameters.AddWithValue("@uid", doctorId);
                        cmdDel.Parameters.AddWithValue("@ym", $"{year}-{month:00}");
                        cmdDel.ExecuteNonQuery();
                    }

                    // 2. Генерация
                    int days = DateTime.DaysInMonth(year, month);
                    using (var cmdIns = new SQLiteCommand(insertSql, conn))
                    {
                        cmdIns.Parameters.AddWithValue("@uid", doctorId);
                        var pDate = cmdIns.Parameters.Add("@date", System.Data.DbType.String);

                        for (int day = 1; day <= days; day++)
                        {
                            DateTime dt = new DateTime(year, month, day);
                            if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday) continue;

                            pDate.Value = dt.ToString("yyyy-MM-dd");
                            cmdIns.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                }
                catch { trans.Rollback(); throw; }
            }
        }

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