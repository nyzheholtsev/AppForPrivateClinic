using System;
using System.Collections.Generic;
using program.dbClass;
using program.dbClass.Models;
using program.Localization;
using program.Repositories;
using System;
using System.Drawing;
using System.Windows.Forms;
using program.Controls;

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

            dtpWorkDate.ValueChanged += (s, e) => LoadScheduleForDate(); // + расписание

            cmbDoctors.SelectedIndexChanged += (s, e) => LoadScheduleForDate();

            cmbDoctors.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) LoadScheduleForDate();
            };

            btnSaveDay.Click += BtnSaveDay_Click;
            btnDeleteDay.Click += BtnDeleteDay_Click;
            btnAutoSchedule.Click += BtnAutoSchedule_Click;
        }

        public void UpdateLocalization()
        {
            this.Text = LocalizationManager.GetString("Schedule_Title");
            lblDoctor.Text = LocalizationManager.GetString("Schedule_Label_Doctor");
            lblWork.Text = LocalizationManager.GetString("Schedule_Label_WorkTime");
            lblLunch.Text = LocalizationManager.GetString("Schedule_Label_LunchTime");
            btnSaveDay.Text = LocalizationManager.GetString("Schedule_Btn_Save");
            btnDeleteDay.Text = LocalizationManager.GetString("Schedule_Btn_Delete");
            btnAutoSchedule.Text = LocalizationManager.GetString("ManageUsers_Btn_Auto");

            dtpWorkDate.UpdateLocalization();
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

            if (cmbDoctors.SelectedValue == null)
            {
                ResetTimePickers();
                btnDeleteDay.Enabled = false;
                return;
            }

            int doctorId;
            try
            {
                doctorId = (int)cmbDoctors.SelectedValue;
            }
            catch
            {
                return;
            }

            DateTime date = dtpWorkDate.Value;

            var schedule = _scheduleRepo.GetSchedule(doctorId, date);

            if (schedule != null)
            {
                dtpStart.Value = DateTime.Parse(schedule.StartTime);
                dtpEnd.Value = DateTime.Parse(schedule.EndTime);
                dtpLunchStart.Value = DateTime.Parse(schedule.LunchStart);
                dtpLunchEnd.Value = DateTime.Parse(schedule.LunchEnd);
                btnDeleteDay.Enabled = true;
            }
            else
            {
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
            if (cmbDoctors.SelectedValue == null)
            {
                MessageBox.Show("Лікаря не знайдено! Будь ласка, виберіть лікаря зі списку.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int doctorId = (int)cmbDoctors.SelectedValue;
            DateTime date = dtpWorkDate.Value;

            string start = dtpStart.Value.ToString("HH:mm");
            string end = dtpEnd.Value.ToString("HH:mm");
            string lStart = dtpLunchStart.Value.ToString("HH:mm");
            string lEnd = dtpLunchEnd.Value.ToString("HH:mm");

            try
            {
                _scheduleRepo.Save(doctorId, date, start, end, lStart, lEnd);
                MessageBox.Show("Schedule saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDeleteDay.Enabled = true;
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

            DateTime date = dtpWorkDate.Value;

            if (MessageBox.Show("Make this day a day off?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _scheduleRepo.Delete(doctorId, date);
                ResetTimePickers();
                btnDeleteDay.Enabled = false;
            }
        }

        private void BtnAutoSchedule_Click(object sender, EventArgs e)
        {
            if (cmbDoctors.SelectedValue == null)
            {
                MessageBox.Show("Будь ласка, оберіть лікаря.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int doctorId = (int)cmbDoctors.SelectedValue;
            string doctorName = cmbDoctors.Text;

            string msg = $"Згенерувати розклад на ЦЕЙ тиждень (Пн-Пт) для лікаря {doctorName}?\nІснуючі записи на цей тиждень будуть перезаписані!";

            if (MessageBox.Show(msg, "Авто-розклад", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _scheduleRepo.AutoGenerateCurrentWeek(doctorId);
                    MessageBox.Show("Розклад успішно створено (Пн-Пт, 09:00 - 17:00).", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadScheduleForDate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка генерації: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}