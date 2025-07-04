using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Core;
using Project.Data;
using Project.Forms;
using Project.Repositories;

namespace Project.Controllers
{
    public class UserManagementController
    {
        private IUserManagementView _view;
        private UserRepository _userRepository;

        private User _selectedUser; // Internal state for the currently selected user

        public UserManagementController(IUserManagementView view, UserRepository userRepository)
        {
            _view = view;
            _userRepository = userRepository;
            _selectedUser = new User(); // Inisialisasi awal

            // Langganan event dari View
            _view.LoadView += OnLoadView;
            _view.UsersCellClick += OnUsersCellClick;
            _view.UpdateUserButtonClick += OnUpdateUserButtonClick;
            _view.DeleteUserButtonClick += OnDeleteUserButtonClick;
            _view.BackToDashboardButtonClick += OnBackToDashboardButtonClick;
        }

        // --- Event Handlers dari View yang ditangani oleh Controller ---

        private void OnLoadView(object sender, EventArgs e)
        {
            LoadUsers();
            ClearInputFields();
        }

        private void OnUsersCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Mengisi objek _selectedUser dengan data dari View
                _selectedUser = new User
                {
                    Id = _view.SelectedUserId,
                    Username = _view.SelectedUsername,
                    Role = _view.SelectedRole
                };

                // Mengisi field form di View dengan data pengguna yang dipilih
                _view.UserIdText = _selectedUser.Id.ToString();
                _view.UsernameText = _selectedUser.Username;
                _view.RoleText = _selectedUser.Role;
            }
        }

        private void OnUpdateUserButtonClick(object sender, EventArgs e)
        {
            if (_selectedUser == null || _selectedUser.Id == 0)
            {
                _view.ShowMessage("Silakan pilih pengguna untuk diperbarui.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(_view.UsernameText) || string.IsNullOrEmpty(_view.RoleText))
            {
                _view.ShowMessage("Username dan Role tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _selectedUser.Username = _view.UsernameText.Trim();
                _selectedUser.Role = _view.RoleText;

                bool success = _userRepository.UpdateUser(_selectedUser);
                if (success)
                {
                    _view.ShowMessage("Pengguna berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    ClearInputFields();
                }
                else
                {
                    _view.ShowMessage("Gagal memperbarui pengguna.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database saat memperbarui pengguna: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Terjadi kesalahan tak terduga selama pembaruan pengguna: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteUserButtonClick(object sender, EventArgs e)
        {
            if (_selectedUser == null || _selectedUser.Id == 0)
            {
                _view.ShowMessage("Silakan pilih pengguna untuk dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SessionManager.Instance.IsLoggedIn && SessionManager.Instance.CurrentUser.Id == _selectedUser.Id)
            {
                _view.ShowMessage("Anda tidak dapat menghapus akun Anda sendiri saat login.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_view.ShowMessage($"Anda yakin ingin menghapus pengguna '{_selectedUser.Username}'? Tindakan ini tidak dapat dibatalkan.", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool success = _userRepository.DeleteUser(_selectedUser.Id);
                    if (success)
                    {
                        _view.ShowMessage("Pengguna berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                        ClearInputFields();
                    }
                    else
                    {
                        _view.ShowMessage("Gagal menghapus pengguna.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1451) // Foreign key constraint violation
                    {
                        _view.ShowMessage("Tidak dapat menghapus pengguna: Pengguna ini memiliki transaksi atau data terkait. Harap hapus data terkait terlebih dahulu.", "Kesalahan Penghapusan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _view.ShowMessage("Kesalahan Database saat menghapus pengguna: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    _view.ShowMessage("Terjadi kesalahan tak terduga selama penghapusan pengguna: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnBackToDashboardButtonClick(object sender, EventArgs e)
        {
            _view.HideView();
            _view.ShowAdminDashboard();
        }

        // --- Metode Internal yang Digunakan oleh Controller ---

        private void LoadUsers()
        {
            try
            {
                _view.DisplayUsers(_userRepository.GetAllUsers());
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database saat memuat pengguna: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Gagal memuat pengguna: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            _view.ClearFields(); // Panggil metode ClearFields di View
            _selectedUser = new User(); // Reset objek pengguna yang sedang dipilih
        }
    }
}