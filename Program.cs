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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DbInitializer.Initialize();

            //PatientSeeder seeder = new PatientSeeder();
            //seeder.Seed(50);
          
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