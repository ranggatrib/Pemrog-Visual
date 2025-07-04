using System;

namespace Project.Forms
{
    public interface IAdminDashboardView
    {
        // Metode untuk menampilkan/menyembunyikan View
        void HideView();
        void ShowView(); // Digunakan saat form anak ditutup

        // Metode untuk menavigasi ke Form lain
        void ShowManageProductsForm();
        void ShowViewTransactionsForm();
        void ShowManageUsersForm();
        void ShowLoginForm();

        // Event yang akan diekspos oleh View dan ditangani oleh Controller
        event EventHandler ManageProductsButtonClick;
        event EventHandler ViewTransactionsButtonClick;
        event EventHandler ManageUsersButtonClick;
        event EventHandler LogoutButtonClick;
    }
}