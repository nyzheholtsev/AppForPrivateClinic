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
            dtpWorkDate = new program.Controls.CustomDatePicker();
            panelRight = new Panel();
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
            btnAutoSchedule = new Button();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new Font("Palatino Linotype", 10.2F);
            lblDoctor.ForeColor = Color.Wheat;
            lblDoctor.Location = new Point(20, 44);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(62, 23);
            lblDoctor.TabIndex = 3;
            lblDoctor.Text = "Doctor";
            // 
            // cmbDoctors
            // 
            cmbDoctors.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDoctors.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbDoctors.BackColor = Color.Wheat;
            cmbDoctors.FlatStyle = FlatStyle.Flat;
            cmbDoctors.Font = new Font("Palatino Linotype", 10.2F);
            cmbDoctors.FormattingEnabled = true;
            cmbDoctors.Location = new Point(20, 70);
            cmbDoctors.Name = "cmbDoctors";
            cmbDoctors.Size = new Size(300, 31);
            cmbDoctors.TabIndex = 2;
            // 
            // dtpWorkDate
            // 
            dtpWorkDate.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpWorkDate.Location = new Point(20, 123);
            dtpWorkDate.MaxDate = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            dtpWorkDate.MinDate = new DateTime(0L);
            dtpWorkDate.Name = "dtpWorkDate";
            dtpWorkDate.Size = new Size(300, 43);
            dtpWorkDate.TabIndex = 1;
            dtpWorkDate.Value = new DateTime(2025, 12, 7, 9, 38, 32, 681);
            // 
            // panelRight
            // 
            panelRight.BorderStyle = BorderStyle.FixedSingle;
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
            panelRight.Size = new Size(400, 176);
            panelRight.TabIndex = 0;
            // 
            // btnDeleteDay
            // 
            btnDeleteDay.BackColor = Color.DimGray;
            btnDeleteDay.FlatStyle = FlatStyle.Flat;
            btnDeleteDay.Font = new Font("Palatino Linotype", 10F, FontStyle.Bold);
            btnDeleteDay.ForeColor = Color.LightCoral;
            btnDeleteDay.Location = new Point(180, 114);
            btnDeleteDay.Name = "btnDeleteDay";
            btnDeleteDay.Size = new Size(190, 45);
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
            btnSaveDay.Location = new Point(15, 114);
            btnSaveDay.Name = "btnSaveDay";
            btnSaveDay.Size = new Size(150, 45);
            btnSaveDay.TabIndex = 2;
            btnSaveDay.Text = "Save Day";
            btnSaveDay.UseVisualStyleBackColor = false;
            // 
            // lblDash2
            // 
            lblDash2.AutoSize = true;
            lblDash2.ForeColor = Color.Wheat;
            lblDash2.Location = new Point(255, 71);
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
            dtpLunchEnd.Location = new Point(290, 65);
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
            dtpLunchStart.Location = new Point(165, 65);
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
            lblDash1.Location = new Point(255, 20);
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
            dtpEnd.Location = new Point(290, 15);
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
            dtpStart.Location = new Point(165, 15);
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
            // btnAutoSchedule
            // 
            btnAutoSchedule.BackColor = Color.DimGray;
            btnAutoSchedule.FlatStyle = FlatStyle.Flat;
            btnAutoSchedule.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold);
            btnAutoSchedule.ForeColor = Color.Wheat;
            btnAutoSchedule.Location = new Point(20, 185);
            btnAutoSchedule.Name = "btnAutoSchedule";
            btnAutoSchedule.Size = new Size(300, 45);
            btnAutoSchedule.TabIndex = 11;
            btnAutoSchedule.Text = "Auto Schedule (Week)";
            btnAutoSchedule.UseVisualStyleBackColor = false;
            // 
            // DoctorScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(750, 258);
            Controls.Add(btnAutoSchedule);
            Controls.Add(panelRight);
            Controls.Add(dtpWorkDate);
            Controls.Add(cmbDoctors);
            Controls.Add(lblDoctor);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DoctorScheduleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Schedule";
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cmbDoctors;
        private program.Controls.CustomDatePicker dtpWorkDate;
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
        private System.Windows.Forms.Button btnAutoSchedule;
    }
}