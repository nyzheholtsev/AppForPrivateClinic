namespace program.Forms.chiefDoctor
{
    partial class ManageUsersForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvUsers = new DataGridView();
            panelControls = new Panel();
            btnAutoSchedule = new Button();
            btnEditSchedule = new Button();
            btnFireUser = new Button();
            btnAddUser = new Button();
            panelSpacer = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panelControls.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeColumns = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.Gray;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DimGray;
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Wheat;
            dataGridViewCellStyle1.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = Color.Wheat;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gray;
            dataGridViewCellStyle2.Font = new Font("Palatino Linotype", 10F);
            dataGridViewCellStyle2.ForeColor = Color.Wheat;
            dataGridViewCellStyle2.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = Color.Wheat;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
            dgvUsers.Dock = DockStyle.Left;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.DimGray;
            dgvUsers.Location = new Point(0, 60);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.Gray;
            dataGridViewCellStyle3.ForeColor = Color.Wheat;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(90, 90, 90);
            dgvUsers.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(544, 390);
            dgvUsers.TabIndex = 0;
            // 
            // panelControls
            // 
            panelControls.Controls.Add(btnAutoSchedule);
            panelControls.Controls.Add(btnEditSchedule);
            panelControls.Controls.Add(btnFireUser);
            panelControls.Controls.Add(btnAddUser);
            panelControls.Dock = DockStyle.Fill;
            panelControls.Location = new Point(544, 60);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(256, 390);
            panelControls.TabIndex = 1;
            // 
            // btnAutoSchedule
            // 
            btnAutoSchedule.FlatStyle = FlatStyle.Flat;
            btnAutoSchedule.Font = new Font("Palatino Linotype", 10.2F);
            btnAutoSchedule.ForeColor = Color.Wheat;
            btnAutoSchedule.Location = new Point(20, 200);
            btnAutoSchedule.Name = "btnAutoSchedule";
            btnAutoSchedule.Size = new Size(200, 40);
            btnAutoSchedule.TabIndex = 3;
            btnAutoSchedule.Text = "Auto Schedule";
            btnAutoSchedule.UseVisualStyleBackColor = true;
            // 
            // btnEditSchedule
            // 
            btnEditSchedule.FlatStyle = FlatStyle.Flat;
            btnEditSchedule.Font = new Font("Palatino Linotype", 10.2F);
            btnEditSchedule.ForeColor = Color.Wheat;
            btnEditSchedule.Location = new Point(20, 150);
            btnEditSchedule.Name = "btnEditSchedule";
            btnEditSchedule.Size = new Size(200, 40);
            btnEditSchedule.TabIndex = 2;
            btnEditSchedule.Text = "Edit Schedule";
            btnEditSchedule.UseVisualStyleBackColor = true;
            // 
            // btnFireUser
            // 
            btnFireUser.FlatStyle = FlatStyle.Flat;
            btnFireUser.Font = new Font("Palatino Linotype", 10.2F);
            btnFireUser.ForeColor = Color.Wheat;
            btnFireUser.Location = new Point(20, 70);
            btnFireUser.Name = "btnFireUser";
            btnFireUser.Size = new Size(200, 40);
            btnFireUser.TabIndex = 1;
            btnFireUser.Text = "Fire User";
            btnFireUser.UseVisualStyleBackColor = true;
            btnFireUser.Click += btnFireUser_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Palatino Linotype", 10.2F);
            btnAddUser.ForeColor = Color.Wheat;
            btnAddUser.Location = new Point(20, 20);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(200, 40);
            btnAddUser.TabIndex = 0;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // panelSpacer
            // 
            panelSpacer.BackColor = Color.Transparent;
            panelSpacer.Dock = DockStyle.Top;
            panelSpacer.Location = new Point(0, 0);
            panelSpacer.Name = "panelSpacer";
            panelSpacer.Size = new Size(800, 60);
            panelSpacer.TabIndex = 2;
            // 
            // ManageUsersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 450);
            Controls.Add(panelControls);
            Controls.Add(dgvUsers);
            Controls.Add(panelSpacer);
            Name = "ManageUsersForm";
            Text = "Manage Users";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panelControls.ResumeLayout(false);
            ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Panel panelSpacer;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnFireUser;
        private System.Windows.Forms.Button btnEditSchedule;
        private System.Windows.Forms.Button btnAutoSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpec;
    }
}