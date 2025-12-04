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

            // Отключаем автогенерацию колонок, чтобы использовать наши настройки из Дизайнера
            dgvUsers.AutoGenerateColumns = false;

            UpdateLocalization();
            LoadUsers();
        }

        public void UpdateLocalization()
        {
            this.Text = LocalizationManager.GetString("ManageUsers_Title");

            // Обновляем заголовки колонок
            if (dgvUsers.Columns["colName"] != null) dgvUsers.Columns["colName"].HeaderText = LocalizationManager.GetString("ManageUsers_Col_Name");
            if (dgvUsers.Columns["colRole"] != null) dgvUsers.Columns["colRole"].HeaderText = LocalizationManager.GetString("ManageUsers_Col_Role");
            if (dgvUsers.Columns["colSpec"] != null) dgvUsers.Columns["colSpec"].HeaderText = LocalizationManager.GetString("ManageUsers_Col_Spec");

            // Обновляем кнопки
            btnAddUser.Text = LocalizationManager.GetString("ManageUsers_Btn_Add");
            btnFireUser.Text = LocalizationManager.GetString("ManageUsers_Btn_Fire");
            btnEditSchedule.Text = LocalizationManager.GetString("ManageUsers_Btn_Schedule");
            btnAutoSchedule.Text = LocalizationManager.GetString("ManageUsers_Btn_Auto");

            // Перезагружаем список, чтобы обновились локализованные должности (RoleLocalized)
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = _repo.GetAllUsers();
            dgvUsers.DataSource = users;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Переходимо до кроку 2: Додавання користувача");
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
                LoadUsers();
            }
        }
    }
}