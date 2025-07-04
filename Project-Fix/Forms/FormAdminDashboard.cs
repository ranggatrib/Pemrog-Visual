using System;
using System.Windows.Forms;
using Project.Controllers;

namespace Project.Forms
{
    public partial class FormAdminDashboard : Form, IAdminDashboardView
    {
        private AdminDashboardController _controller;

        public void HideView()
        {
            this.Hide();
        }

        public void ShowView()
        {
            this.Show();
        }

        public void ShowManageProductsForm()
        {
            FormProdukAdmin produkAdminForm = new FormProdukAdmin();
            produkAdminForm.Show();
        }

        public void ShowViewTransactionsForm()
        {
            FormAdminTransactions adminTransactionsForm = new FormAdminTransactions();
            adminTransactionsForm.Show();
        }

        public void ShowManageUsersForm()
        {
            FormUserManagement userManagementForm = new FormUserManagement();
            userManagementForm.Show();
        }

        public void ShowLoginForm()
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
        }

        public event EventHandler ManageProductsButtonClick;
        public event EventHandler ViewTransactionsButtonClick;
        public event EventHandler ManageUsersButtonClick;
        public event EventHandler LogoutButtonClick;

        public FormAdminDashboard()
        {
            InitializeComponent();

            _controller = new AdminDashboardController(this);

            btnManageProducts.Click += (sender, e) => ManageProductsButtonClick?.Invoke(sender, e);
            btnViewTransactions.Click += (sender, e) => ViewTransactionsButtonClick?.Invoke(sender, e);
            btnManageUsers.Click += (sender, e) => ManageUsersButtonClick?.Invoke(sender, e);
            btnLogout.Click += (sender, e) => LogoutButtonClick?.Invoke(sender, e);
        }
    }
}
