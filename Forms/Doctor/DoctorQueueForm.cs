using program.dbClass;
using program.dbClass.Models;
using program.Localization;
using program.Repositories;
using System.Data;

namespace program.Forms.Doctor
{
    public partial class DoctorQueueForm : Form, Localizable
    {
        private UserModel _currentUser;
        private AppointmentRepository _repo;
        private AppointmentModel _nextAppointment;

        public DoctorQueueForm(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;
            _repo = new AppointmentRepository();

            dgvQueue.AutoGenerateColumns = false;
            dgvQueue.EnableHeadersVisualStyles = false;

            dgvQueue.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgvQueue.ColumnHeadersDefaultCellStyle.ForeColor = Color.Wheat;
            dgvQueue.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 10, FontStyle.Bold);
            dgvQueue.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.DimGray;

 
            dgvQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            dgvQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            UpdateLocalization();
        }

        public void UpdateLocalization()
        {
            this.Text = LocalizationManager.GetString("DoctorQueue_Title");

            if (dgvQueue.Columns["colTime"] != null)
                dgvQueue.Columns["colTime"].HeaderText = LocalizationManager.GetString("DoctorQueue_Col_Time");

            if (dgvQueue.Columns["colPatient"] != null)
                dgvQueue.Columns["colPatient"].HeaderText = LocalizationManager.GetString("DoctorQueue_Col_Patient");

            if (dgvQueue.Columns["colStatus"] != null)
                dgvQueue.Columns["colStatus"].HeaderText = LocalizationManager.GetString("DoctorQueue_Col_Status");

            btnPatientAbsent.Text = LocalizationManager.GetString("DoctorQueue_Btn_Absent");

            UpdateNextPatientUI();
        }

        private void DoctorQueueForm_Load(object sender, EventArgs e)
        {
            
            LoadQueue();
        }

        public void LoadQueue()
        {
            var all = _repo.GetAppointments(_currentUser.UserID, DateTime.Now);
            dgvQueue.DataSource = all;

            _nextAppointment = all
                .Where(a => a.StatusEnum == AppointmentStatus.Scheduled || a.StatusEnum == AppointmentStatus.InProgress)
                .OrderBy(a => a.AppointmentTime)
                .FirstOrDefault();

            UpdateNextPatientUI();
        }

        private void UpdateNextPatientUI()
        {
            if (_nextAppointment != null)
            {
                lblNextPatientName.Text = _nextAppointment.PatientName;
                lblNextTime.Text = $"{LocalizationManager.GetString("DoctorQueue_Col_Time")}: {_nextAppointment.AppointmentTime}";

                if (_nextAppointment.StatusEnum == AppointmentStatus.InProgress)
                {
                    btnStartAppointment.Text = LocalizationManager.GetString("DoctorQueue_Btn_Continue");
                }
                else
                {
                    btnStartAppointment.Text = LocalizationManager.GetString("DoctorQueue_Btn_Start");
                }

                btnStartAppointment.Enabled = true;
                btnPatientAbsent.Enabled = true;
            }
            else
            {
                lblNextPatientName.Text = LocalizationManager.GetString("DoctorQueue_Empty");
                lblNextTime.Text = "--:--";
                btnStartAppointment.Text = LocalizationManager.GetString("DoctorQueue_Btn_Start");
                btnStartAppointment.Enabled = false;
                btnPatientAbsent.Enabled = false;
            }
        }

        private void btnStartAppointment_Click(object sender, EventArgs e)
        {
            if (_nextAppointment == null) return;

            if (_nextAppointment.StatusEnum == AppointmentStatus.Scheduled)
            {
                _repo.UpdateStatus(_nextAppointment.AppointmentID, AppointmentStatus.InProgress);
            }

            DoctorConsultationForm consultationForm = new DoctorConsultationForm(_nextAppointment);
            consultationForm.TopLevel = false;          
            consultationForm.FormBorderStyle = FormBorderStyle.None; 
            consultationForm.Dock = DockStyle.Fill;   
            this.Controls.Add(consultationForm);      
            consultationForm.Show();

            LoadQueue();
        }

        private void btnPatientAbsent_Click_1(object sender, EventArgs e)
        {
            if (_nextAppointment == null) return;

            string msg = string.Format(LocalizationManager.GetString("DoctorQueue_Msg_AbsentConfirm"), _nextAppointment.PatientName);

            var result = MessageBox.Show(msg,
                                         "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _repo.UpdateStatus(_nextAppointment.AppointmentID, AppointmentStatus.Cancelled);
                LoadQueue();
            }
        }
    }
}