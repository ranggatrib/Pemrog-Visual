// Project/Forms/IRegistrasiView.cs
using System;
using System.Windows.Forms; // Untuk MessageBoxButtons, MessageBoxIcon, DialogResult

namespace Project.Forms
{
    public interface IRegistrasiView
    {
        // Properti untuk membaca input dari View
        string Username { get; }
        string Password { get; }
        string ConfirmPassword { get; }

        // Metode untuk menampilkan pesan
        void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);

        // Metode untuk menavigasi ke Form lain
        void HideView();
        void ShowLoginForm();

        // Event yang akan diekspos oleh View dan ditangani oleh Controller
        event EventHandler RegisterButtonClick;
        event EventHandler BackToLoginButtonClick;
    }
}