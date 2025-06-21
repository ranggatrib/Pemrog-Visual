using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Data;
using Project.Repositories;
using Project.Forms;

namespace Project.Forms
{
    public partial class FormRegistrasi : Form
    {
        private UserRepository _userRepository;

        public FormRegistrasi()
        {
            InitializeComponent();
            _userRepository = new UserRepository(new DatabaseConnection());
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("All fields must be filled.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_userRepository.IsUsernameExists(username))
                {
                    MessageBox.Show("Username already taken. Please choose another one.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                User newUser = new User
                {
                    Username = username,
                    Password = password, // PENTING: Di aplikasi nyata, HASH password di sini!
                    Role = "user"
                };

                _userRepository.AddUser(newUser);

                MessageBox.Show("Registration successful! You can now log in.", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error during registration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred during registration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
        }
    }
}