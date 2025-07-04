using System;
using System.Data;
using System.Windows.Forms;
using Project.Data;
using Project.Repositories;
using Project.Controllers;

namespace Project.Forms
{
    public partial class FormUserManagement : Form, IUserManagementView
    {
        private UserManagementController _controller;

        public string UserIdText
        {
            get => txtUserId.Text;
            set => txtUserId.Text = value;
        }

        public string UsernameText
        {
            get => txtUsername.Text;
            set => txtUsername.Text = value;
        }

        public string RoleText
        {
            get => cmbRole.SelectedItem?.ToString();
            set => cmbRole.SelectedItem = value;
        }

        public int SelectedUserId { get; private set; }
        public string SelectedUsername { get; private set; }
        public string SelectedRole { get; private set; }

        public FormUserManagement()
        {
            InitializeComponent();

            if (cmbRole.Items.Count == 0)
            {
                cmbRole.Items.AddRange(new object[] { "admin", "user" });
            }

            _controller = new UserManagementController(this, new UserRepository(new DatabaseConnection()));

            this.Load += (sender, e) => LoadView?.Invoke(sender, e);

            dgvUsers.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                    SelectedUserId = Convert.ToInt32(row.Cells["Id"].Value);
                    SelectedUsername = row.Cells["Username"].Value.ToString();
                    SelectedRole = row.Cells["Role"].Value.ToString();
                }
                UsersCellClick?.Invoke(sender, e);
            };

            btnUpdateUser.Click += (sender, e) => UpdateUserButtonClick?.Invoke(sender, e);
            btnDeleteUser.Click += (sender, e) => DeleteUserButtonClick?.Invoke(sender, e);
            btnBackToDashboard.Click += (sender, e) => BackToDashboardButtonClick?.Invoke(sender, e);
        }

        public void DisplayUsers(DataTable users)
        {
            dgvUsers.DataSource = users;
            if (dgvUsers.Columns.Contains("Id")) dgvUsers.Columns["Id"].Visible = false;
            dgvUsers.ClearSelection();
        }

        public void ClearFields()
        {
            txtUserId.Clear();
            txtUsername.Clear();
            cmbRole.SelectedIndex = -1;
            SelectedUserId = 0;
            SelectedUsername = string.Empty;
            SelectedRole = string.Empty;
        }

        public DialogResult ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, title, buttons, icon);
        }

        public void HideView()
        {
            this.Hide();
        }

        public void ShowAdminDashboard()
        {
            FormAdminDashboard dashboardForm = new FormAdminDashboard();
            dashboardForm.Show();
        }

        public event EventHandler LoadView;
        public event DataGridViewCellEventHandler UsersCellClick;
        public event EventHandler UpdateUserButtonClick;
        public event EventHandler DeleteUserButtonClick;
        public event EventHandler BackToDashboardButtonClick;
    }
}
