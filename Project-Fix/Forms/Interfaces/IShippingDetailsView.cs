using System;
using System.Windows.Forms;

namespace Project.Forms
{
    public interface IShippingDetailsView
    {
        // Properti untuk membaca input dari View
        string NamaPenerimaText { get; }
        string AlamatPengirimanText { get; }
        string NomorTeleponPenerimaText { get; }

        // Metode untuk menampilkan pesan
        void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);

        // Metode untuk menutup View dan mengatur DialogResult
        void CloseView();
        void SetDialogResult(DialogResult result);

        // Event yang akan diekspos oleh View dan ditangani oleh Controller
        event EventHandler ContinuePaymentButtonClick;
        event EventHandler CancelButtonClick;
    }
}