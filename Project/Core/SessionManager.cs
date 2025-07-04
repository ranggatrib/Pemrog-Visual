using Project.Data;

namespace Project.Core
{
    public sealed class SessionManager
    {
        private static readonly SessionManager instance = new SessionManager();

        public User CurrentUser { get; private set; }

        private SessionManager() { }

        public static SessionManager Instance
        {
            get { return instance; }
        }

        public void LoginUser(User user)
        {
            CurrentUser = user;
        }

        public void LogoutUser()
        {
            CurrentUser = null;
        }

        public bool IsLoggedIn
        {
            get { return CurrentUser != null; }
        }

        public bool IsAdmin
        {
            get { return CurrentUser != null && CurrentUser.Role == "admin"; }
        }
    }
}