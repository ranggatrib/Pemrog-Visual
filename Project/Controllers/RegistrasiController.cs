using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Data;
using Project.Forms;
using Project.Repositories;

namespace Project.Controllers
{
    public class RegistrasiController
    {
        private IRegistrasiView _view;
        private UserRepository _userRepository;

        public RegistrasiController(IRegistrasiView view, UserRepository userRepository)
        {
            _view = view;
            _userRepository = userRepository;

            // Langganan event dari View
            _view.RegisterButtonClick += OnRegisterButtonClick;
            _view.BackToLoginButtonClick += OnBackToLoginButtonClick;
        }

        // --- Event Handlers dari View yang ditangani oleh Controller ---
        private void OnRegisterButtonClick(object sender, EventArgs e)
        {
            string username = _view.Username;
            string password = _view.Password;
            string confirmPassword = _view.ConfirmPassword;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                _view.ShowMessage("Semua field harus diisi.", "Kesalahan Registrasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                _view.ShowMessage("Password harus minimal 6 karakter.", "Kesalahan Registrasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                _view.ShowMessage("Password dan Konfirmasi Password tidak cocok.", "Kesalahan Registrasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_userRepository.IsUsernameExists(username))
                {
                    _view.ShowMessage("Username sudah digunakan. Harap pilih yang lain.", "Registrasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                User newUser = new User
                {
                    Username = username,
                    Password = password,
                    Role = "user"
                };

                _userRepository.AddUser(newUser);

                _view.ShowMessage("Registrasi berhasil! Anda sekarang bisa login.", "Registrasi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _view.HideView();
                _view.ShowLoginForm();
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database selama registrasi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Terjadi kesalahan tak terduga selama registrasi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnBackToLoginButtonClick(object sender, EventArgs e)
        {
            _view.HideView();
            _view.ShowLoginForm();
        }
    }
}