using program.dbClass;
using program.dbClass.Models;
using program.Localization;
using program.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace program.Forms.chiefDoctor
{
    public partial class UserAddForm : Form, Localizable
    {
        private UserRepository _repo;
        private UserModel _currentUser;
        private class RoleItem
        {
            public string Display { get; set; }
            public UserRole Value { get; set; }
        }

        public UserAddForm(UserModel currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser; 
            _repo = new UserRepository();

            LoadRoles();
            UpdateLocalization();

            cmbRole.SelectedIndexChanged += CmbRole_SelectedIndexChanged;
            CmbRole_SelectedIndexChanged(null, null);
        }

        public void UpdateLocalization()
        {
            this.Text = LocalizationManager.GetString("UserAddForm_Title");
            lblFullName.Text = LocalizationManager.GetString("UserAddForm_Label_FullName");
            lblUsername.Text = LocalizationManager.GetString("UserAddForm_Label_Username");
            lblPassword.Text = LocalizationManager.GetString("UserAddForm_Label_Password");
            lblRole.Text = LocalizationManager.GetString("UserAddForm_Label_Role");
            lblSpec.Text = LocalizationManager.GetString("UserAddForm_Label_Spec");
            btnSave.Text = LocalizationManager.GetString("UserAddForm_Btn_Save");
            btnCancel.Text = LocalizationManager.GetString("UserAddForm_Btn_Cancel");

            var currentRole = cmbRole.SelectedValue;
            LoadRoles();
            if (currentRole != null)
            {
                cmbRole.SelectedValue = currentRole;
            }
        }

        private void LoadRoles()
        { 
            List<RoleItem> items = new List<RoleItem>();

            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                items.Add(new RoleItem
                {
                    Display = role.GetLocalizedName(),
                    Value = role
                });
            }

            cmbRole.DataSource = null; 
            cmbRole.DataSource = items;
            cmbRole.DisplayMember = "Display";
            cmbRole.ValueMember = "Value";

            if (items.Count > 0 && cmbRole.SelectedIndex < 0)
                cmbRole.SelectedIndex = 0;
        }

        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (cmbRole.SelectedValue is UserRole role && role == UserRole.Doctor)
            {
                txtSpec.Enabled = true;
                txtSpec.BackColor = Color.Wheat;
            }
            else
            {
                txtSpec.Enabled = false;
                txtSpec.BackColor = Color.Silver;
                txtSpec.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string spec = txtSpec.Text.Trim();

         
            if (cmbRole.SelectedValue == null) return;
            UserRole selectedRole = (UserRole)cmbRole.SelectedValue;


            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(LocalizationManager.GetString("UserAddForm_Error_Empty"),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (selectedRole == UserRole.Doctor && string.IsNullOrEmpty(spec))
            {
                MessageBox.Show(LocalizationManager.GetString("UserAddForm_Error_SpecRequired"),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (_repo.CheckUsernameExists(username))
            {
                MessageBox.Show(LocalizationManager.GetString("UserAddForm_Error_UserExists"),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            try
            {

                if (selectedRole != UserRole.Doctor) spec = "-";

                _repo.AddUser(fullName, username, password, selectedRole.ToString(), spec);

                Logger.Log($"Added new user: {fullName} (Login: {username}, Role: {selectedRole})", _currentUser.Username);
                MessageBox.Show(LocalizationManager.GetString("UserAddForm_Msg_Success"),
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}