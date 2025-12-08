using program.dbClass;
using program.dbClass.Models;
using System;
using System.Windows.Forms;

namespace program
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.ThreadException += (s, e) => Logger.LogError("Critical UI Error", e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => Logger.LogError("Critical Non-UI Error", (Exception)e.ExceptionObject);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DbInitializer.Initialize();

            //DataSeeder.SeedAllData();

            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    UserModel loggedInUser = loginForm.LoggedInUser;
                    string currentLang = loginForm.CurrentLang;

                    Application.Run(new MainForm(loggedInUser, currentLang));
                }
            }
        }
    }
}