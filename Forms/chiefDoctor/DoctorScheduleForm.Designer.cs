namespace program.Forms.chiefDoctor
{
    partial class DoctorScheduleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblDoctor = new Label();
            cmbDoctors = new ComboBox();
            monthCalendar = new MonthCalendar();
            panelRight = new Panel();
            grpAuto = new GroupBox();
            btnAutoGenerate = new Button();
            dtpAutoMonth = new DateTimePicker();
            btnDeleteDay = new Button();
            btnSaveDay = new Button();
            lblDash2 = new Label();
            dtpLunchEnd = new DateTimePicker();
            dtpLunchStart = new DateTimePicker();
            lblLunch = new Label();
            lblDash1 = new Label();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            lblWork = new Label();
            panelRight.SuspendLayout();
            grpAuto.SuspendLayout();
            SuspendLayout();
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new Font("Palatino Linotype", 10.2F);
            lblDoctor.ForeColor = Color.Wheat;
            lblDoctor.Location = new Point(20, 20);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(62, 23);
            lblDoctor.TabIndex = 3;
            lblDoctor.Text = "Doctor";
            // 
            // cmbDoctors
            // 
            cmbDoctors.BackColor = Color.Wheat;
            cmbDoctors.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoctors.FlatStyle = FlatStyle.Flat;
            cmbDoctors.Font = new Font("Palatino Linotype", 10.2F);
            cmbDoctors.FormattingEnabled = true;
            cmbDoctors.Location = new Point(90, 17);
            cmbDoctors.Name = "cmbDoctors";
            cmbDoctors.Size = new Size(300, 31);
            cmbDoctors.TabIndex = 2;
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(20, 70);
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.Name = "monthCalendar";
            monthCalendar.ShowTodayCircle = false;
            monthCalendar.TabIndex = 1;
            // 
            // panelRight
            // 
            panelRight.BorderStyle = BorderStyle.FixedSingle;
            panelRight.Controls.Add(grpAuto);
            panelRight.Controls.Add(btnDeleteDay);
            panelRight.Controls.Add(btnSaveDay);
            panelRight.Controls.Add(lblDash2);
            panelRight.Controls.Add(dtpLunchEnd);
            panelRight.Controls.Add(dtpLunchStart);
            panelRight.Controls.Add(lblLunch);
            panelRight.Controls.Add(lblDash1);
            panelRight.Controls.Add(dtpEnd);
            panelRight.Controls.Add(dtpStart);
            panelRight.Controls.Add(lblWork);
            panelRight.Location = new Point(338, 70);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(400, 320);
            panelRight.TabIndex = 0;
            // 
            // grpAuto
            // 
            grpAuto.Controls.Add(btnAutoGenerate);
            grpAuto.Controls.Add(dtpAutoMonth);
            grpAuto.Font = new Font("Palatino Linotype", 10.2F);
            grpAuto.ForeColor = Color.Wheat;
            grpAuto.Location = new Point(20, 170);
            grpAuto.Name = "grpAuto";
            grpAuto.Size = new Size(350, 130);
            grpAuto.TabIndex = 0;
            grpAuto.TabStop = false;
            grpAuto.Text = "Auto Schedule";
            // 
            // btnAutoGenerate
            // 
            btnAutoGenerate.BackColor = Color.DimGray;
            btnAutoGenerate.FlatStyle = FlatStyle.Flat;
            btnAutoGenerate.Font = new Font("Palatino Linotype", 10F, FontStyle.Bold);
            btnAutoGenerate.Location = new Point(20, 80);
            btnAutoGenerate.Name = "btnAutoGenerate";
            btnAutoGenerate.Size = new Size(200, 35);
            btnAutoGenerate.TabIndex = 0;
            btnAutoGenerate.Text = "Fill Month";
            btnAutoGenerate.UseVisualStyleBackColor = false;
            // 
            // dtpAutoMonth
            // 
            dtpAutoMonth.CustomFormat = "MMMM yyyy";
            dtpAutoMonth.Format = DateTimePickerFormat.Custom;
            dtpAutoMonth.Location = new Point(20, 40);
            dtpAutoMonth.Name = "dtpAutoMonth";
            dtpAutoMonth.ShowUpDown = true;
            dtpAutoMonth.Size = new Size(200, 30);
            dtpAutoMonth.TabIndex = 1;
            // 
            // btnDeleteDay
            // 
            btnDeleteDay.BackColor = Color.DimGray;
            btnDeleteDay.FlatStyle = FlatStyle.Flat;
            btnDeleteDay.Font = new Font("Palatino Linotype", 10F, FontStyle.Bold);
            btnDeleteDay.ForeColor = Color.LightCoral;
            btnDeleteDay.Location = new Point(180, 110);
            btnDeleteDay.Name = "btnDeleteDay";
            btnDeleteDay.Size = new Size(190, 35);
            btnDeleteDay.TabIndex = 1;
            btnDeleteDay.Text = "Delete (Day Off)";
            btnDeleteDay.UseVisualStyleBackColor = false;
            // 
            // btnSaveDay
            // 
            btnSaveDay.BackColor = Color.DimGray;
            btnSaveDay.FlatStyle = FlatStyle.Flat;
            btnSaveDay.Font = new Font("Palatino Linotype", 10F, FontStyle.Bold);
            btnSaveDay.ForeColor = Color.Wheat;
            btnSaveDay.Location = new Point(20, 110);
            btnSaveDay.Name = "btnSaveDay";
            btnSaveDay.Size = new Size(150, 35);
            btnSaveDay.TabIndex = 2;
            btnSaveDay.Text = "Save Day";
            btnSaveDay.UseVisualStyleBackColor = false;
            // 
            // lblDash2
            // 
            lblDash2.AutoSize = true;
            lblDash2.ForeColor = Color.Wheat;
            lblDash2.Location = new Point(220, 65);
            lblDash2.Name = "lblDash2";
            lblDash2.Size = new Size(24, 20);
            lblDash2.TabIndex = 3;
            lblDash2.Text = "—";
            // 
            // dtpLunchEnd
            // 
            dtpLunchEnd.CustomFormat = "HH:mm";
            dtpLunchEnd.Font = new Font("Palatino Linotype", 10.2F);
            dtpLunchEnd.Format = DateTimePickerFormat.Custom;
            dtpLunchEnd.Location = new Point(250, 62);
            dtpLunchEnd.Name = "dtpLunchEnd";
            dtpLunchEnd.ShowUpDown = true;
            dtpLunchEnd.Size = new Size(80, 30);
            dtpLunchEnd.TabIndex = 4;
            dtpLunchEnd.Value = new DateTime(2025, 1, 1, 14, 0, 0, 0);
            // 
            // dtpLunchStart
            // 
            dtpLunchStart.CustomFormat = "HH:mm";
            dtpLunchStart.Font = new Font("Palatino Linotype", 10.2F);
            dtpLunchStart.Format = DateTimePickerFormat.Custom;
            dtpLunchStart.Location = new Point(130, 62);
            dtpLunchStart.Name = "dtpLunchStart";
            dtpLunchStart.ShowUpDown = true;
            dtpLunchStart.Size = new Size(80, 30);
            dtpLunchStart.TabIndex = 5;
            dtpLunchStart.Value = new DateTime(2025, 1, 1, 13, 0, 0, 0);
            // 
            // lblLunch
            // 
            lblLunch.AutoSize = true;
            lblLunch.Font = new Font("Palatino Linotype", 10.2F);
            lblLunch.ForeColor = Color.Wheat;
            lblLunch.Location = new Point(15, 65);
            lblLunch.Name = "lblLunch";
            lblLunch.Size = new Size(101, 23);
            lblLunch.TabIndex = 6;
            lblLunch.Text = "Lunch Time";
            // 
            // lblDash1
            // 
            lblDash1.AutoSize = true;
            lblDash1.ForeColor = Color.Wheat;
            lblDash1.Location = new Point(220, 15);
            lblDash1.Name = "lblDash1";
            lblDash1.Size = new Size(24, 20);
            lblDash1.TabIndex = 7;
            lblDash1.Text = "—";
            // 
            // dtpEnd
            // 
            dtpEnd.CustomFormat = "HH:mm";
            dtpEnd.Font = new Font("Palatino Linotype", 10.2F);
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(250, 12);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.ShowUpDown = true;
            dtpEnd.Size = new Size(80, 30);
            dtpEnd.TabIndex = 8;
            dtpEnd.Value = new DateTime(2025, 1, 1, 17, 0, 0, 0);
            // 
            // dtpStart
            // 
            dtpStart.CustomFormat = "HH:mm";
            dtpStart.Font = new Font("Palatino Linotype", 10.2F);
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(130, 12);
            dtpStart.Name = "dtpStart";
            dtpStart.ShowUpDown = true;
            dtpStart.Size = new Size(80, 30);
            dtpStart.TabIndex = 9;
            dtpStart.Value = new DateTime(2025, 1, 1, 9, 0, 0, 0);
            // 
            // lblWork
            // 
            lblWork.AutoSize = true;
            lblWork.Font = new Font("Palatino Linotype", 10.2F);
            lblWork.ForeColor = Color.Wheat;
            lblWork.Location = new Point(15, 15);
            lblWork.Name = "lblWork";
            lblWork.Size = new Size(95, 23);
            lblWork.TabIndex = 10;
            lblWork.Text = "Work Time";
            // 
            // DoctorScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(750, 450);
            Controls.Add(panelRight);
            Controls.Add(monthCalendar);
            Controls.Add(cmbDoctors);
            Controls.Add(lblDoctor);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DoctorScheduleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Schedule";
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            grpAuto.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        // Объявление полей
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cmbDoctors;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblWork;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblDash1;
        private System.Windows.Forms.Label lblLunch;
        private System.Windows.Forms.DateTimePicker dtpLunchStart;
        private System.Windows.Forms.DateTimePicker dtpLunchEnd;
        private System.Windows.Forms.Label lblDash2;
        private System.Windows.Forms.Button btnSaveDay;
        private System.Windows.Forms.Button btnDeleteDay;
        private System.Windows.Forms.GroupBox grpAuto;
        private System.Windows.Forms.DateTimePicker dtpAutoMonth;
        private System.Windows.Forms.Button btnAutoGenerate;
    }
}