// Project/Repositories/CartRepository.cs
using MySql.Data.MySqlClient;
using Project.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project.Repositories
{
    public class CartRepository
    {
        private readonly DatabaseConnection _dbConn;

        public CartRepository(DatabaseConnection dbConn)
        {
            _dbConn = dbConn;
        }

        public bool AddToCart(int userId, int produkId, int jumlah)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string checkQuery = "SELECT Id, Jumlah FROM keranjang WHERE UserId = @UserId AND ProdukId = @ProdukId";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@UserId", userId);
                checkCmd.Parameters.AddWithValue("@ProdukId", produkId);

                using (MySqlDataReader reader = checkCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int existingCartItemId = Convert.ToInt32(reader["Id"]);
                        reader.Close();

                        string updateQuery = "UPDATE keranjang SET Jumlah = Jumlah + @JumlahBaru WHERE Id = @Id";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@JumlahBaru", jumlah);
                        updateCmd.Parameters.AddWithValue("@Id", existingCartItemId);
                        return updateCmd.ExecuteNonQuery() > 0;
                    }
                    else
                    {
                        reader.Close();

                        string insertQuery = "INSERT INTO keranjang (UserId, ProdukId, Jumlah, TanggalDitambahkan) VALUES (@UserId, @ProdukId, @Jumlah, @TanggalDitambahkan)";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@UserId", userId);
                        insertCmd.Parameters.AddWithValue("@ProdukId", produkId);
                        insertCmd.Parameters.AddWithValue("@Jumlah", jumlah);
                        insertCmd.Parameters.AddWithValue("@TanggalDitambahkan", DateTime.Now);
                        return insertCmd.ExecuteNonQuery() > 0;
                    }
                }
            }
        }

        public List<CartItem> GetCartItemsByUserId(int userId)
        {
            List<CartItem> cartItems = new List<CartItem>();
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT
                        k.Id, k.UserId, k.ProdukId, k.Jumlah, k.TanggalDitambahkan,
                        p.Nama AS NamaProduk, p.Harga AS HargaProduk, p.Gambar AS GambarProduk, p.Stok AS StokProduk
                    FROM
                        keranjang k
                    JOIN
                        produk p ON k.ProdukId = p.Id
                    WHERE
                        k.UserId = @UserId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cartItems.Add(new CartItem
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            ProdukId = Convert.ToInt32(reader["ProdukId"]),
                            Jumlah = Convert.ToInt32(reader["Jumlah"]),
                            TanggalDitambahkan = Convert.ToDateTime(reader["TanggalDitambahkan"]),
                            NamaProduk = reader["NamaProduk"].ToString(),
                            HargaProduk = Convert.ToDecimal(reader["HargaProduk"]),
                            GambarProduk = reader["GambarProduk"]?.ToString(),
                            StokProduk = Convert.ToInt32(reader["StokProduk"]) // <<<< PERUBAHAN INI (Mengambil StokProduk)
                        });
                    }
                }
            }
            return cartItems;
        }

        public bool RemoveCartItem(int cartItemId)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM keranjang WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", cartItemId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ClearCart(int userId, MySqlConnection conn, MySqlTransaction transaction)
        {
            string query = "DELETE FROM keranjang WHERE UserId = @UserId";
            MySqlCommand cmd = new MySqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@UserId", userId);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool ClearCart(int userId)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                return ClearCart(userId, conn, null);
            }
        }
    }
}