using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms; 
using Project.Data; 

namespace Project.Forms
{
    public interface ICartView
    {
        // Properti untuk mengakses data dari View
        int SelectedCartItemId { get; }

        // Properti untuk menampilkan data ke View
        string GrandTotalText { set; }
        bool CheckoutButtonEnabled { set; }
        bool RemoveItemButtonEnabled { set; }

        // Metode untuk menampilkan/memperbarui data ke DataGridView
        void DisplayCartItems(DataTable cartItems);

        // PERBAIKAN DI SINI: Ubah return type dari void menjadi DialogResult
        DialogResult ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);

        // Metode untuk menutup Form dan mengatur DialogResult
        void CloseView();
        void SetDialogResult(DialogResult result);

        // Metode untuk memanggil Form eksternal yang diinisiasi oleh Controller
        DialogResult ShowShippingDetailsForm(out string namaPenerima, out string alamatPengiriman, out string nomorTeleponPenerima);
        DialogResult ShowPaymentForm(decimal grandTotal, List<CartItem> cartItems, string namaPenerima, string alamatPengiriman, string nomorTeleponPenerima);

        // Event yang akan diekspos oleh View dan ditangani oleh Controller
        event EventHandler LoadView;
        event EventHandler RemoveItemButtonClick;
        event EventHandler CheckoutButtonClick;
        event DataGridViewCellEventHandler CartItemsCellClick;
    }
}