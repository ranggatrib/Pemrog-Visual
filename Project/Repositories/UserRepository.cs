using MySql.Data.MySqlClient;
using Project.Data;
using System;
using System.Data;

namespace Project.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseConnection _dbConn;

        public UserRepository(DatabaseConnection dbConn)
        {
            _dbConn = dbConn;
        }

        public bool AddUser(User user)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                // IMPORTANT: In a real application, HASH the password here before storing!
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool IsUsernameExists(string username)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM users WHERE Username = @Username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Username, Role FROM users WHERE Username=@Username AND Password=@Password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Username = reader["Username"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public DataTable GetAllUsers()
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Username, Role FROM users";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool UpdateUser(User user)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "UPDATE users SET Username=@Username, Role=@Role WHERE Id=@Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM users WHERE Id=@Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", userId);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}