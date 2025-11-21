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
            SearchButton = new Button();
            NewPatientButton = new Button();
            SearchTextBox = new TextBox();
            PatientsDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)PatientsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(290, 98);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(94, 29);
            SearchButton.TabIndex = 0;
            SearchButton.Text = "SearchButton";
            SearchButton.UseVisualStyleBackColor = true;
            // 
            // NewPatientButton
            // 
            NewPatientButton.Location = new Point(290, 47);
            NewPatientButton.Name = "NewPatientButton";
            NewPatientButton.Size = new Size(94, 29);
            NewPatientButton.TabIndex = 1;
            NewPatientButton.Text = "NewPatientButton";
            NewPatientButton.UseVisualStyleBackColor = true;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(30, 100);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(254, 27);
            SearchTextBox.TabIndex = 2;
            // 
            // PatientsDataGridView
            // 
            PatientsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PatientsDataGridView.Location = new Point(401, 47);
            PatientsDataGridView.Name = "PatientsDataGridView";
            PatientsDataGridView.RowHeadersWidth = 51;
            PatientsDataGridView.Size = new Size(361, 324);
            PatientsDataGridView.TabIndex = 3;
            // 
            // PatientSearchForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 400);
            Controls.Add(PatientsDataGridView);
            Controls.Add(SearchTextBox);
            Controls.Add(NewPatientButton);
            Controls.Add(SearchButton);
            Name = "PatientSearchForm";
            Text = "PatientSearchForm";
            Load += PatientSearchForm_Load;
            ((System.ComponentModel.ISupportInitialize)PatientsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SearchButton;
        private Button NewPatientButton;
        private TextBox SearchTextBox;
        private DataGridView PatientsDataGridView;
    }
}