using program.dbClass;
using program.Localization;
using program.Repositories;

namespace program.Forms.Doctor
{
    public partial class DoctorConsultationForm : Form, Localizable
    {
        private AppointmentModel _appointment;
        private MedicalRecordRepository _recordRepo;
        private AppointmentRepository _apptRepo;

        public DoctorConsultationForm(AppointmentModel appointment)
        {
            InitializeComponent();
            _appointment = appointment;
            _recordRepo = new MedicalRecordRepository();
            _apptRepo = new AppointmentRepository();

            UpdateLocalization();
            SetupUI();
        }

        public void UpdateLocalization()
        {
            this.Text = LocalizationManager.GetString("DoctorConsultation_Title");

            lblDiagnos.Text = LocalizationManager.GetString("DoctorConsultation_Label_Diagnosis");
            lblTreatment.Text = LocalizationManager.GetString("DoctorConsultation_Label_Treatment");
            lblNote.Text = LocalizationManager.GetString("DoctorConsultation_Label_Notes");
            btnHistory.Text = LocalizationManager.GetString("DoctorConsultation_Btn_History");
            btnFinish.Text = LocalizationManager.GetString("DoctorConsultation_Btn_Finish");
            btnClose.Text = LocalizationManager.GetString("DoctorConsultation_Btn_Close");
        }

        private void SetupUI()
        {
            lblPatientInfo.Text = $"{_appointment.PatientName} ({_appointment.AppointmentTime})";
            var record = _recordRepo.GetByAppointmentId(_appointment.AppointmentID);

            if (record != null)
            {
                txtDiagnosis.Text = record.Diagnosis;
                txtTreatment.Text = record.Treatment;
                txtNotes.Text = record.Notes;
            }

            btnFinish.Enabled = true;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            _recordRepo.SaveOrUpdate(
                _appointment.AppointmentID,
                txtDiagnosis.Text,
                txtTreatment.Text,
                txtNotes.Text
            );

            _apptRepo.UpdateStatus(_appointment.AppointmentID, AppointmentStatus.Completed);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _recordRepo.SaveOrUpdate(
                _appointment.AppointmentID,
                txtDiagnosis.Text,
                txtTreatment.Text,
                txtNotes.Text
            );

            this.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            PatientHistoryForm historyForm = new PatientHistoryForm(_appointment.PatientID);
            historyForm.ShowDialog();
        }
    }
}