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

        private const string REPORT_WORKLOAD = "Workload";
        private const string REPORT_VISITS = "Visits";
        private const string REPORT_DIAGNOSES = "Diagnoses";

        public StatisticsForm()
        {
            InitializeComponent();
            _repo = new StatisticsRepository();

            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now;

            UpdateLocalization();

            btnShow.Click += (s, e) => GenerateReport();
            btnExport.Click += (s, e) => ExportReport();
        }

        private class ReportTypeItem
        {
            public string Name { get; set; }
            public string Key { get; set; } 
            public override string ToString() => Name;
        }

        public void UpdateLocalization()
        {
            this.Text = LocalizationManager.GetString("Stats_Title");
            lblReportType.Text = LocalizationManager.GetString("Stats_Label_Type");
            lblPeriod.Text = LocalizationManager.GetString("Stats_Label_Period");
            btnShow.Text = LocalizationManager.GetString("Stats_Btn_Show");
            btnExport.Text = LocalizationManager.GetString("Stats_Btn_Export");

            int selectedIndex = cmbReportType.SelectedIndex;
            string selectedKey = null;
            if (selectedIndex >= 0 && cmbReportType.Items[selectedIndex] is ReportTypeItem currentItem)
            {
                selectedKey = currentItem.Key;
            }

            cmbReportType.Items.Clear();
            cmbReportType.Items.Add(new ReportTypeItem { Name = LocalizationManager.GetString("Stats_Type_Workload"), Key = REPORT_WORKLOAD });
            cmbReportType.Items.Add(new ReportTypeItem { Name = LocalizationManager.GetString("Stats_Type_Visits"), Key = REPORT_VISITS });
            cmbReportType.Items.Add(new ReportTypeItem { Name = LocalizationManager.GetString("Stats_Type_Diagnoses"), Key = REPORT_DIAGNOSES });

            if (selectedKey != null)
            {
                for (int i = 0; i < cmbReportType.Items.Count; i++)
                {
                    if (((ReportTypeItem)cmbReportType.Items[i]).Key == selectedKey)
                    {
                        cmbReportType.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                cmbReportType.SelectedIndex = 0;
            }

            LocalizeGridHeaders();
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
            LocalizeGridHeaders();
        }

        private void LocalizeGridHeaders()
        {
            if (dgvStats.DataSource == null) return;

            foreach (DataGridViewColumn col in dgvStats.Columns)
            { 
                switch (col.Name)
                {
                    case "Doctor Name":
                        col.HeaderText = LocalizationManager.GetString("Stats_Col_DoctorName");
                        break;
                    case "Patients Count":
                        col.HeaderText = LocalizationManager.GetString("Stats_Col_PatientsCount");
                        break;
                    case "Date":
                        col.HeaderText = LocalizationManager.GetString("Stats_Col_Date");
                        break;
                    case "Total Visits":
                        col.HeaderText = LocalizationManager.GetString("Stats_Col_TotalVisits");
                        break;
                    case "Diagnosis":
                        col.HeaderText = LocalizationManager.GetString("Stats_Col_Diagnosis");
                        break;
                    case "Count":
                        col.HeaderText = LocalizationManager.GetString("Stats_Col_Count");
                        break;
                }
            }
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

                    string separator = ";";

                    for (int i = 0; i < dgvStats.Columns.Count; i++)
                    {
                        sb.Append(dgvStats.Columns[i].HeaderText);
                        if (i < dgvStats.Columns.Count - 1)
                            sb.Append(separator);
                    }
                    sb.AppendLine();

                    foreach (DataRow row in _currentData.Rows)
                    {
                        for (int i = 0; i < _currentData.Columns.Count; i++)
                        {
                            string value = row[i].ToString()
                                .Replace(separator, " ")
                                .Replace("\r", "")
                                .Replace("\n", " ");

                            sb.Append(value);

                            if (i < _currentData.Columns.Count - 1)
                                sb.Append(separator);
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));

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