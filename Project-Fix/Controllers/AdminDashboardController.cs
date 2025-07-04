using System;
using Project.Core;
using Project.Forms;

namespace Project.Controllers
{
    public class AdminDashboardController
    {
        private IAdminDashboardView _view;

        public AdminDashboardController(IAdminDashboardView view)
        {
            _view = view;
            // Langganan event dari View
            _view.ManageProductsButtonClick += OnManageProductsButtonClick;
            _view.ViewTransactionsButtonClick += OnViewTransactionsButtonClick;
            _view.ManageUsersButtonClick += OnManageUsersButtonClick;
            _view.LogoutButtonClick += OnLogoutButtonClick;
        }

        // --- Event Handlers dari View yang ditangani oleh Controller ---
        private void OnManageProductsButtonClick(object sender, EventArgs e)
        {
            _view.HideView();
            // Saat Form anak ditutup, ShowView() akan dipanggil dari event FormClosed-nya
            FormProdukAdmin produkAdminForm = new FormProdukAdmin();
            produkAdminForm.FormClosed += (s, args) => _view.ShowView();
            produkAdminForm.Show();
        }

        private void OnViewTransactionsButtonClick(object sender, EventArgs e)
        {
            _view.HideView();
            // Saat Form anak ditutup, ShowView() akan dipanggil dari event FormClosed-nya
            FormAdminTransactions adminTransactionsForm = new FormAdminTransactions();
            adminTransactionsForm.FormClosed += (s, args) => _view.ShowView();
            adminTransactionsForm.Show();
        }

        private void OnManageUsersButtonClick(object sender, EventArgs e)
        {
            _view.HideView();
            // Saat Form anak ditutup, ShowView() akan dipanggil dari event FormClosed-nya
            FormUserManagement userManagementForm = new FormUserManagement();
            userManagementForm.FormClosed += (s, args) => _view.ShowView();
            userManagementForm.Show();
        }

        private void OnLogoutButtonClick(object sender, EventArgs e)
        {
            SessionManager.Instance.LogoutUser(); // Clear session
            _view.HideView(); // Close dashboard
            _view.ShowLoginForm(); // Return to Login Form
        }
    }
}