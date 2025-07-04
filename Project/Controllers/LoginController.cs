using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Core;
using Project.Data;
using Project.Forms;
using Project.Repositories;

namespace Project.Controllers
{
    public class LoginController
    {
        private ILoginView _view;
        private UserRepository _userRepository;

        public LoginController(ILoginView view, UserRepository userRepository)
        {
            _view = view;
            _userRepository = userRepository;
        }

        public void OnLoginAttempt()
        {
            try
            {
                string username = _view.Username;
                string password = _view.Password;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    _view.ShowMessage("Username dan Password harus diisi.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                User loggedInUser = _userRepository.GetUserByUsernameAndPassword(username, password);

                if (loggedInUser != null)
                {
                    SessionManager.Instance.LoginUser(loggedInUser);
                    _view.HideView();
                    if (loggedInUser.Role == "admin")
                    {
                        _view.ShowAdminDashboard();
                    }
                    else
                    {
                        _view.ShowUserDashboard();
                    }
                }
                else
                {
                    _view.ShowMessage("Kredensial tidak valid!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Terjadi kesalahan tak terduga: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OnRegisterRequested()
        {
            _view.HideView();
            _view.ShowRegistrationForm();
        }
    }
}