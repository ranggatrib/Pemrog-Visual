using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Data;
using Project.Core;
using Project.Repositories;
using Project.Forms;

namespace Project.Forms
{
    public partial class FormLogin : Form
    {
        private UserRepository _userRepository;

        public FormLogin()
        {
            InitializeComponent();
            _userRepository = new UserRepository(new DatabaseConnection());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username and Password must be filled.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                User loggedInUser = _userRepository.GetUserByUsernameAndPassword(username, password);

                if (loggedInUser != null)
                {
                    SessionManager.Instance.LoginUser(loggedInUser);

                    this.Hide();

                    if (loggedInUser.Role == "admin")
                    {
                        FormAdminDashboard adminDashboardForm = new FormAdminDashboard();
                        adminDashboardForm.Show();
                    }
                    else
                    {
                        FormProdukUser userForm = new FormProdukUser();
                        userForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid credentials!", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegistrasi registerForm = new FormRegistrasi();
            registerForm.Show();
        }
    }
}