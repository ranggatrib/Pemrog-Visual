using System;
using System.Windows.Forms;
using Project.Data;
using Project.Repositories;
using Project.Controllers;

namespace Project.Forms
{
    public partial class FormRegistrasi : Form, IRegistrasiView
    {
        private readonly RegistrasiController _controller;

        public string Username => txtUsername.Text.Trim();
        public string Password => txtPassword.Text;
        public string ConfirmPassword => txtConfirmPassword.Text;

        public event EventHandler RegisterButtonClick;
        public event EventHandler BackToLoginButtonClick;

        public FormRegistrasi()
        {
            InitializeComponent();

            _controller = new RegistrasiController(
                this,
                new UserRepository(new DatabaseConnection())
            );

            btnRegister.Click += (sender, e) => RegisterButtonClick?.Invoke(sender, e);
            btnBackToLogin.Click += (sender, e) => BackToLoginButtonClick?.Invoke(sender, e);
        }

        public void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        public void HideView()
        {
            this.Hide();
        }

        public void ShowLoginForm()
        {
            var loginForm = new FormLogin();
            loginForm.Show();
        }
    }
}
