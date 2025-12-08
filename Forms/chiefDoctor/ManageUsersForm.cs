using program.dbClass.Models;
using program.Localization;
using program.Repositories;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace program.Forms.chiefDoctor
{
    public partial class ManageUsersForm : Form, Localizable
    {
        private UserModel _currentUser;
        private UserRepository _repo;

        public ManageUsersForm(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;
            _repo = new UserRepository();

            dgvUsers.AutoGenerateColumns = false; 

            dgvUsers.Columns.Clear();

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colID";
            colId.DataPropertyName = "UserID";
            colId.Visible = false;
            dgvUsers.Columns.Add(colId);

            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.Name = "colName";
            colName.HeaderText = "Name"; 
            colName.DataPropertyName = "FullName";
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvUsers.Columns.Add(colName);

            DataGridViewTextBoxColumn colRole = new DataGridViewTextBoxColumn();
            colRole.Name = "colRole";
            colRole.HeaderText = "Role";
            colRole.DataPropertyName = "RoleLocalized"; 
            colRole.Width = 150;
            dgvUsers.Columns.Add(colRole);

            DataGridViewTextBoxColumn colSpec = new DataGridViewTextBoxColumn();
            colSpec.Name = "colSpec";
            colSpec.HeaderText = "Specialization";
            colSpec.DataPropertyName = "Specialization"; 
            colSpec.Width = 150;
            dgvUsers.Columns.Add(colSpec);

            UpdateLocalization();
            LoadUsers();
        }

        public void UpdateLocalization()
        {
            this.Text = LocalizationManager.GetString("ManageUsers_Title");

            if (dgvUsers.Columns["colName"] != null) dgvUsers.Columns["colName"].HeaderText = LocalizationManager.GetString("ManageUsers_Col_Name");
            if (dgvUsers.Columns["colRole"] != null) dgvUsers.Columns["colRole"].HeaderText = LocalizationManager.GetString("ManageUsers_Col_Role");
            if (dgvUsers.Columns["colSpec"] != null) dgvUsers.Columns["colSpec"].HeaderText = LocalizationManager.GetString("ManageUsers_Col_Spec");

            btnAddUser.Text = LocalizationManager.GetString("ManageUsers_Btn_Add");
            btnFireUser.Text = LocalizationManager.GetString("ManageUsers_Btn_Fire");
            btnEditSchedule.Text = LocalizationManager.GetString("ManageUsers_Btn_Schedule");

            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = _repo.GetAllUsers();
            dgvUsers.DataSource = users;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (UserAddForm addForm = new UserAddForm(_currentUser))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();
                }
            }
        }

        private void btnFireUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;

            var selectedUser = (UserModel)dgvUsers.SelectedRows[0].DataBoundItem;

            if (selectedUser.UserID == _currentUser.UserID)
            {
                MessageBox.Show("Ви не можете звільнити самі себе!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Ви впевнені, що хочете звільнити співробітника {selectedUser.FullName}?\nВін зникне зі списку.",
                                         "Звільнення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _repo.UpdateUserStatus(selectedUser.UserID, false);
                Logger.Log($"Fired user: {selectedUser.FullName} (ID: {selectedUser.UserID})", _currentUser.Username);
                LoadUsers();
            }
        }

        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            DoctorScheduleForm form = new DoctorScheduleForm();
            form.ShowDialog();
        }
    }
}