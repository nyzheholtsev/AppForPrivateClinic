using program.dbClass;
using program.Localization;
using System;
using System.Windows.Forms;

namespace program
{
    public partial class PatientSearchForm : Form, Localizable
    {
        private UserModel _currentUser;

        public PatientSearchForm(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;

            this.FormBorderStyle = FormBorderStyle.None; // - края
            UpdateLocalization();
        }

        public void UpdateLocalization()
        {
            SearchButton.Text = LocalizationManager.GetString("PatientSearchForm_SearchButton");
            NewPatientButton.Text = LocalizationManager.GetString("PatientSearchForm_NewButton");
        }
        private void PatientSearchForm_Load(object sender, EventArgs e)
        {
            PatientsDataGridView.ReadOnly = true;
            PatientsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PatientsDataGridView.AllowUserToAddRows = false;
            PatientsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // TODO: настроить кнопки под роль

            if (_currentUser.RoleName == "Лікар")
            {
                NewPatientButton.Visible = false;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string query = SearchTextBox.Text;

            PatientsDataGridView.DataSource = DatabaseHelper.SearchPatients(query);

            if (PatientsDataGridView.Columns.Count > 0)
            {
                PatientsDataGridView.Columns["PatientID"].HeaderText = "ID";
                PatientsDataGridView.Columns["FullName"].HeaderText = "ПІБ";
                PatientsDataGridView.Columns["DateOfBirth"].HeaderText = "Дата нар.";
                PatientsDataGridView.Columns["Contacts"].HeaderText = "Контакти";
            }
        }

        private void NewPatientButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тут будет открыта форма 'Новий пацієнт'");
        }


    }
}