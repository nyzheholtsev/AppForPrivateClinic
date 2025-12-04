namespace program.Forms.chiefDoctor
{
    partial class StatisticsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelTop = new Panel();
            btnExport = new Button();
            btnShow = new Button();
            dtpEnd = new DateTimePicker();
            lblDash = new Label();
            dtpStart = new DateTimePicker();
            lblPeriod = new Label();
            cmbReportType = new ComboBox();
            lblReportType = new Label();
            dgvStats = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStats).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnExport);
            panelTop.Controls.Add(btnShow);
            panelTop.Controls.Add(dtpEnd);
            panelTop.Controls.Add(lblDash);
            panelTop.Controls.Add(dtpStart);
            panelTop.Controls.Add(lblPeriod);
            panelTop.Controls.Add(cmbReportType);
            panelTop.Controls.Add(lblReportType);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(800, 100);
            panelTop.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.DimGray;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Palatino Linotype", 10F, FontStyle.Bold);
            btnExport.ForeColor = Color.Wheat;
            btnExport.Location = new Point(290, 54);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(200, 35);
            btnExport.TabIndex = 7;
            btnExport.Text = "Export to Excel";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // btnShow
            // 
            btnShow.BackColor = Color.DimGray;
            btnShow.FlatStyle = FlatStyle.Flat;
            btnShow.Font = new Font("Palatino Linotype", 10F, FontStyle.Bold);
            btnShow.ForeColor = Color.Wheat;
            btnShow.Location = new Point(130, 54);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(150, 35);
            btnShow.TabIndex = 6;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = false;
            // 
            // dtpEnd
            // 
            dtpEnd.Font = new Font("Palatino Linotype", 10.2F);
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(620, 17);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(110, 30);
            dtpEnd.TabIndex = 5;
            // 
            // lblDash
            // 
            lblDash.AutoSize = true;
            lblDash.Font = new Font("Palatino Linotype", 10.2F);
            lblDash.ForeColor = Color.Wheat;
            lblDash.Location = new Point(590, 20);
            lblDash.Name = "lblDash";
            lblDash.Size = new Size(15, 23);
            lblDash.TabIndex = 4;
            lblDash.Text = "-";
            // 
            // dtpStart
            // 
            dtpStart.Font = new Font("Palatino Linotype", 10.2F);
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(470, 17);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(110, 30);
            dtpStart.TabIndex = 3;
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Font = new Font("Palatino Linotype", 10.2F);
            lblPeriod.ForeColor = Color.Wheat;
            lblPeriod.Location = new Point(400, 20);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(62, 23);
            lblPeriod.TabIndex = 2;
            lblPeriod.Text = "Period:";
            // 
            // cmbReportType
            // 
            cmbReportType.BackColor = Color.Wheat;
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.FlatStyle = FlatStyle.Flat;
            cmbReportType.Font = new Font("Palatino Linotype", 10.2F);
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Location = new Point(130, 17);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(250, 31);
            cmbReportType.TabIndex = 1;
            // 
            // lblReportType
            // 
            lblReportType.AutoSize = true;
            lblReportType.Font = new Font("Palatino Linotype", 10.2F);
            lblReportType.ForeColor = Color.Wheat;
            lblReportType.Location = new Point(20, 20);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(103, 23);
            lblReportType.TabIndex = 0;
            lblReportType.Text = "Report Type";
            // 
            // dgvStats
            // 
            dgvStats.AllowUserToAddRows = false;
            dgvStats.AllowUserToDeleteRows = false;
            dgvStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStats.BackgroundColor = Color.Gray;
            dgvStats.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.BackColor = Color.DimGray;
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Wheat;
            dataGridViewCellStyle1.SelectionBackColor = Color.DimGray;
            dgvStats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvStats.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gray;
            dataGridViewCellStyle2.Font = new Font("Palatino Linotype", 10.2F);
            dataGridViewCellStyle2.ForeColor = Color.Wheat;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(90, 90, 90);
            dataGridViewCellStyle2.SelectionForeColor = Color.Wheat;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvStats.DefaultCellStyle = dataGridViewCellStyle2;
            dgvStats.Dock = DockStyle.Fill;
            dgvStats.EnableHeadersVisualStyles = false;
            dgvStats.GridColor = Color.DimGray;
            dgvStats.Location = new Point(0, 100);
            dgvStats.Name = "dgvStats";
            dgvStats.ReadOnly = true;
            dgvStats.RowHeadersVisible = false;
            dgvStats.RowHeadersWidth = 51;
            dgvStats.Size = new Size(800, 350);
            dgvStats.TabIndex = 1;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvStats);
            Controls.Add(panelTop);
            Name = "StatisticsForm";
            Text = "Statistics";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStats).EndInit();
            ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvStats;
    }
}