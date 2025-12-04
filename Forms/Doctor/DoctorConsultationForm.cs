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

            btnFinish.Text = LocalizationManager.GetString("DoctorConsultation_Btn_Finish");
            btnEdit.Text = LocalizationManager.GetString("DoctorConsultation_Btn_Edit");
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

            if (_appointment.StatusEnum == AppointmentStatus.Completed)
            {
                SetFieldsEnabled(false);
                btnFinish.Enabled = false;
                btnEdit.Visible = true;
            }
            else
            {
                SetFieldsEnabled(true);
                btnFinish.Enabled = true;
                btnEdit.Visible = false;
            }
        }

        private void SetFieldsEnabled(bool enabled)
        {
            txtDiagnosis.ReadOnly = !enabled;
            txtTreatment.ReadOnly = !enabled;
            txtNotes.ReadOnly = !enabled;
            Color backColor = enabled ? Color.Wheat : Color.Silver;
            txtDiagnosis.BackColor = backColor;
            txtTreatment.BackColor = backColor;
            txtNotes.BackColor = backColor;
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

            MessageBox.Show(LocalizationManager.GetString("DoctorConsultation_Msg_Success"),
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetFieldsEnabled(true);
            btnFinish.Enabled = true;
            btnEdit.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}