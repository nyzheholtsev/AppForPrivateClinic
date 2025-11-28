
using program.dbClass.Models;
using program.Localization;
using program.Repositories;


namespace program
{
    public partial class PatientSearchForm : Form, Localizable
    {   

        private UserModel _currentUser;
        private readonly PatientRepository _patientRepository;

        public PatientSearchForm(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;
            _patientRepository = new PatientRepository();

            this.FormBorderStyle = FormBorderStyle.None; // - края
            UpdateLocalization();
        }

        public void UpdateLocalization()
        {
            SearchButton.Text = LocalizationManager.GetString("PatientSearchForm_SearchButton");
            PathientFullNameColumn.HeaderText = LocalizationManager.GetString("PatientSearchForm_Column_FullName");
            PathientDateOfBirthColumn.HeaderText = LocalizationManager.GetString("PatientSearchForm_Column_DateOfBirth");
            PathientContactColumn.HeaderText = LocalizationManager.GetString("PatientSearchForm_Column_Contact");
        }
        private void PatientSearchForm_Load(object sender, EventArgs e)
        {
            PatientsDataGridView.ReadOnly = true;
            PatientsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PatientsDataGridView.AllowUserToAddRows = false;
            PatientsDataGridView.AutoGenerateColumns = false;
            PatientsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            PatientsDataGridView.EnableHeadersVisualStyles = false;
            PatientsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            PatientsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Wheat;
            PatientsDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 10, FontStyle.Bold);
            PatientsDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.DimGray;

            PerformSearch();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string query = SearchTextBox.Text;

            PatientsDataGridView.DataSource = _patientRepository.Search(query);
            PerformSearch();
        }

        private void PerformSearch()
        {
            string query = SearchTextBox.Text;
            PatientsDataGridView.DataSource = _patientRepository.Search(query);
        }

    }
}