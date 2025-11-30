namespace program.Forms
{
    partial class PatientAddForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblDob = new Label();
            dtpDob = new program.Controls.CustomDatePicker();
            lblPhone = new Label();
            txtPhone = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold);
            lblFullName.ForeColor = Color.Wheat;
            lblFullName.Location = new Point(15, 75);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(89, 23);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full Name";
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.Wheat;
            txtFullName.Font = new Font("Palatino Linotype", 10.2F);
            txtFullName.Location = new Point(210, 70);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(439, 30);
            txtFullName.TabIndex = 1;
            // 
            // lblDob
            // 
            lblDob.AutoSize = true;
            lblDob.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold);
            lblDob.ForeColor = Color.Wheat;
            lblDob.Location = new Point(15, 125);
            lblDob.Name = "lblDob";
            lblDob.Size = new Size(109, 23);
            lblDob.TabIndex = 2;
            lblDob.Text = "Date of Birth";
            // 
            // dtpDob
            // 
            dtpDob.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dtpDob.Location = new Point(210, 120);
            dtpDob.MaxDate = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            dtpDob.MinDate = new DateTime(0L);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(439, 30);
            dtpDob.TabIndex = 3;
            dtpDob.Value = new DateTime(2025, 11, 30, 15, 54, 24, 380);
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold);
            lblPhone.ForeColor = Color.Wheat;
            lblPhone.Location = new Point(15, 175);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(57, 23);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.Wheat;
            txtPhone.Font = new Font("Palatino Linotype", 10.2F);
            txtPhone.Location = new Point(210, 170);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(439, 30);
            txtPhone.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Gray;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold);
            btnSave.ForeColor = Color.Wheat;
            btnSave.Location = new Point(667, 166);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Wheat;
            btnCancel.Location = new Point(667, 70);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // PatientAddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(dtpDob);
            Controls.Add(lblDob);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Name = "PatientAddForm";
            Text = "Add Patient";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblDob;
        // Обновленный тип
        private program.Controls.CustomDatePicker dtpDob;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}