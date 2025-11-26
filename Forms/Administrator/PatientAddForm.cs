using program.dbClass.Models;
using program.Localization;


namespace program.Forms
{
    public partial class PatientAddForm : Form, Localizable
    {
        private UserModel _currentUser;
        public PatientAddForm(UserModel user)
        {   
            InitializeComponent();
            _currentUser = user;
        }

        public void UpdateLocalization()
        {
            
        }

        private void PatientAddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
