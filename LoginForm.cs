using program.Repositories;
using program.dbClass.Models;
using program.Localization;

namespace program
{
    public partial class LoginForm : Form
    {
        private string _currentLang = "ukr";

        public UserModel LoggedInUser { get; private set; }
        public string CurrentLang => _currentLang;

        public LoginForm()
        {
            InitializeComponent();
            
            LocalizationManager.LoadLanguage(_currentLang);
            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            this.Text = LocalizationManager.GetString("LoginForm_Title");
            UsernameLabel.Text = LocalizationManager.GetString("LoginForm_UsernameLabel");
            FormNameLabel.Text = LocalizationManager.GetString("LoginForm_Title");
            PassLabel.Text = LocalizationManager.GetString("LoginForm_PasswordLabel");
            LoginButton.Text = LocalizationManager.GetString("LoginForm_LoginButton");
            LangChangButton.Text = LocalizationManager.GetString("LoginForm_LangToggleButton");
        }

        private void LangChangButton_Click(object sender, EventArgs e)
        {
            _currentLang = (_currentLang == "ukr") ? "eng" : "ukr";
            LocalizationManager.LoadLanguage(_currentLang);
            ApplyLocalization();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTxtBox.Text;
            string password = PassTxtBox.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(LocalizationManager.GetString("LoginForm_ErrorEmpty"), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UserRepository repo = new UserRepository();
            UserModel user = repo.ValidateUser(username, password);

            if (user != null)
            {
                this.LoggedInUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(LocalizationManager.GetString("LoginForm_ErrorInvalid"), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}