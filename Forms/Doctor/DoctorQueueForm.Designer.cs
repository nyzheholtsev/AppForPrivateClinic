namespace program.Forms.Doctor
{
    partial class DoctorQueueForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            btnPatientAbsent = new Button();
            btnStartAppointment = new Button();
            lblNextTime = new Label();
            lblNextPatientName = new Label();
            dgvQueue = new DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colPatient = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            appointmentModelBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQueue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)appointmentModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnPatientAbsent);
            splitContainer1.Panel1.Controls.Add(btnStartAppointment);
            splitContainer1.Panel1.Controls.Add(lblNextTime);
            splitContainer1.Panel1.Controls.Add(lblNextPatientName);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvQueue);
            splitContainer1.Size = new Size(800, 400);
            splitContainer1.SplitterDistance = 243;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // btnPatientAbsent
            // 
            btnPatientAbsent.FlatStyle = FlatStyle.Flat;
            btnPatientAbsent.Location = new Point(30, 330);
            btnPatientAbsent.Margin = new Padding(4, 3, 4, 3);
            btnPatientAbsent.Name = "btnPatientAbsent";
            btnPatientAbsent.Size = new Size(190, 33);
            btnPatientAbsent.TabIndex = 3;
            btnPatientAbsent.Text = "btnPatientAbsent";
            btnPatientAbsent.UseVisualStyleBackColor = true;
            btnPatientAbsent.Click += btnPatientAbsent_Click_1;
            // 
            // btnStartAppointment
            // 
            btnStartAppointment.FlatStyle = FlatStyle.Flat;
            btnStartAppointment.Location = new Point(30, 291);
            btnStartAppointment.Margin = new Padding(4, 3, 4, 3);
            btnStartAppointment.Name = "btnStartAppointment";
            btnStartAppointment.Size = new Size(190, 33);
            btnStartAppointment.TabIndex = 2;
            btnStartAppointment.Text = "btnStartAppointment";
            btnStartAppointment.UseVisualStyleBackColor = true;
            btnStartAppointment.Click += btnStartAppointment_Click;
            // 
            // lblNextTime
            // 
            lblNextTime.AutoSize = true;
            lblNextTime.Location = new Point(30, 118);
            lblNextTime.Margin = new Padding(4, 0, 4, 0);
            lblNextTime.Name = "lblNextTime";
            lblNextTime.Size = new Size(105, 23);
            lblNextTime.TabIndex = 1;
            lblNextTime.Text = "lblNextTime";
            // 
            // lblNextPatientName
            // 
            lblNextPatientName.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblNextPatientName.Location = new Point(30, 49);
            lblNextPatientName.Margin = new Padding(4, 0, 4, 0);
            lblNextPatientName.Name = "lblNextPatientName";
            lblNextPatientName.Size = new Size(190, 69);
            lblNextPatientName.TabIndex = 0;
            lblNextPatientName.Text = "lblNextPatientName";
            // 
            // dgvQueue
            // 
            dgvQueue.AllowUserToAddRows = false;
            dgvQueue.AllowUserToDeleteRows = false;
            dgvQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQueue.Columns.AddRange(new DataGridViewColumn[] { colTime, colPatient, colStatus });
            dgvQueue.Location = new Point(13, 49);
            dgvQueue.Margin = new Padding(4, 3, 4, 3);
            dgvQueue.Name = "dgvQueue";
            dgvQueue.ReadOnly = true;
            dgvQueue.RowHeadersVisible = false;
            dgvQueue.RowHeadersWidth = 51;
            dgvQueue.Size = new Size(505, 314);
            dgvQueue.TabIndex = 0;
            // 
            // colTime
            // 
            colTime.DataPropertyName = "AppointmentTime";
            dataGridViewCellStyle1.BackColor = Color.Gray;
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = Color.Wheat;
            dataGridViewCellStyle1.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = Color.Wheat;
            colTime.DefaultCellStyle = dataGridViewCellStyle1;
            colTime.HeaderText = "colTime";
            colTime.MinimumWidth = 6;
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            colTime.Width = 50;
            // 
            // colPatient
            // 
            colPatient.DataPropertyName = "PatientName";
            dataGridViewCellStyle2.BackColor = Color.Gray;
            dataGridViewCellStyle2.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Wheat;
            dataGridViewCellStyle2.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = Color.Wheat;
            colPatient.DefaultCellStyle = dataGridViewCellStyle2;
            colPatient.HeaderText = "colPatient";
            colPatient.MinimumWidth = 6;
            colPatient.Name = "colPatient";
            colPatient.ReadOnly = true;
            colPatient.Width = 276;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            dataGridViewCellStyle3.BackColor = Color.Gray;
            dataGridViewCellStyle3.ForeColor = Color.Wheat;
            dataGridViewCellStyle3.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = Color.Wheat;
            colStatus.DefaultCellStyle = dataGridViewCellStyle3;
            colStatus.HeaderText = "colStatus";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 125;
            // 
            // appointmentModelBindingSource
            // 
            appointmentModelBindingSource.DataSource = typeof(dbClass.AppointmentModel);
            // 
            // DoctorQueueForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 400);
            Controls.Add(splitContainer1);
            Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ForeColor = Color.Wheat;
            Margin = new Padding(4, 3, 4, 3);
            Name = "DoctorQueueForm";
            Text = "DoctorQueueForm";
            Load += DoctorQueueForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvQueue).EndInit();
            ((System.ComponentModel.ISupportInitialize)appointmentModelBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btnPatientAbsent;
        private Button btnStartAppointment;
        private Label lblNextTime;
        private Label lblNextPatientName;
        private DataGridView dgvQueue;
        private BindingSource appointmentModelBindingSource;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colPatient;
        private DataGridViewTextBoxColumn colStatus;
    }
}