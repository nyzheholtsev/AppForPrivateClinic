namespace program.Forms.Administrator
{
    partial class NewAppointmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPathient = new Label();
            cmbPatients = new ComboBox();
            lblDoctor = new Label();
            cmbDoctors = new ComboBox();
            lblDate = new Label();
            dtpDate = new program.Controls.CustomDatePicker();
            lblTime = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnBook = new Button();
            line = new Label();
            lblGlobalData = new Label();
            SuspendLayout();
            // 
            // lblPathient
            // 
            lblPathient.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPathient.ForeColor = Color.Wheat;
            lblPathient.Location = new Point(12, 109);
            lblPathient.Name = "lblPathient";
            lblPathient.Size = new Size(81, 25);
            lblPathient.TabIndex = 0;
            lblPathient.Text = "Pathient";
            // 
            // cmbPatients
            // 
            cmbPatients.BackColor = Color.Wheat;
            cmbPatients.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPatients.FlatStyle = FlatStyle.Flat;
            cmbPatients.Font = new Font("Palatino Linotype", 10.2F);
            cmbPatients.FormattingEnabled = true;
            cmbPatients.Location = new Point(108, 103);
            cmbPatients.Name = "cmbPatients";
            cmbPatients.Size = new Size(393, 31);
            cmbPatients.TabIndex = 1;
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new Font("Palatino Linotype", 10.2F);
            lblDoctor.ForeColor = Color.Wheat;
            lblDoctor.Location = new Point(12, 169);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(62, 23);
            lblDoctor.TabIndex = 2;
            lblDoctor.Text = "Doctor";
            // 
            // cmbDoctors
            // 
            cmbDoctors.BackColor = Color.Wheat;
            cmbDoctors.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoctors.FlatStyle = FlatStyle.Flat;
            cmbDoctors.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbDoctors.FormattingEnabled = true;
            cmbDoctors.Location = new Point(108, 161);
            cmbDoctors.Name = "cmbDoctors";
            cmbDoctors.Size = new Size(393, 31);
            cmbDoctors.TabIndex = 3;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Palatino Linotype", 10.2F);
            lblDate.ForeColor = Color.Wheat;
            lblDate.Location = new Point(12, 229);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(46, 23);
            lblDate.TabIndex = 4;
            lblDate.Text = "Date";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Palatino Linotype", 10.2F);
            dtpDate.Location = new Point(108, 222);
            dtpDate.MaxDate = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            dtpDate.MinDate = new DateTime(0L);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(393, 33);
            dtpDate.TabIndex = 5;
            dtpDate.Text = "customDatePicker1";
            dtpDate.Value = new DateTime(2025, 12, 3, 18, 22, 35, 851);
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Palatino Linotype", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTime.ForeColor = Color.Wheat;
            lblTime.Location = new Point(537, 62);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(65, 31);
            lblTime.TabIndex = 6;
            lblTime.Text = "Time";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(537, 96);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(233, 279);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // btnBook
            // 
            btnBook.FlatStyle = FlatStyle.Flat;
            btnBook.ForeColor = Color.Wheat;
            btnBook.Location = new Point(12, 336);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(489, 39);
            btnBook.TabIndex = 8;
            btnBook.Text = "Made Termin";
            btnBook.UseVisualStyleBackColor = true;
            // 
            // line
            // 
            line.BackColor = Color.Wheat;
            line.Location = new Point(516, 70);
            line.Name = "line";
            line.Size = new Size(5, 313);
            line.TabIndex = 9;
            // 
            // lblGlobalData
            // 
            lblGlobalData.AutoSize = true;
            lblGlobalData.Font = new Font("Palatino Linotype", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblGlobalData.ForeColor = Color.Wheat;
            lblGlobalData.Location = new Point(12, 62);
            lblGlobalData.Name = "lblGlobalData";
            lblGlobalData.Size = new Size(132, 31);
            lblGlobalData.TabIndex = 10;
            lblGlobalData.Text = "GlobalData";
            // 
            // NewAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 400);
            Controls.Add(lblGlobalData);
            Controls.Add(line);
            Controls.Add(btnBook);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblTime);
            Controls.Add(dtpDate);
            Controls.Add(lblDate);
            Controls.Add(cmbDoctors);
            Controls.Add(lblDoctor);
            Controls.Add(cmbPatients);
            Controls.Add(lblPathient);
            ForeColor = Color.Gray;
            Name = "NewAppointmentForm";
            Text = "AppointmentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPathient;
        private ComboBox cmbPatients;
        private Label lblDoctor;
        private ComboBox cmbDoctors;
        private Label lblDate;
        private Controls.CustomDatePicker dtpDate;
        private Label lblTime;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnBook;
        private Label line;
        private Label lblGlobalData;
    }
}