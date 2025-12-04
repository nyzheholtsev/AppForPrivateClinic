namespace program.Forms.Doctor
{
    partial class DoctorConsultationForm
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
            lblPatientInfo = new Label();
            lblDiagnos = new Label();
            lblTreatment = new Label();
            lblNote = new Label();
            txtDiagnosis = new TextBox();
            txtTreatment = new TextBox();
            txtNotes = new TextBox();
            btnFinish = new Button();
            btnEdit = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblPatientInfo
            // 
            lblPatientInfo.AutoSize = true;
            lblPatientInfo.Font = new Font("Palatino Linotype", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            lblPatientInfo.Location = new Point(29, 52);
            lblPatientInfo.Name = "lblPatientInfo";
            lblPatientInfo.Size = new Size(156, 30);
            lblPatientInfo.TabIndex = 0;
            lblPatientInfo.Text = "lblPatientInfo";
            // 
            // lblDiagnos
            // 
            lblDiagnos.AutoSize = true;
            lblDiagnos.Font = new Font("Palatino Linotype", 10.2F);
            lblDiagnos.Location = new Point(30, 97);
            lblDiagnos.Name = "lblDiagnos";
            lblDiagnos.Size = new Size(93, 23);
            lblDiagnos.TabIndex = 1;
            lblDiagnos.Text = "lblDiagnos";
            // 
            // lblTreatment
            // 
            lblTreatment.AutoSize = true;
            lblTreatment.Font = new Font("Palatino Linotype", 10.2F);
            lblTreatment.Location = new Point(29, 152);
            lblTreatment.Name = "lblTreatment";
            lblTreatment.Size = new Size(83, 23);
            lblTreatment.TabIndex = 2;
            lblTreatment.Text = "lblTerapy";
            // 
            // lblNote
            // 
            lblNote.Font = new Font("Palatino Linotype", 10.2F);
            lblNote.Location = new Point(340, 150);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(240, 25);
            lblNote.TabIndex = 3;
            lblNote.Text = "lblNote";
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.BackColor = Color.Gray;
            txtDiagnosis.Font = new Font("Palatino Linotype", 10.2F);
            txtDiagnosis.Location = new Point(129, 92);
            txtDiagnosis.Multiline = true;
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.Size = new Size(645, 34);
            txtDiagnosis.TabIndex = 4;
            // 
            // txtTreatment
            // 
            txtTreatment.BackColor = Color.Gray;
            txtTreatment.Font = new Font("Palatino Linotype", 10.2F);
            txtTreatment.Location = new Point(30, 178);
            txtTreatment.Multiline = true;
            txtTreatment.Name = "txtTreatment";
            txtTreatment.Size = new Size(285, 154);
            txtTreatment.TabIndex = 5;
            // 
            // txtNotes
            // 
            txtNotes.BackColor = Color.Gray;
            txtNotes.Font = new Font("Palatino Linotype", 10.2F);
            txtNotes.Location = new Point(340, 178);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(434, 154);
            txtNotes.TabIndex = 6;
            // 
            // btnFinish
            // 
            btnFinish.FlatStyle = FlatStyle.Flat;
            btnFinish.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnFinish.Location = new Point(574, 348);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(200, 30);
            btnFinish.TabIndex = 7;
            btnFinish.Text = "btnFinish";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += btnFinish_Click;
            // 
            // btnEdit
            // 
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnEdit.Location = new Point(291, 348);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(200, 30);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "btnEdit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnClose.Location = new Point(30, 348);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(200, 30);
            btnClose.TabIndex = 9;
            btnClose.Text = "btnClose";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // DoctorConsultationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 400);
            Controls.Add(btnClose);
            Controls.Add(btnEdit);
            Controls.Add(btnFinish);
            Controls.Add(txtNotes);
            Controls.Add(txtTreatment);
            Controls.Add(txtDiagnosis);
            Controls.Add(lblNote);
            Controls.Add(lblTreatment);
            Controls.Add(lblDiagnos);
            Controls.Add(lblPatientInfo);
            Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            ForeColor = Color.Wheat;
            Margin = new Padding(4, 3, 4, 3);
            Name = "DoctorConsultationForm";
            Text = "DoctorConsultationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPatientInfo;
        private Label lblDiagnos;
        private Label lblTreatment;
        private Label lblNote;
        private TextBox txtDiagnosis;
        private TextBox txtTreatment;
        private TextBox txtNotes;
        private Button btnFinish;
        private Button btnEdit;
        private Button btnClose;
    }
}