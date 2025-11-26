using program.dbClass.Models;
using program.Forms;
using program.Localization;

namespace program
{
    public partial class MainForm : Form
    {
        private UserModel _currentUser;
        private string _currentLang;

        public MainForm(UserModel user, string language)
        {
            _currentUser = user;
            _currentLang = language;
                
            InitializeComponent();

            this.Load += new System.EventHandler(this.MainForm_Load);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            MainMenuStrip.Renderer = new CustomMenuRenderer();

            MainStatusStrip.Dock = DockStyle.Bottom;
            MainStatusStrip.BringToFront();

            LocalizationManager.LoadLanguage(_currentLang);
            ApplyLocalization();
            SetupUiForRole();
            BindMenuEvents();
           
        }

        private void ApplyLocalization()
        {
            this.Text = string.Format(LocalizationManager.GetString("MainForm_Title"), _currentUser.RoleName);

            UserStatusLabel.Text = string.Format(LocalizationManager.GetString("MainForm_UserStatus"), _currentUser.FullName, _currentUser.RoleName);

            FileToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_File");
            FileExitToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_File_Exit");
            FileLangChangeToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_File_LangChange");

            RegistrarToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_Registrar");
            PatientSearchToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_Registrar_Search");
            PatientNewToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_Registrar_New");
            ScheduleToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_Registrar_Schedule");

            DoctorToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_Doctor");
            MyQueueToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_Doctor_Queue");

            AdminToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_Admin");
            ManageUsersToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_Admin_Users");
            StatisticsToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_Admin_Stats");
        }

        private void SetupUiForRole()
        {

            RegistrarToolStripMenuItem.Visible = false;
            DoctorToolStripMenuItem.Visible = false;
            AdminToolStripMenuItem.Visible = false;


            switch (_currentUser.RoleName)
            {
                case "Головний Лікар":

                    RegistrarToolStripMenuItem.Visible = true;
                    DoctorToolStripMenuItem.Visible = true;
                    AdminToolStripMenuItem.Visible = true;
                    break;

                case "Лікар":
                    RegistrarToolStripMenuItem.Visible = true;
                    PatientNewToolStripMenuItem.Visible = false;
                    ScheduleToolStripMenuItem.Visible = false;
                    DoctorToolStripMenuItem.Visible = true;
                    break;

                case "Адміністратор":
                    RegistrarToolStripMenuItem.Visible = true;
                    break;
            }
        }

        private void BindMenuEvents()
        {

            FileExitToolStripMenuItem.Click += (s, e) => Application.Exit();
            PatientSearchToolStripMenuItem.Click += PatientSearchToolStripMenuItem_Click;
            PatientNewToolStripMenuItem.Click += PatientNewToolStripMenuItem_Click;
            ScheduleToolStripMenuItem.Click += (s, e) => MessageBox.Show("Тут буде форма 'Календар/Розклад'");
            MyQueueToolStripMenuItem.Click += (s, e) => MessageBox.Show("Тут буде форма 'Моя черга'");
            ManageUsersToolStripMenuItem.Click += (s, e) => MessageBox.Show("Тут буде форма 'Керування персоналом'");
            StatisticsToolStripMenuItem.Click += (s, e) => MessageBox.Show("Тут буде форма 'Статистика'");
        }

        private class CustomColorTable : ProfessionalColorTable
        {

            private Color _defaultGray = Color.FromArgb(68, 68, 68);

            private Color _hoverGray = Color.FromArgb(90, 90, 90);

            public override Color ToolStripDropDownBackground
            {
                get { return _defaultGray; }
            }

            public override Color MenuStripGradientBegin
            {
                get { return _defaultGray; }
            }

            public override Color MenuStripGradientEnd
            {
                get { return _defaultGray; }
            }

            public override Color MenuItemSelected
            {
                get { return _hoverGray; }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get { return _hoverGray; }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get { return _hoverGray; }
            }

            public override Color MenuItemBorder
            {
                get { return _hoverGray; }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get { return _hoverGray; }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get { return _hoverGray; }
            }

            public override Color ImageMarginGradientBegin
            {
                get { return _defaultGray; }
            }
            public override Color ImageMarginGradientMiddle
            {
                get { return _defaultGray; }
            }

            public override Color ImageMarginGradientEnd
            {
                get { return _defaultGray; }
            }
        }



        private void OpenPage(Form newForm)
        {
            List<Control> controlsToRemove = new List<Control>(); // поиск + удаления =- старые формы

            foreach (Control c in this.Controls)
            {
                if (c is Form) // if c == Form открытая форма
                {
                    controlsToRemove.Add(c);
                }
            }

            foreach (Control c in controlsToRemove)
            {
                this.Controls.Remove(c);
                c.Dispose();
            } // удалили + очистили


            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;


            this.Controls.Add(newForm);
            newForm.Show();

            MainMenuStrip.BringToFront();
            MainStatusStrip.BringToFront();
        }

        private class CustomMenuRenderer : ToolStripProfessionalRenderer // кастом рендеринг
        {
            public CustomMenuRenderer() : base(new CustomColorTable()) { }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = Color.Wheat;
                base.OnRenderItemText(e);
            }
        }




        private void FileLangChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentLang = (_currentLang == "ukr") ? "eng" : "ukr";
            LocalizationManager.LoadLanguage(_currentLang);
            ApplyLocalization();

            foreach (Control c in this.Controls) // пробегаемся
            {
                if (c is Localizable localizableForm)
                {
                    localizableForm.UpdateLocalization();
                }
            }
        }
        private void PatientSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientSearchForm searchForm = new PatientSearchForm(_currentUser);
            OpenPage(new PatientSearchForm(_currentUser));
        }

        private void PatientNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientAddForm searchForm = new PatientAddForm(_currentUser);
            OpenPage(new PatientAddForm(_currentUser));
        }
    }
}