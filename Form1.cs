using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Project
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=bawangmerahdb;password=;");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MessageBox.Show("Koneksi ke database berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();

                LoadData(); // Lanjutkan untuk memuat data jika koneksi berhasil
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal terkoneksi ke database!\n\n" + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Tutup aplikasi jika tidak bisa terhubung
            }
        }
        void LoadData()
        {
            string query = "SELECT * FROM produk";
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvProduk.DataSource = dt;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string path = Path.GetFileName(pbGambar.ImageLocation);

            // Buat folder img jika belum ada
            Directory.CreateDirectory("img");

            // Salin gambar ke folder img
            File.Copy(pbGambar.ImageLocation, Path.Combine("img", path), true);

            string query = "INSERT INTO produk (Nama, Deskripsi, Harga, Gambar) VALUES (@Nama, @Deskripsi, @Harga, @Gambar)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
            cmd.Parameters.AddWithValue("@Deskripsi", txtDeskripsi.Text);
            cmd.Parameters.AddWithValue("@Harga", txtHarga.Text);
            cmd.Parameters.AddWithValue("@Gambar", "img/" + path);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "UPDATE produk SET Nama=@Nama, Deskripsi=@Deskripsi, Harga=@Harga WHERE Id=@Id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
            cmd.Parameters.AddWithValue("@Deskripsi", txtDeskripsi.Text);
            cmd.Parameters.AddWithValue("@Harga", txtHarga.Text);
            cmd.Parameters.AddWithValue("@Id", txtId.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM produk WHERE Id=@Id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", txtId.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            LoadData();
        }

        private void dgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduk.Rows[e.RowIndex];
                txtId.Text = row.Cells["Id"].Value.ToString();
                txtNama.Text = row.Cells["Nama"].Value.ToString();
                txtDeskripsi.Text = row.Cells["Deskripsi"].Value.ToString();
                txtHarga.Text = row.Cells["Harga"].Value.ToString();
                pbGambar.ImageLocation = row.Cells["Gambar"].Value.ToString();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbGambar.ImageLocation = openFileDialog1.FileName;
            }
        }
    }
}
