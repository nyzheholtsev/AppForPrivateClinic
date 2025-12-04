using program.dbClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace program.Repositories
{
    public class StatisticsRepository : BaseRepository
    {
        // Отчет 1: Загрузка врачей (Топ по количеству завершенных приемов)
        public DataTable GetDoctorWorkload(DateTime start, DateTime end)
        {
            string sql = @"
                SELECT u.FullName AS 'Doctor Name', COUNT(a.AppointmentID) AS 'Patients Count'
                FROM Appointments a
                JOIN Users u ON a.UserID = u.UserID
                WHERE a.Status = 'Completed' 
                  AND date(a.AppointmentDate) BETWEEN date(@start) AND date(@end)
                GROUP BY u.UserID, u.FullName
                ORDER BY COUNT(a.AppointmentID) DESC";

            return ExecuteQuery(sql, start, end);
        }

        // Отчет 2: Количество приемов по дням
        public DataTable GetVisitsByDate(DateTime start, DateTime end)
        {
            string sql = @"
                SELECT AppointmentDate AS 'Date', COUNT(*) AS 'Total Visits'
                FROM Appointments
                WHERE Status = 'Completed'
                  AND date(AppointmentDate) BETWEEN date(@start) AND date(@end)
                GROUP BY AppointmentDate
                ORDER BY AppointmentDate";

            return ExecuteQuery(sql, start, end);
        }

        // Отчет 3: Статистика диагнозов
        public DataTable GetDiagnosisStats(DateTime start, DateTime end)
        {
            // Связываем MedicalRecords -> Appointments, чтобы фильтровать по дате
            string sql = @"
                SELECT m.Diagnosis, COUNT(*) AS 'Count'
                FROM MedicalRecords m
                JOIN Appointments a ON m.AppointmentID = a.AppointmentID
                WHERE date(a.AppointmentDate) BETWEEN date(@start) AND date(@end)
                GROUP BY m.Diagnosis
                ORDER BY COUNT(*) DESC";

            return ExecuteQuery(sql, start, end);
        }

        private DataTable ExecuteQuery(string sql, DateTime start, DateTime end)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@start", start.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@end", end.ToString("yyyy-MM-dd"));

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Логирование можно добавить сюда
                System.Windows.Forms.MessageBox.Show("Error loading stats: " + ex.Message);
            }
            return dt;
        }
    }
}