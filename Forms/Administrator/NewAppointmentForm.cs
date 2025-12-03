using program.dbClass.Models;
using program.Localization;
using program.Repositories;

namespace program.Forms.Administrator
{
    public partial class NewAppointmentForm : Form, Localizable
    {
        private UserModel _currentUser;

        private string _selectedTime;
        private readonly PatientRepository _patientRepository;
        private readonly UserRepository _userRepository;
        private readonly AppointmentRepository _appointmentRepository;
        private readonly DoctorScheduleRepository _scheduleRepository;
        private string _doctor_not_have_A;

        public NewAppointmentForm(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;
            UpdateLocalization();

            _patientRepository = new PatientRepository();
            _userRepository = new UserRepository();
            _appointmentRepository = new AppointmentRepository();
            _scheduleRepository = new DoctorScheduleRepository();

            LoadData();

            dtpDate.MinDate = DateTime.Now;
            cmbPatients.SelectedIndexChanged += (s, e) => UpdateBookButtonState();
            cmbDoctors.SelectedIndexChanged += (s, e) =>
            {
                GenerateTimeSlots();
                UpdateBookButtonState();
            };

            {
                GenerateTimeSlots();
                UpdateBookButtonState();
            };
        } 

        public void UpdateLocalization()
        {
            lblPathient.Text = LocalizationManager.GetString("NewAppointmentForm_Label_Patient");
            lblDoctor.Text = LocalizationManager.GetString("NewAppointmentForm_Label_Doctor");
            lblDate.Text = LocalizationManager.GetString("NewAppointmentForm_Label_Date");
            lblTime.Text = LocalizationManager.GetString("NewAppointmentForm_Label_Time");
            btnBook.Text = LocalizationManager.GetString("NewAppointmentForm_Button_Add");
            lblGlobalData.Text = LocalizationManager.GetString("NewAppointmentForm_Labell_GD");
            _doctor_not_have_A = LocalizationManager.GetString("NewAppointmentForm_Label_haveNoAppointment");
        }

        private void UpdateBookButtonState()
        {
            bool isPatientSelected = cmbPatients.SelectedIndex > -1;
            bool isDoctorSelected = cmbDoctors.SelectedIndex > -1;
            bool isTimeSelected = !string.IsNullOrEmpty(_selectedTime);

            bool isReady = isPatientSelected && isDoctorSelected && isTimeSelected;

            btnBook.Enabled = isReady;
            btnBook.ForeColor = isReady ? Color.Wheat : Color.DimGray;
        }

        private void GenerateTimeSlots()
        {
            flowLayoutPanel1.Controls.Clear();
            _selectedTime = null;
            UpdateBookButtonState();

            if (cmbDoctors.SelectedIndex == -1 || cmbDoctors.SelectedValue == null) return;
            if (!int.TryParse(cmbDoctors.SelectedValue.ToString(), out int doctorId)) return;

            DateTime date = dtpDate.Value;

            var schedule = _scheduleRepository.GetSchedule(doctorId, date);
            if (schedule == null)
            {
                Label lbl = new Label { Text = _doctor_not_have_A,
                    AutoSize = true, 
                    ForeColor = Color.Wheat, 
                    Font = new Font("Segoe UI", 10) };
                flowLayoutPanel1.Controls.Add(lbl);
                return;
            }

            var appointments = _appointmentRepository.GetAppointments(doctorId, date);
            HashSet<string> busyTimes = new HashSet<string>(appointments.Select(a => a.AppointmentTime));

            TimeSpan start = TimeSpan.Parse(schedule.StartTime);
            TimeSpan end = TimeSpan.Parse(schedule.EndTime);
            TimeSpan lunchStart = TimeSpan.Parse(schedule.LunchStart);
            TimeSpan lunchEnd = TimeSpan.Parse(schedule.LunchEnd);
            TimeSpan step = TimeSpan.FromMinutes(30);

            while (start < end)
            {
                TimeSpan next = start.Add(step);

                if (next > end) break;

                string timeStr = start.ToString(@"hh\:mm");


                bool isLunch = (start >= lunchStart && start < lunchEnd);
                bool isBusy = busyTimes.Contains(timeStr);
                bool isPast = (date.Date == DateTime.Now.Date && start < DateTime.Now.TimeOfDay);

                bool isAvailable = !isLunch && !isBusy && !isPast;

                Button btn = CreateSlotButton(timeStr, isAvailable);
                flowLayoutPanel1.Controls.Add(btn);

                start = next;
            }
        }

        private Button CreateSlotButton(string time, bool isAvailable)
        {
            Button btn = new Button();
            btn.Text = time;
            btn.Width = 45;
            btn.Height = 25;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Tag = isAvailable;

            if (isAvailable)
            {
                //доступные
                btn.BackColor = Color.Wheat;
                btn.ForeColor = Color.Black;
                btn.Cursor = Cursors.Hand;

                //доступные
                btn.Click += (s, e) =>
                {
                    
                    foreach (Control c in flowLayoutPanel1.Controls)
                    {
                        if (c is Button b)
                        {
                            bool wasAvailable = (bool)b.Tag;
                            b.BackColor = wasAvailable ? Color.Wheat : Color.Silver;
                        }
                    }

                    btn.BackColor = Color.Orange; //выбраная
                    _selectedTime = time;

                    UpdateBookButtonState();
                };
            }
            else
            {
                //нету
                btn.BackColor = Color.Silver; 
                btn.ForeColor = Color.DimGray;
                btn.Cursor = Cursors.No;
                                        
            }

            return btn;
        }

        private void LoadData()
        {
            var patients = _patientRepository.GetAllPatients();
            cmbPatients.DataSource = patients;
            cmbPatients.DisplayMember = "FullName";
            cmbPatients.ValueMember = "PatientID";

            cmbPatients.AutoCompleteMode = AutoCompleteMode.SuggestAppend; 
            cmbPatients.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbPatients.SelectedIndex = -1; 

            var doctors = _userRepository.GetAllDoctors();
            cmbDoctors.DataSource = doctors;
            cmbDoctors.DisplayMember = "FullName";
            cmbDoctors.ValueMember = "UserID";
            cmbDoctors.SelectedIndex = -1;

            cmbDoctors.SelectedIndexChanged += (s, e) => GenerateTimeSlots();
            dtpDate.ValueChanged += (s, e) => GenerateTimeSlots();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            int patientId = (int)cmbPatients.SelectedValue;
            int doctorId = (int)cmbDoctors.SelectedValue;
            DateTime date = dtpDate.Value;

            _appointmentRepository.Create(patientId, doctorId, date, _selectedTime);
            MessageBox.Show(LocalizationManager.GetString("NewAppointmentForm_Message_Success"),
                            "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
