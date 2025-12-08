using System;
using System.IO;
using System.Windows.Forms;

namespace program
{
    public static class Logger
    {
        private static string _logPath = Path.Combine(Application.StartupPath, "Logs");

        static Logger()
        {
            if (!Directory.Exists(_logPath))
                Directory.CreateDirectory(_logPath);
        }

        public static void Log(string action, string username = "System")
        {
            try
            {
                string fileName = Path.Combine(_logPath, $"log_{DateTime.Now:yyyy-MM-dd}.txt");
                string logMessage = $"[{DateTime.Now:HH:mm:ss}] [{username}] {action}";

                File.AppendAllText(fileName, logMessage + Environment.NewLine);
            }
            catch {}
        }

        public static void LogError(string message, Exception ex)
        {
            Log($"ERROR: {message}. Details: {ex.Message}\nStack: {ex.StackTrace}");
        }
    }
}