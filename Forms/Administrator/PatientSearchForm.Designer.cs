namespace program
{
    partial class PatientSearchForm
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
            SearchButton = new Button();
            SearchTextBox = new TextBox();
            PatientsDataGridView = new DataGridView();
            patientModelBindingSource = new BindingSource(components);
            PathientFullNameColumn = new DataGridViewTextBoxColumn();
            PathientDateOfBirthColumn = new DataGridViewTextBoxColumn();
            PathientContactColumn = new DataGridViewTextBoxColumn();
            patientIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateOfBirthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            contactsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)PatientsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)patientModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // SearchButton
            // 
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.Font = new Font("Palatino Linotype", 10.2F);
            SearchButton.ForeColor = Color.Wheat;
            SearchButton.Location = new Point(694, 54);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(94, 37);
            SearchButton.TabIndex = 0;
            SearchButton.Text = "SearchButton";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // SearchTextBox
            // 
            SearchTextBox.BackColor = Color.Wheat;
            SearchTextBox.Font = new Font("Segoe UI", 10.2F);
            SearchTextBox.Location = new Point(12, 54);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(676, 30);
            SearchTextBox.TabIndex = 2;
            // 
            // PatientsDataGridView
            // 
            PatientsDataGridView.AllowUserToAddRows = false;
            PatientsDataGridView.AllowUserToDeleteRows = false;
            PatientsDataGridView.AllowUserToResizeColumns = false;
            PatientsDataGridView.AllowUserToResizeRows = false;
            PatientsDataGridView.AutoGenerateColumns = false;
            PatientsDataGridView.BackgroundColor = Color.Gray;
            PatientsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PatientsDataGridView.Columns.AddRange(new DataGridViewColumn[] { PathientFullNameColumn, PathientDateOfBirthColumn, PathientContactColumn, patientIDDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, dateOfBirthDataGridViewTextBoxColumn, contactsDataGridViewTextBoxColumn, createdDateDataGridViewTextBoxColumn, ageDataGridViewTextBoxColumn });
            PatientsDataGridView.DataSource = patientModelBindingSource;
            PatientsDataGridView.GridColor = Color.Gray;
            PatientsDataGridView.Location = new Point(12, 104);
            PatientsDataGridView.Name = "PatientsDataGridView";
            PatientsDataGridView.ReadOnly = true;
            PatientsDataGridView.RowHeadersVisible = false;
            PatientsDataGridView.RowHeadersWidth = 51;
            PatientsDataGridView.Size = new Size(776, 284);
            PatientsDataGridView.TabIndex = 3;
            // 
            // patientModelBindingSource
            // 
            patientModelBindingSource.DataSource = typeof(dbClass.PatientModel);
            // 
            // PathientFullNameColumn
            // 
            PathientFullNameColumn.DataPropertyName = "FullName";
            dataGridViewCellStyle1.BackColor = Color.Gray;
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 9.2F);
            dataGridViewCellStyle1.ForeColor = Color.Wheat;
            dataGridViewCellStyle1.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = Color.Wheat;
            PathientFullNameColumn.DefaultCellStyle = dataGridViewCellStyle1;
            PathientFullNameColumn.HeaderText = "PathientFullName";
            PathientFullNameColumn.MinimumWidth = 6;
            PathientFullNameColumn.Name = "PathientFullNameColumn";
            PathientFullNameColumn.ReadOnly = true;
            PathientFullNameColumn.Resizable = DataGridViewTriState.False;
            PathientFullNameColumn.Width = 410;
            // 
            // PathientDateOfBirthColumn
            // 
            PathientDateOfBirthColumn.DataPropertyName = "DateOfBirth";
            dataGridViewCellStyle2.BackColor = Color.Gray;
            dataGridViewCellStyle2.Font = new Font("Palatino Linotype", 9.2F);
            dataGridViewCellStyle2.ForeColor = Color.Wheat;
            dataGridViewCellStyle2.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = Color.Wheat;
            PathientDateOfBirthColumn.DefaultCellStyle = dataGridViewCellStyle2;
            PathientDateOfBirthColumn.HeaderText = "PathientDateOfBirth";
            PathientDateOfBirthColumn.MinimumWidth = 6;
            PathientDateOfBirthColumn.Name = "PathientDateOfBirthColumn";
            PathientDateOfBirthColumn.ReadOnly = true;
            PathientDateOfBirthColumn.Resizable = DataGridViewTriState.False;
            PathientDateOfBirthColumn.Width = 125;
            // 
            // PathientContactColumn
            // 
            PathientContactColumn.DataPropertyName = "Contacts";
            dataGridViewCellStyle3.BackColor = Color.Gray;
            dataGridViewCellStyle3.Font = new Font("Palatino Linotype", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = Color.Wheat;
            dataGridViewCellStyle3.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = Color.Wheat;
            PathientContactColumn.DefaultCellStyle = dataGridViewCellStyle3;
            PathientContactColumn.HeaderText = "PathientContactColumn";
            PathientContactColumn.MinimumWidth = 6;
            PathientContactColumn.Name = "PathientContactColumn";
            PathientContactColumn.ReadOnly = true;
            PathientContactColumn.Resizable = DataGridViewTriState.False;
            PathientContactColumn.Width = 236;
            // 
            // patientIDDataGridViewTextBoxColumn
            // 
            patientIDDataGridViewTextBoxColumn.DataPropertyName = "PatientID";
            patientIDDataGridViewTextBoxColumn.HeaderText = "PatientID";
            patientIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            patientIDDataGridViewTextBoxColumn.Name = "patientIDDataGridViewTextBoxColumn";
            patientIDDataGridViewTextBoxColumn.ReadOnly = true;
            patientIDDataGridViewTextBoxColumn.Visible = false;
            patientIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            fullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            fullNameDataGridViewTextBoxColumn.Visible = false;
            fullNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateOfBirthDataGridViewTextBoxColumn
            // 
            dateOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn.HeaderText = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn.MinimumWidth = 6;
            dateOfBirthDataGridViewTextBoxColumn.Name = "dateOfBirthDataGridViewTextBoxColumn";
            dateOfBirthDataGridViewTextBoxColumn.ReadOnly = true;
            dateOfBirthDataGridViewTextBoxColumn.Visible = false;
            dateOfBirthDataGridViewTextBoxColumn.Width = 125;
            // 
            // contactsDataGridViewTextBoxColumn
            // 
            contactsDataGridViewTextBoxColumn.DataPropertyName = "Contacts";
            contactsDataGridViewTextBoxColumn.HeaderText = "Contacts";
            contactsDataGridViewTextBoxColumn.MinimumWidth = 6;
            contactsDataGridViewTextBoxColumn.Name = "contactsDataGridViewTextBoxColumn";
            contactsDataGridViewTextBoxColumn.ReadOnly = true;
            contactsDataGridViewTextBoxColumn.Visible = false;
            contactsDataGridViewTextBoxColumn.Width = 125;
            // 
            // createdDateDataGridViewTextBoxColumn
            // 
            createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
            createdDateDataGridViewTextBoxColumn.HeaderText = "CreatedDate";
            createdDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
            createdDateDataGridViewTextBoxColumn.ReadOnly = true;
            createdDateDataGridViewTextBoxColumn.Visible = false;
            createdDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            ageDataGridViewTextBoxColumn.HeaderText = "Age";
            ageDataGridViewTextBoxColumn.MinimumWidth = 6;
            ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            ageDataGridViewTextBoxColumn.ReadOnly = true;
            ageDataGridViewTextBoxColumn.Visible = false;
            ageDataGridViewTextBoxColumn.Width = 125;
            // 
            // PatientSearchForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 400);
            Controls.Add(PatientsDataGridView);
            Controls.Add(SearchTextBox);
            Controls.Add(SearchButton);
            Name = "PatientSearchForm";
            Text = "PatientSearchForm";
            Load += PatientSearchForm_Load;
            ((System.ComponentModel.ISupportInitialize)PatientsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)patientModelBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SearchButton;
        private TextBox SearchTextBox;
        private DataGridView PatientsDataGridView;
        private BindingSource patientModelBindingSource;
        private DataGridViewTextBoxColumn PathientFullNameColumn;
        private DataGridViewTextBoxColumn PathientDateOfBirthColumn;
        private DataGridViewTextBoxColumn PathientContactColumn;
        private DataGridViewTextBoxColumn patientIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateOfBirthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn contactsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
    }
}