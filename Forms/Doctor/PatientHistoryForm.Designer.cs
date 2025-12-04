    namespace program.Forms.Doctor
    {
        partial class PatientHistoryForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dgvHistory = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colDiagnosis = new DataGridViewTextBoxColumn();
            colTreatment = new DataGridViewTextBoxColumn();
            colNotes = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvHistory.BackgroundColor = Color.Gray;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Columns.AddRange(new DataGridViewColumn[] { colDate, colDiagnosis, colTreatment, colNotes });
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.Location = new Point(0, 0);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowHeadersWidth = 51;
            dgvHistory.Size = new Size(782, 453);
            dgvHistory.TabIndex = 0;
            // 
            // colDate
            // 
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDate.DataPropertyName = "AppointmentDateTime";
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            colDate.DefaultCellStyle = dataGridViewCellStyle1;
            colDate.HeaderText = "colDate";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 90;
            // 
            // colDiagnosis
            // 
            colDiagnosis.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDiagnosis.DataPropertyName = "Diagnosis";
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            colDiagnosis.DefaultCellStyle = dataGridViewCellStyle2;
            colDiagnosis.HeaderText = "colDiagnosis";
            colDiagnosis.MinimumWidth = 6;
            colDiagnosis.Name = "colDiagnosis";
            colDiagnosis.ReadOnly = true;
            colDiagnosis.Width = 123;
            // 
            // colTreatment
            // 
            colTreatment.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTreatment.DataPropertyName = "Treatment";
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            colTreatment.DefaultCellStyle = dataGridViewCellStyle3;
            colTreatment.HeaderText = "colTreatment";
            colTreatment.MinimumWidth = 6;
            colTreatment.Name = "colTreatment";
            colTreatment.ReadOnly = true;
            colTreatment.Width = 125;
            // 
            // colNotes
            // 
            colNotes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNotes.DataPropertyName = "Notes";
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            colNotes.DefaultCellStyle = dataGridViewCellStyle4;
            colNotes.HeaderText = "colNotes";
            colNotes.MinimumWidth = 6;
            colNotes.Name = "colNotes";
            colNotes.ReadOnly = true;
            // 
            // PatientHistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(782, 453);
            Controls.Add(dgvHistory);
            ForeColor = Color.Wheat;
            Name = "PatientHistoryForm";
            Text = "PatientHistoryForm";
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvHistory;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colDiagnosis;
        private DataGridViewTextBoxColumn colTreatment;
        private DataGridViewTextBoxColumn colNotes;
    }
    }