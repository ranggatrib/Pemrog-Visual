using System;
using System.Windows.Forms;
using Project.Core; 
using Project.Forms; 

namespace Project.Forms
{
    public partial class FormAdminDashboard : Form
    {
        public FormAdminDashboard()
        {
            InitializeComponent();
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            FormProdukAdmin produkAdminForm = new FormProdukAdmin();
            this.Hide();
            produkAdminForm.Show();
            produkAdminForm.FormClosed += (s, args) => this.Show(); // Show dashboard again when this form closes
        }

        private void btnViewTransactions_Click(object sender, EventArgs e)
        {
            FormAdminTransactions adminTransactionsForm = new FormAdminTransactions();
            this.Hide();
            adminTransactionsForm.Show();
            adminTransactionsForm.FormClosed += (s, args) => this.Show(); // Show dashboard again when this form closes
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            FormUserManagement userManagementForm = new FormUserManagement();
            this.Hide();
            userManagementForm.Show();
            userManagementForm.FormClosed += (s, args) => this.Show(); // Show dashboard again when this form closes
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Instance.LogoutUser(); // Clear session
            this.Close(); // Close dashboard
            FormLogin loginForm = new FormLogin(); // Return to Login Form
            loginForm.Show();
        }
    }
}