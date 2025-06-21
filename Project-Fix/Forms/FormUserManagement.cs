using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Data;
using Project.Repositories;
using Project.Core;
using Project.Forms;

namespace Project.Forms
{
    public partial class FormUserManagement : Form
    {
        private UserRepository _userRepository;
        private User selectedUser = new User();

        public FormUserManagement()
        {
            InitializeComponent();
            _userRepository = new UserRepository(new DatabaseConnection());
            cmbRole.Items.AddRange(new object[] { "user", "admin" });
        }

        private void FormUserManagement_Load(object sender, EventArgs e)
        {
            LoadUsers();
            ClearFields();
        }

        private void LoadUsers()
        {
            try
            {
                dgvUsers.DataSource = _userRepository.GetAllUsers();
                dgvUsers.ClearSelection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                selectedUser = new User
                {
                    Id = Convert.ToInt32(row.Cells["Id"].Value),
                    Username = row.Cells["Username"].Value.ToString(),
                    Role = row.Cells["Role"].Value.ToString()
                };

                txtUserId.Text = selectedUser.Id.ToString();
                txtUsername.Text = selectedUser.Username;
                cmbRole.SelectedItem = selectedUser.Role;
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (selectedUser == null || selectedUser.Id == 0)
            {
                MessageBox.Show("Please select a user to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(cmbRole.Text))
            {
                MessageBox.Show("Username and Role cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedUser.Username = txtUsername.Text.Trim();
                selectedUser.Role = cmbRole.Text;

                bool success = _userRepository.UpdateUser(selectedUser);
                if (success)
                {
                    MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to update user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred during user update: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (selectedUser == null || selectedUser.Id == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SessionManager.Instance.IsLoggedIn && SessionManager.Instance.CurrentUser.Id == selectedUser.Id)
            {
                MessageBox.Show("You cannot delete your own account while logged in.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete user '{selectedUser.Username}'? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool success = _userRepository.DeleteUser(selectedUser.Id);
                    if (success)
                    {
                        MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1451)
                    {
                        MessageBox.Show("Cannot delete user: This user has existing transactions or linked data. Please delete linked data first.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Database Error deleting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred during user deletion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearFields()
        {
            txtUserId.Text = "";
            txtUsername.Text = "";
            cmbRole.SelectedIndex = -1;
            selectedUser = new User();
        }

        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAdminDashboard dashboardForm = new FormAdminDashboard();
            dashboardForm.Show();
        }
    }
}