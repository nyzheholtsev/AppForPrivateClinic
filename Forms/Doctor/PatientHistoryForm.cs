using program.Localization;
using program.Repositories;

namespace program.Forms.Doctor
{

    public partial class PatientHistoryForm : Form
    {
        private int _patientId;
        private MedicalRecordRepository _repo;

        public PatientHistoryForm(int patientId)
        {
            InitializeComponent(); 
            _patientId = patientId;
            _repo = new MedicalRecordRepository();

            SetupGridStyles();
            UpdateLocalization();
            LoadHistory();
        }
        public void UpdateLocalization()
        {
            this.Text = LocalizationManager.GetString("History_Title");

            if (dgvHistory.Columns["colDate"] != null)
                dgvHistory.Columns["colDate"].HeaderText = LocalizationManager.GetString("History_Col_Date");

            if (dgvHistory.Columns["colDiagnosis"] != null)
                dgvHistory.Columns["colDiagnosis"].HeaderText = LocalizationManager.GetString("History_Col_Diagnosis");

            if (dgvHistory.Columns["colTreatment"] != null)
                dgvHistory.Columns["colTreatment"].HeaderText = LocalizationManager.GetString("History_Col_Treatment");

            if (dgvHistory.Columns["colNotes"] != null)
                dgvHistory.Columns["colNotes"].HeaderText = LocalizationManager.GetString("History_Col_Notes");
        }

        private void SetupGridStyles()
        {
            if (dgvHistory == null) return;

            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.Wheat;
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 10, FontStyle.Bold);

            dgvHistory.DefaultCellStyle.BackColor = Color.Gray;
            dgvHistory.DefaultCellStyle.ForeColor = Color.Wheat;
            dgvHistory.DefaultCellStyle.Font = new Font("Palatino Linotype", 10);
            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.Gray;
            dgvHistory.DefaultCellStyle.SelectionForeColor = Color.Wheat;
        }

        private void LoadHistory()
        {
            var history = _repo.GetHistoryByPatientId(_patientId);

            if (dgvHistory != null)
            {
                dgvHistory.DataSource = history;
            }
        }
    }
}