using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project.Forms
{
    public interface IPaymentView
    {
        // Properti yang akan diatur oleh Controller untuk ditampilkan di View
        string GrandTotalLabel { set; }
        string ChangeLabel { set; }
        Color ChangeLabelColor { set; }

        // Properti untuk membaca input dari View
        string AmountPaidText { get; set; }
        string PaymentMethod { get; set; } // PERBAIKAN: Tambahkan 'set;' di sini
        string BuktiTransferPath { get; set; }

        // Properti untuk mengontrol visibilitas elemen UI
        bool BuktiTransferVisible { set; }
        bool AmountPaidEnabled { set; }
        bool BrowseProofVisible { set; }
        bool AdminRekeningVisible { set; }
        string AdminRekeningText { set; }


        // Metode untuk menampilkan pesan
        void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);

        // Metode untuk menutup Form dan mengatur DialogResult
        void CloseView();
        void SetDialogResult(DialogResult result);

        // Metode untuk memicu dialog OpenFileDialog
        DialogResult ShowOpenFileDialog(string filter, out string fileName);

        // Event yang akan diekspos oleh View dan ditangani oleh Controller
        event EventHandler LoadView;
        event EventHandler AmountPaidTextChanged;
        event EventHandler PaymentMethodSelectedIndexChanged;
        event EventHandler PayButtonClick;
        event EventHandler CancelButtonClick;
        event EventHandler BrowseProofButtonClick;
    }
}