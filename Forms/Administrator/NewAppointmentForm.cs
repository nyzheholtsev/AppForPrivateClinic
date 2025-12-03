using program.dbClass.Models;
using program.Localization;
using System.Security.Cryptography.X509Certificates;

namespace program.Forms.Administrator
{
    public partial class NewAppointmentForm : Form, Localizable
    {
        private UserModel _currentUser;
        public NewAppointmentForm(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;
            UpdateLocalization();
        } 


        public void UpdateLocalization()
        {
            lblPathient.Text = LocalizationManager.GetString("NewAppointmentForm_Label_Patient");
            lblDoctor.Text = LocalizationManager.GetString("NewAppointmentForm_Label_Doctor");
            lblDate.Text = LocalizationManager.GetString("NewAppointmentForm_Label_Date");
            lblTime.Text = LocalizationManager.GetString("NewAppointmentForm_Label_Time");
            btnBook.Text = LocalizationManager.GetString("NewAppointmentForm_Button_Add");
            lblGlobalData.Text = LocalizationManager.GetString("NewAppointmentForm_Labell_GD");
        }
    }
}
