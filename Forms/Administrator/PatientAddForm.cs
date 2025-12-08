using program.dbClass.Models;
using program.Localization;
using program.Repositories;

namespace program.Forms
{
    public partial class PatientAddForm : Form, Localizable
    {
        private UserModel _currentUser;
        private readonly PatientRepository _repository;

        public PatientAddForm(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;
            _repository = new PatientRepository();
            
            UpdateLocalization();

            dtpDob.MaxDate = DateTime.Now; // > td
        }

        public void UpdateLocalization()
        {
            this.Text = LocalizationManager.GetString("PatientAddForm_Title");
            lblFullName.Text = LocalizationManager.GetString("PatientAddForm_Label_Name");
            lblDob.Text = LocalizationManager.GetString("PatientAddForm_Label_Dob");
            lblPhone.Text = LocalizationManager.GetString("PatientAddForm_Label_Phone");
            btnSave.Text = LocalizationManager.GetString("PatientAddForm_Button_Save");
            btnCancel.Text = LocalizationManager.GetString("PatientAddForm_Button_Cancel");

            dtpDob.UpdateLocalization();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtFullName.Text.Trim();
            DateTime dob = dtpDob.Value;
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show(LocalizationManager.GetString("PatientAddForm_Error_Empty"),
                                "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dob.Date > DateTime.Now.Date) // d < td
            {
                MessageBox.Show("Дата народження не може бути в майбутньому!",
                                "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _repository.Add(name, dob, phone);

            Logger.Log($"Added new patient: {name}, Phone: {phone}", _currentUser.Username);
            MessageBox.Show(LocalizationManager.GetString("PatientAddForm_Message_Success"),
                            "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            txtFullName.Clear();
            txtPhone.Clear();
            dtpDob.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtPhone.Clear();
            dtpDob.Value = DateTime.Now;
        }
    }
}