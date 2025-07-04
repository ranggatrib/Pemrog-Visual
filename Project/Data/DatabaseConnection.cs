using MySql.Data.MySqlClient;
using System.Configuration; 

namespace Project.Data
{
    public class DatabaseConnection
    {
        private string connStr;

        public DatabaseConnection()
        {
            connStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }
    }
}