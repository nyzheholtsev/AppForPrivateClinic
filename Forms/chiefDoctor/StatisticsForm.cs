using program.Localization;
using program.Repositories;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace program.Forms.chiefDoctor
{
    public partial class StatisticsForm : Form, Localizable
    {
        private StatisticsRepository _repo;
        private DataTable _currentData;

        // Ключи для определения типа отчета
        private const string REPORT_WORKLOAD = "Workload";
        private const string REPORT_VISITS = "Visits";
        private const string REPORT_DIAGNOSES = "Diagnoses";

        public StatisticsForm()
        {
            InitializeComponent();
            _repo = new StatisticsRepository();

            // Настройка дат (текущий месяц по умолчанию)
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now;

            SetupReportTypes();
            UpdateLocalization();

            // Подписки
            btnShow.Click += (s, e) => GenerateReport();
            btnExport.Click += (s, e) => ExportReport();
        }

        private class ReportTypeItem
        {
            public string Name { get; set; }
            public string Key { get; set; } // Ключ для логики (не меняется при переводе)
            public override string ToString() => Name;
        }

        private void SetupReportTypes()
        {
            // Мы заполним это в UpdateLocalization, чтобы обновлялся язык
        }

        public void UpdateLocalization()
        {
            this.Text = LocalizationManager.GetString("Stats_Title");
            lblReportType.Text = LocalizationManager.GetString("Stats_Label_Type");
            lblPeriod.Text = LocalizationManager.GetString("Stats_Label_Period");
            btnShow.Text = LocalizationManager.GetString("Stats_Btn_Show");
            btnExport.Text = LocalizationManager.GetString("Stats_Btn_Export");

            // Сохраняем текущий выбор
            int selectedIndex = cmbReportType.SelectedIndex;
            if (selectedIndex < 0) selectedIndex = 0;

            cmbReportType.Items.Clear();
            cmbReportType.Items.Add(new ReportTypeItem { Name = LocalizationManager.GetString("Stats_Type_Workload"), Key = REPORT_WORKLOAD });
            cmbReportType.Items.Add(new ReportTypeItem { Name = LocalizationManager.GetString("Stats_Type_Visits"), Key = REPORT_VISITS });
            cmbReportType.Items.Add(new ReportTypeItem { Name = LocalizationManager.GetString("Stats_Type_Diagnoses"), Key = REPORT_DIAGNOSES });

            cmbReportType.SelectedIndex = selectedIndex;
        }

        private void GenerateReport()
        {
            if (cmbReportType.SelectedItem is not ReportTypeItem selected) return;

            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;

            switch (selected.Key)
            {
                case REPORT_WORKLOAD:
                    _currentData = _repo.GetDoctorWorkload(start, end);
                    break;
                case REPORT_VISITS:
                    _currentData = _repo.GetVisitsByDate(start, end);
                    break;
                case REPORT_DIAGNOSES:
                    _currentData = _repo.GetDiagnosisStats(start, end);
                    break;
            }

            dgvStats.DataSource = _currentData;
        }

        private void ExportReport()
        {
            if (_currentData == null || _currentData.Rows.Count == 0)
            {
                MessageBox.Show("No data to export!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File (*.csv)|*.csv|Text File (*.txt)|*.txt";
            sfd.FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmm}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Заголовки
                    foreach (DataColumn col in _currentData.Columns)
                    {
                        sb.Append(col.ColumnName + ",");
                    }
                    sb.AppendLine();

                    // Данные
                    foreach (DataRow row in _currentData.Rows)
                    {
                        for (int i = 0; i < _currentData.Columns.Count; i++)
                        {
                            sb.Append(row[i].ToString().Replace(",", " ") + ",");
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                    string msg = string.Format(LocalizationManager.GetString("Stats_Msg_ExportSuccess"), sfd.FileName);
                    MessageBox.Show(msg, "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export Error: {ex.Message}");
                }
            }
        }
    }
}