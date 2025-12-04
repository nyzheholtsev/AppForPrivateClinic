using System;
using System.Collections.Generic;
using program.dbClass;
using program.dbClass.Models;
using program.Localization;
using program.Repositories;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace program.Forms.chiefDoctor
{
    public partial class DoctorScheduleForm : Form, Localizable
    {
        private UserRepository _userRepo;
        private DoctorScheduleRepository _scheduleRepo;

        public DoctorScheduleForm()
        {
            InitializeComponent();
            _userRepo = new UserRepository();
            _scheduleRepo = new DoctorScheduleRepository();

            UpdateLocalization();
            LoadDoctors();

            // Привязка событий
            monthCalendar.DateChanged += (s, e) => LoadScheduleForDate();
            cmbDoctors.SelectedIndexChanged += (s, e) => LoadScheduleForDate();
            btnSaveDay.Click += BtnSaveDay_Click;
            btnDeleteDay.Click += BtnDeleteDay_Click;
            btnAutoGenerate.Click += BtnAutoGenerate_Click;
        }

        public void UpdateLocalization()
        {
            this.Text = LocalizationManager.GetString("Schedule_Title");
            lblDoctor.Text = LocalizationManager.GetString("Schedule_Label_Doctor");
            lblWork.Text = LocalizationManager.GetString("Schedule_Label_WorkTime");
            lblLunch.Text = LocalizationManager.GetString("Schedule_Label_LunchTime");
            btnSaveDay.Text = LocalizationManager.GetString("Schedule_Btn_Save");
            btnDeleteDay.Text = LocalizationManager.GetString("Schedule_Btn_Delete");
            grpAuto.Text = LocalizationManager.GetString("Schedule_Group_Auto");
            btnAutoGenerate.Text = LocalizationManager.GetString("Schedule_Btn_Auto");
        }

        private void LoadDoctors()
        {
            var doctors = _userRepo.GetAllDoctors();
            cmbDoctors.DataSource = doctors;
            cmbDoctors.DisplayMember = "FullName";
            cmbDoctors.ValueMember = "UserID";
        }

        private void LoadScheduleForDate()
        {
            if (cmbDoctors.SelectedValue == null) return;
            int doctorId = (int)cmbDoctors.SelectedValue;
            DateTime date = monthCalendar.SelectionStart;

            var schedule = _scheduleRepo.GetSchedule(doctorId, date);

            if (schedule != null)
            {
                // Если запись есть, заполняем поля
                dtpStart.Value = DateTime.Parse(schedule.StartTime);
                dtpEnd.Value = DateTime.Parse(schedule.EndTime);
                dtpLunchStart.Value = DateTime.Parse(schedule.LunchStart);
                dtpLunchEnd.Value = DateTime.Parse(schedule.LunchEnd);
                btnDeleteDay.Enabled = true;
            }
            else
            {
                // Если нет - ставим дефолт и блокируем удаление
                ResetTimePickers();
                btnDeleteDay.Enabled = false;
            }
        }

        private void ResetTimePickers()
        {
            DateTime now = DateTime.Now.Date;
            dtpStart.Value = now.AddHours(9);
            dtpEnd.Value = now.AddHours(17);
            dtpLunchStart.Value = now.AddHours(13);
            dtpLunchEnd.Value = now.AddHours(14);
        }

        private void BtnSaveDay_Click(object sender, EventArgs e)
        {
            if (cmbDoctors.SelectedValue == null) return;

            int doctorId = (int)cmbDoctors.SelectedValue;
            DateTime date = monthCalendar.SelectionStart;

            string start = dtpStart.Value.ToString("HH:mm");
            string end = dtpEnd.Value.ToString("HH:mm");
            string lStart = dtpLunchStart.Value.ToString("HH:mm");
            string lEnd = dtpLunchEnd.Value.ToString("HH:mm");

            try
            {
                _scheduleRepo.Save(doctorId, date, start, end, lStart, lEnd);
                MessageBox.Show("Schedule saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDeleteDay.Enabled = true; // Теперь можно удалять
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void BtnDeleteDay_Click(object sender, EventArgs e)
        {
            if (cmbDoctors.SelectedValue == null) return;
            int doctorId = (int)cmbDoctors.SelectedValue;
            DateTime date = monthCalendar.SelectionStart;

            if (MessageBox.Show("Make this day a day off?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _scheduleRepo.Delete(doctorId, date);
                ResetTimePickers();
                btnDeleteDay.Enabled = false;
            }
        }

        private void BtnAutoGenerate_Click(object sender, EventArgs e)
        {
            if (cmbDoctors.SelectedValue == null) return;
            int doctorId = (int)cmbDoctors.SelectedValue;

            // Берем год и месяц из авто-пикера
            int year = dtpAutoMonth.Value.Year;
            int month = dtpAutoMonth.Value.Month;

            string msg = $"Auto-fill schedule for {dtpAutoMonth.Value:MMMM yyyy}?\nExisting schedule for this month will be overwritten!";

            if (MessageBox.Show(msg, "Confirm Auto-Schedule", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _scheduleRepo.AutoGenerate(doctorId, year, month);
                    MessageBox.Show("Schedule generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadScheduleForDate(); // Обновить текущий вид
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}