using System;
using System.Data;
using System.Windows.Forms;

namespace Project.Forms
{
    public interface IAdminTransactionsView
    {
        // Properti untuk membaca dan menulis nilai dari/ke View (input fields)
        string SelectedTransactionStatus { get; }

        // Properti untuk membaca transaksi yang dipilih dari DataGridView
        int SelectedTransactionId { get; }

        // Metode untuk menampilkan/memperbarui data ke DataGridView
        void DisplayTransactions(DataTable transactions);

        // Metode untuk mengatur pilihan awal ComboBox status
        void SetInitialStatusSelection(int index);

        // Metode untuk menampilkan pesan
        void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);

        // Metode untuk menavigasi kembali
        void HideView();
        void ShowAdminDashboard();

        // Event yang akan diekspos oleh View dan ditangani oleh Controller
        event EventHandler LoadView;
        event DataGridViewCellEventHandler TransactionsCellClick; // Untuk mengambil TransactionId yang dipilih
        event EventHandler UpdateStatusButtonClick;
        event EventHandler BackToDashboardButtonClick;
    }
}