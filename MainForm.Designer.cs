namespace program
{
    partial class MainForm
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
            MainMenuStrip = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            FileLangChangeToolStripMenuItem = new ToolStripMenuItem();
            FileExitToolStripMenuItem = new ToolStripMenuItem();
            RegistrarToolStripMenuItem = new ToolStripMenuItem();
            PatientSearchToolStripMenuItem = new ToolStripMenuItem();
            PatientNewToolStripMenuItem = new ToolStripMenuItem();
            TerminToolStripMenuItem = new ToolStripMenuItem();
            DoctorToolStripMenuItem = new ToolStripMenuItem();
            MyQueueToolStripMenuItem = new ToolStripMenuItem();
            AdminToolStripMenuItem = new ToolStripMenuItem();
            ManageUsersToolStripMenuItem = new ToolStripMenuItem();
            StatisticsToolStripMenuItem = new ToolStripMenuItem();
            MainStatusStrip = new StatusStrip();
            UserStatusLabel = new ToolStripStatusLabel();
            MainMenuStrip.SuspendLayout();
            MainStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenuStrip
            // 
            MainMenuStrip.BackColor = Color.DimGray;
            MainMenuStrip.ImageScalingSize = new Size(20, 20);
            MainMenuStrip.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, RegistrarToolStripMenuItem, DoctorToolStripMenuItem, AdminToolStripMenuItem });
            MainMenuStrip.Location = new Point(0, 0);
            MainMenuStrip.Name = "MainMenuStrip";
            MainMenuStrip.RenderMode = ToolStripRenderMode.Professional;
            MainMenuStrip.Size = new Size(800, 31);
            MainMenuStrip.TabIndex = 1;
            MainMenuStrip.Text = "File";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.BackColor = Color.Transparent;
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { FileLangChangeToolStripMenuItem, FileExitToolStripMenuItem });
            FileToolStripMenuItem.Font = new Font("Palatino Linotype", 10.2F);
            FileToolStripMenuItem.ForeColor = Color.Wheat;
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(47, 27);
            FileToolStripMenuItem.Text = "file";
            // 
            // FileLangChangeToolStripMenuItem
            // 
            FileLangChangeToolStripMenuItem.BackColor = Color.Gray;
            FileLangChangeToolStripMenuItem.Name = "FileLangChangeToolStripMenuItem";
            FileLangChangeToolStripMenuItem.Size = new Size(185, 28);
            FileLangChangeToolStripMenuItem.Text = "lang change";
            FileLangChangeToolStripMenuItem.Click += FileLangChangeToolStripMenuItem_Click;
            // 
            // FileExitToolStripMenuItem
            // 
            FileExitToolStripMenuItem.BackColor = Color.Gray;
            FileExitToolStripMenuItem.Name = "FileExitToolStripMenuItem";
            FileExitToolStripMenuItem.Size = new Size(185, 28);
            FileExitToolStripMenuItem.Text = "exit";
            // 
            // RegistrarToolStripMenuItem
            // 
            RegistrarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { PatientSearchToolStripMenuItem, PatientNewToolStripMenuItem, TerminToolStripMenuItem });
            RegistrarToolStripMenuItem.Font = new Font("Palatino Linotype", 10.2F);
            RegistrarToolStripMenuItem.ForeColor = Color.Wheat;
            RegistrarToolStripMenuItem.Name = "RegistrarToolStripMenuItem";
            RegistrarToolStripMenuItem.Size = new Size(82, 27);
            RegistrarToolStripMenuItem.Text = "register";
            // 
            // PatientSearchToolStripMenuItem
            // 
            PatientSearchToolStripMenuItem.BackColor = Color.Gray;
            PatientSearchToolStripMenuItem.Name = "PatientSearchToolStripMenuItem";
            PatientSearchToolStripMenuItem.Size = new Size(224, 28);
            PatientSearchToolStripMenuItem.Text = "PatientSearch";
            // 
            // PatientNewToolStripMenuItem
            // 
            PatientNewToolStripMenuItem.BackColor = Color.Gray;
            PatientNewToolStripMenuItem.Name = "PatientNewToolStripMenuItem";
            PatientNewToolStripMenuItem.Size = new Size(224, 28);
            PatientNewToolStripMenuItem.Text = "PatientNew";
            PatientNewToolStripMenuItem.Click += PatientNewToolStripMenuItem_Click;
            // 
            // TerminToolStripMenuItem
            // 
            TerminToolStripMenuItem.BackColor = Color.Gray;
            TerminToolStripMenuItem.Name = "TerminToolStripMenuItem";
            TerminToolStripMenuItem.Size = new Size(224, 28);
            TerminToolStripMenuItem.Text = "newTermin";
            TerminToolStripMenuItem.Click += TerminToolStripMenuItem_Click;
            // 
            // DoctorToolStripMenuItem
            // 
            DoctorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MyQueueToolStripMenuItem });
            DoctorToolStripMenuItem.Font = new Font("Palatino Linotype", 10.2F);
            DoctorToolStripMenuItem.ForeColor = Color.Wheat;
            DoctorToolStripMenuItem.Name = "DoctorToolStripMenuItem";
            DoctorToolStripMenuItem.Size = new Size(73, 27);
            DoctorToolStripMenuItem.Text = "doctor";
            // 
            // MyQueueToolStripMenuItem
            // 
            MyQueueToolStripMenuItem.BackColor = Color.Gray;
            MyQueueToolStripMenuItem.Name = "MyQueueToolStripMenuItem";
            MyQueueToolStripMenuItem.Size = new Size(224, 28);
            MyQueueToolStripMenuItem.Text = "MyQueue";
            // 
            // AdminToolStripMenuItem
            // 
            AdminToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ManageUsersToolStripMenuItem, StatisticsToolStripMenuItem });
            AdminToolStripMenuItem.Font = new Font("Palatino Linotype", 10.2F);
            AdminToolStripMenuItem.ForeColor = Color.Wheat;
            AdminToolStripMenuItem.Name = "AdminToolStripMenuItem";
            AdminToolStripMenuItem.Size = new Size(73, 27);
            AdminToolStripMenuItem.Text = "admin";
            // 
            // ManageUsersToolStripMenuItem
            // 
            ManageUsersToolStripMenuItem.BackColor = Color.Gray;
            ManageUsersToolStripMenuItem.Name = "ManageUsersToolStripMenuItem";
            ManageUsersToolStripMenuItem.Size = new Size(224, 28);
            ManageUsersToolStripMenuItem.Text = "ManageUsers";
            // 
            // StatisticsToolStripMenuItem
            // 
            StatisticsToolStripMenuItem.BackColor = Color.Gray;
            StatisticsToolStripMenuItem.Name = "StatisticsToolStripMenuItem";
            StatisticsToolStripMenuItem.Size = new Size(224, 28);
            StatisticsToolStripMenuItem.Text = "Statistics";
            // 
            // MainStatusStrip
            // 
            MainStatusStrip.BackColor = Color.Gray;
            MainStatusStrip.ImageScalingSize = new Size(20, 20);
            MainStatusStrip.Items.AddRange(new ToolStripItem[] { UserStatusLabel });
            MainStatusStrip.Location = new Point(0, 421);
            MainStatusStrip.Name = "MainStatusStrip";
            MainStatusStrip.Size = new Size(800, 29);
            MainStatusStrip.TabIndex = 2;
            MainStatusStrip.Text = "statusStrip1";
            // 
            // UserStatusLabel
            // 
            UserStatusLabel.BackColor = Color.Transparent;
            UserStatusLabel.Font = new Font("Segoe UI", 10.2F);
            UserStatusLabel.ForeColor = Color.Wheat;
            UserStatusLabel.Name = "UserStatusLabel";
            UserStatusLabel.Size = new Size(160, 23);
            UserStatusLabel.Text = "toolStripStatusLabel";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 450);
            Controls.Add(MainStatusStrip);
            Controls.Add(MainMenuStrip);
            Name = "MainForm";
            Text = "MainForm";
            MainMenuStrip.ResumeLayout(false);
            MainMenuStrip.PerformLayout();
            MainStatusStrip.ResumeLayout(false);
            MainStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainMenuStrip;
        private StatusStrip MainStatusStrip;
        private ToolStripStatusLabel UserStatusLabel;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem FileExitToolStripMenuItem;
        private ToolStripMenuItem RegistrarToolStripMenuItem;
        private ToolStripMenuItem DoctorToolStripMenuItem;
        private ToolStripMenuItem AdminToolStripMenuItem;
        private ToolStripMenuItem PatientSearchToolStripMenuItem;
        private ToolStripMenuItem PatientNewToolStripMenuItem;
        private ToolStripMenuItem TerminToolStripMenuItem;
        private ToolStripMenuItem MyQueueToolStripMenuItem;
        private ToolStripMenuItem ManageUsersToolStripMenuItem;
        private ToolStripMenuItem StatisticsToolStripMenuItem;
        private ToolStripMenuItem FileLangChangeToolStripMenuItem;
    }
}