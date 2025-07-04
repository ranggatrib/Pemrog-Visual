using System;
using System.Windows.Forms;

namespace Project.Forms
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; }
        void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);
        void HideView();
        void ShowAdminDashboard();
        void ShowUserDashboard();
        void ShowRegistrationForm();
    }
}