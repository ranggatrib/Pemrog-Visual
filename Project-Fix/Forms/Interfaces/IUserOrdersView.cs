using System;
using System.Data;
using System.Windows.Forms; 

namespace Project.Forms
{
    public interface IUserOrdersView
    {
        // Metode untuk menampilkan/memperbarui data ke DataGridView
        void DisplayUserOrders(DataTable orders);

        // Metode untuk menampilkan pesan
        void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);

        // Metode untuk menutup View
        void CloseView();

        // Event yang akan diekspos oleh View dan ditangani oleh Controller
        event EventHandler LoadView;
    }
}