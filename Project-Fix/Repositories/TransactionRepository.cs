// Project/Repositories/TransactionRepository.cs
using MySql.Data.MySqlClient;
using Project.Data;
using System;
using System.Data;

namespace Project.Repositories
{
    public class TransactionRepository
    {
        private readonly DatabaseConnection _dbConn;

        public TransactionRepository(DatabaseConnection dbConn)
        {
            _dbConn = dbConn;
        }

        // <<<< PERUBAHAN INI (Overload untuk transaksi)
        public bool AddTransaction(Transaction transaction, MySqlConnection conn, MySqlTransaction sqlTransaction)
        {
            string query = "INSERT INTO transaksi (ProdukId, Jumlah, Tanggal, UserId, Status) VALUES (@ProdukId, @Jumlah, @Tanggal, @UserId, @Status)";
            MySqlCommand cmd = new MySqlCommand(query, conn, sqlTransaction);
            cmd.Parameters.AddWithValue("@ProdukId", transaction.ProdukId);
            cmd.Parameters.AddWithValue("@Jumlah", transaction.Jumlah);
            cmd.Parameters.AddWithValue("@Tanggal", transaction.Tanggal);
            cmd.Parameters.AddWithValue("@UserId", transaction.UserId);
            cmd.Parameters.AddWithValue("@Status", transaction.Status);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        // Overload untuk transaksi standalone (jika tidak dalam transaksi besar)
        public bool AddTransaction(Transaction transaction)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                return AddTransaction(transaction, conn, null);
            }
        }

        public DataTable GetUserPurchaseHistory(int userId)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT
                        t.Id AS TransactionId,
                        p.Nama AS ProductName,
                        t.Jumlah AS Quantity,
                        t.Tanggal AS TransactionDate,
                        p.Harga AS PricePerUnit,
                        t.Status AS Status,
                        (t.Jumlah * p.Harga) AS Subtotal
                    FROM
                        transaksi t
                    JOIN
                        produk p ON t.ProdukId = p.Id
                    WHERE
                        t.UserId = @UserId
                    ORDER BY
                        t.Tanggal DESC";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@UserId", userId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetAllTransactions()
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT
                        t.Id AS TransactionId,
                        u.Username AS UserName,
                        p.Nama AS ProductName,
                        t.Jumlah AS Quantity,
                        t.Tanggal AS TransactionDate,
                        p.Harga AS PricePerUnit,
                        t.Status AS Status,
                        (t.Jumlah * p.Harga) AS Subtotal
                    FROM
                        transaksi t
                    JOIN
                        produk p ON t.ProdukId = p.Id
                    JOIN
                        users u ON t.UserId = u.Id
                    ORDER BY
                        t.Tanggal DESC";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // <<<< PERUBAHAN INI (Update status transaksi)
        public bool UpdateTransactionStatus(int transactionId, string newStatus)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "UPDATE transaksi SET Status = @NewStatus WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NewStatus", newStatus);
                cmd.Parameters.AddWithValue("@Id", transactionId);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}