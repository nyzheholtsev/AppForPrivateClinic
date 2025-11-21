using program.dbClass;
using System;
using System.Drawing;
using System.Windows.Forms;

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

            PaintMdiBackground();

            ApplyLocalization();

            SetupUiForRole();

            BindMenuEvents();
        }


        private void PaintMdiBackground()
        {
            foreach (Control control in this.Controls)
            {
                MdiClient client = control as MdiClient;
                if (client != null)
                {
                    client.BackColor = Color.FromArgb(68, 68, 68);
                    break;
                }
            }
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


        private void ApplyLocalization()
        {
            this.Text = string.Format(LocalizationManager.GetString("MainForm_Title"), _currentUser.RoleName);

            UserStatusLabel.Text = string.Format(LocalizationManager.GetString("MainForm_UserStatus"), _currentUser.FullName, _currentUser.RoleName);

            FileToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_File");
            FileExitToolStripMenuItem.Text = LocalizationManager.GetString("MainForm_Menu_File_Exit");

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


        private void BindMenuEvents()
        {

            FileExitToolStripMenuItem.Click += (s, e) => Application.Exit();
            PatientSearchToolStripMenuItem.Click += PatientSearchToolStripMenuItem_Click;

            PatientNewToolStripMenuItem.Click += (s, e) => MessageBox.Show("Тут буде форма 'Новий пацієнт'");
            ScheduleToolStripMenuItem.Click += (s, e) => MessageBox.Show("Тут буде форма 'Календар/Розклад'");
            MyQueueToolStripMenuItem.Click += (s, e) => MessageBox.Show("Тут буде форма 'Моя черга'");
            ManageUsersToolStripMenuItem.Click += (s, e) => MessageBox.Show("Тут буде форма 'Керування персоналом'");
            StatisticsToolStripMenuItem.Click += (s, e) => MessageBox.Show("Тут буде форма 'Статистика'");
        }


        private void PatientSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: проверить открытие

            PatientSearchForm searchForm = new PatientSearchForm(_currentUser);

            searchForm.MdiParent = this; 
            searchForm.Show();           
        }


        
        private class CustomMenuRenderer : ToolStripProfessionalRenderer
        {
            public CustomMenuRenderer() : base(new CustomColorTable()) { }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = Color.Wheat;
                base.OnRenderItemText(e);
            }
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

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}