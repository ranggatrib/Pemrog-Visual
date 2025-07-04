using System.Windows.Forms;
using Project.Data;
using Project.Repositories;
using Project.Controllers;

namespace Project.Forms
{
    public partial class FormLogin : Form, ILoginView
    {
        private LoginController _controller;

        public string Username => txtUsername.Text.Trim();
        public string Password => txtPassword.Text;

        public FormLogin()
        {
            InitializeComponent();
            _controller = new LoginController(this, new UserRepository(new DatabaseConnection()));

            btnLogin.Click += (sender, e) => _controller.OnLoginAttempt();
            btnRegister.Click += (sender, e) => _controller.OnRegisterRequested();
        }

        public void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        public void HideView()
        {
            this.Hide();
        }

        public void ShowAdminDashboard()
        {
            FormAdminDashboard adminDashboardForm = new FormAdminDashboard();
            adminDashboardForm.Show();
        }

        public void ShowUserDashboard()
        {
            FormProdukUser userForm = new FormProdukUser();
            userForm.Show();
        }

        public void ShowRegistrationForm()
        {
            FormRegistrasi registerForm = new FormRegistrasi();
            registerForm.Show();
        }
    }
}