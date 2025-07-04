using System;
using System.Data;
using System.Windows.Forms; 

namespace Project.Forms
{
    public interface IUserManagementView
    {
        // Properti untuk membaca dan menulis nilai dari/ke View (input fields)
        string UserIdText { get; set; }
        string UsernameText { get; set; }
        string RoleText { get; set; }

        // Properti untuk membaca pengguna yang dipilih dari DataGridView
        int SelectedUserId { get; }
        string SelectedUsername { get; }
        string SelectedRole { get; }

        // Metode untuk menampilkan/memperbarui data ke DataGridView
        void DisplayUsers(DataTable users);

        // Metode untuk membersihkan field input
        void ClearFields();

        // PERBAIKAN DI SINI: Ubah return type dari void menjadi DialogResult
        DialogResult ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);

        // Metode untuk menavigasi kembali
        void HideView();
        void ShowAdminDashboard();

        // Event yang akan diekspos oleh View dan ditangani oleh Controller
        event EventHandler LoadView;
        event DataGridViewCellEventHandler UsersCellClick;
        event EventHandler UpdateUserButtonClick;
        event EventHandler DeleteUserButtonClick;
        event EventHandler BackToDashboardButtonClick;
    }
}