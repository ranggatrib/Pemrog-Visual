using MySql.Data.MySqlClient;
using Project.Data;
using System;
using System.Data;

namespace Project.Repositories
{
    public class ProductRepository
    {
        private readonly DatabaseConnection _dbConn;

        public ProductRepository(DatabaseConnection dbConn)
        {
            _dbConn = dbConn;
        }

        public DataTable GetAllProducts()
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Nama, Deskripsi, Harga, Gambar, Stok FROM produk";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public Product GetProductById(int id)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Nama, Deskripsi, Harga, Gambar, Stok FROM produk WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nama = reader["Nama"].ToString(),
                            Deskripsi = reader["Deskripsi"].ToString(),
                            Harga = Convert.ToDecimal(reader["Harga"]),
                            Stok = Convert.ToInt32(reader["Stok"]),
                            Gambar = reader["Gambar"]?.ToString()
                        };
                    }
                }
            }
            return null;
        }

        public bool AddProduct(Product product)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO produk (Nama, Deskripsi, Harga, Gambar, Stok) VALUES (@Nama, @Deskripsi, @Harga, @Gambar, @Stok)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nama", product.Nama);
                cmd.Parameters.AddWithValue("@Deskripsi", product.Deskripsi);
                cmd.Parameters.AddWithValue("@Harga", product.Harga);
                cmd.Parameters.AddWithValue("@Gambar", product.Gambar);
                cmd.Parameters.AddWithValue("@Stok", product.Stok);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool UpdateProduct(Product product)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "UPDATE produk SET Nama=@Nama, Deskripsi=@Deskripsi, Harga=@Harga, Stok=@Stok WHERE Id=@Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nama", product.Nama);
                cmd.Parameters.AddWithValue("@Deskripsi", product.Deskripsi);
                cmd.Parameters.AddWithValue("@Harga", product.Harga);
                cmd.Parameters.AddWithValue("@Stok", product.Stok);
                cmd.Parameters.AddWithValue("@Id", product.Id);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool DeleteProduct(int id)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM produk WHERE Id=@Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // <<<< PERUBAHAN INI (Overload untuk transaksi)
        public bool UpdateProductStock(int productId, int quantityChange, MySqlConnection conn, MySqlTransaction transaction)
        {
            string query = "UPDATE produk SET Stok = Stok + @QuantityChange WHERE Id = @Id";
            MySqlCommand cmd = new MySqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@QuantityChange", quantityChange);
            cmd.Parameters.AddWithValue("@Id", productId);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        // Overload untuk update standalone (jika tidak dalam transaksi)
        public bool UpdateProductStock(int productId, int quantityChange)
        {
            using (var conn = _dbConn.GetConnection())
            {
                conn.Open();
                return UpdateProductStock(productId, quantityChange, conn, null);
            }
        }
    }
}