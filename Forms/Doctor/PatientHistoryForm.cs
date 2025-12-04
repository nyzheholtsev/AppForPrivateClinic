using program.dbClass;
using program.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

// ВАЖЛИВО: Тут має бути .Doctor, бо файл лежить у папці Doctor
namespace program.Forms.Doctor
{
    // ВАЖЛИВО: Клас має наслідуватися від Form
    public partial class PatientHistoryForm : Form
    {
        private int _patientId;
        private MedicalRecordRepository _repo;

        public PatientHistoryForm(int patientId)
        {
            InitializeComponent(); // Тепер ця помилка має зникнути
            _patientId = patientId;
            _repo = new MedicalRecordRepository();

            // Налаштування стилів (про всяк випадок, якщо дизайнер збився)
            SetupGridStyles();

            LoadHistory();
        }

        private void SetupGridStyles()
        {
            // Перевіряємо, чи існує грід, перш ніж налаштовувати
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