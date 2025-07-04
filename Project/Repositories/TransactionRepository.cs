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

        public void AddTransaction(Transaction transaction, MySqlConnection conn, MySqlTransaction trans)
        {
            string query = @"INSERT INTO transaksi (ProdukId, Jumlah, Tanggal, UserId, Status, MetodePembayaran, NamaPenerima, AlamatPengiriman, NomorTeleponPenerima, BuktiTransferPath)
                             VALUES (@ProdukId, @Jumlah, @Tanggal, @UserId, @Status, @MetodePembayaran, @NamaPenerima, @AlamatPengiriman, @NomorTeleponPenerima, @BuktiTransferPath)";

            using (MySqlCommand cmd = new MySqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@ProdukId", transaction.ProdukId);
                cmd.Parameters.AddWithValue("@Jumlah", transaction.Jumlah);
                cmd.Parameters.AddWithValue("@Tanggal", transaction.Tanggal);
                cmd.Parameters.AddWithValue("@UserId", transaction.UserId);
                cmd.Parameters.AddWithValue("@Status", transaction.Status);
                cmd.Parameters.AddWithValue("@MetodePembayaran", transaction.MetodePembayaran ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NamaPenerima", transaction.NamaPenerima ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@AlamatPengiriman", transaction.AlamatPengiriman ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NomorTeleponPenerima", transaction.NomorTeleponPenerima ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@BuktiTransferPath", transaction.BuktiTransferPath ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public bool AddTransaction(Transaction transaction)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO transaksi (ProdukId, Jumlah, Tanggal, UserId, Status, MetodePembayaran, NamaPenerima, AlamatPengiriman, NomorTeleponPenerima, BuktiTransferPath)
                                 VALUES (@ProdukId, @Jumlah, @Tanggal, @UserId, @Status, @MetodePembayaran, @NamaPenerima, @AlamatPengiriman, @NomorTeleponPenerima, @BuktiTransferPath)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProdukId", transaction.ProdukId);
                cmd.Parameters.AddWithValue("@Jumlah", transaction.Jumlah);
                cmd.Parameters.AddWithValue("@Tanggal", transaction.Tanggal);
                cmd.Parameters.AddWithValue("@UserId", transaction.UserId);
                cmd.Parameters.AddWithValue("@Status", transaction.Status);
                cmd.Parameters.AddWithValue("@MetodePembayaran", transaction.MetodePembayaran ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NamaPenerima", transaction.NamaPenerima ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@AlamatPengiriman", transaction.AlamatPengiriman ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NomorTeleponPenerima", transaction.NomorTeleponPenerima ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@BuktiTransferPath", transaction.BuktiTransferPath ?? (object)DBNull.Value);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public DataTable GetUserPurchaseHistory(int userId)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = @"SELECT
                                    t.Id,
                                    p.Nama AS ProductName,
                                    t.Jumlah AS Quantity,
                                    t.Tanggal AS TransactionDate,
                                    p.Harga AS PricePerUnit,
                                    (t.Jumlah * p.Harga) AS Subtotal,
                                    t.Status AS Status,
                                    t.MetodePembayaran,
                                    t.NamaPenerima,
                                    t.AlamatPengiriman,
                                    t.NomorTeleponPenerima,
                                    t.BuktiTransferPath
                                FROM
                                    transaksi t
                                JOIN
                                    produk p ON t.ProdukId = p.Id
                                WHERE
                                    t.UserId = @userId
                                ORDER BY
                                    t.Tanggal DESC";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@userId", userId);
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
                string query = @"SELECT
                                    t.Id AS TransactionId,
                                    u.Username AS UserName,
                                    p.Nama AS ProductName,
                                    t.Jumlah AS Quantity,
                                    t.Tanggal AS TransactionDate,
                                    p.Harga AS PricePerUnit,
                                    (t.Jumlah * p.Harga) AS Subtotal,
                                    t.Status AS Status,
                                    t.MetodePembayaran,
                                    t.NamaPenerima,
                                    t.AlamatPengiriman,
                                    t.NomorTeleponPenerima,
                                    t.BuktiTransferPath
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
