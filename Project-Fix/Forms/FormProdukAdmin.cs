using System;
using System.Data;
using System.IO; // Diperlukan untuk Path.Combine, File.Exists
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Diperlukan untuk MySqlException
using Project.Data; // Diperlukan untuk model Product
using Project.Repositories; // Diperlukan untuk ProductRepository
using Project.Core; // Diperlukan untuk SessionManager (jika ingin menambah tombol logout di sini juga)
using Project.Forms; // Penting: Diperlukan untuk memanggil Form lain di namespace yang sama

namespace Project.Forms // Penting: Namespace untuk form ini
{
    public partial class FormProdukAdmin : Form
    {
        private ProductRepository _productRepository; // Instance dari ProductRepository
        private Product currentProduct = new Product(); // Objek untuk menyimpan produk yang sedang dipilih

        public FormProdukAdmin()
        {
            InitializeComponent(); // Menginisialisasi komponen UI dari Designer.cs
            _productRepository = new ProductRepository(new DatabaseConnection()); // Inisialisasi repository
            LoadData(); // Memuat data produk saat form pertama kali dibuka
            ClearFields(); // Membersihkan field input
        }

        private void FormProdukAdmin_Load(object sender, EventArgs e)
        {
            // Event ini dipicu saat form dimuat. Juga digunakan untuk tombol "Refresh Data".
            LoadData();
            ClearFields();
        }

        /// <summary>
        /// Memuat semua data produk dari database ke DataGridView.
        /// </summary>
        private void LoadData()
        {
            try
            {
                dgvProduk.DataSource = _productRepository.GetAllProducts(); // Mengatur sumber data DataGridView
                dgvProduk.ClearSelection(); // Menghapus seleksi baris yang ada
            }
            catch (MySqlException ex) // Menangani kesalahan spesifik yang terkait dengan database MySQL
            {
                MessageBox.Show("Kesalahan Database: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Menangani kesalahan tak terduga lainnya
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Menangani klik sel di DataGridView untuk mengisi field input dengan detail produk yang dipilih.
        /// </summary>
        private void dgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Memastikan klik dilakukan pada baris yang valid (bukan header)
            {
                DataGridViewRow row = dgvProduk.Rows[e.RowIndex]; // Mengambil objek baris yang diklik

                // Mengisi objek currentProduct dengan data dari baris yang dipilih
                currentProduct = new Product
                {
                    Id = Convert.ToInt32(row.Cells["Id"].Value),
                    Nama = row.Cells["Nama"].Value.ToString(),
                    Deskripsi = row.Cells["Deskripsi"].Value.ToString(),
                    Harga = Convert.ToDecimal(row.Cells["Harga"].Value),
                    Stok = Convert.ToInt32(row.Cells["Stok"].Value),
                    Gambar = row.Cells["Gambar"].Value?.ToString() // Menggunakan operator null-conditional untuk Gambar
                };

                // Mengisi field form dengan data produk yang dipilih
                txtId.Text = currentProduct.Id.ToString();
                txtNama.Text = currentProduct.Nama;
                txtDeskripsi.Text = currentProduct.Deskripsi;
                txtHarga.Text = currentProduct.Harga.ToString();
                txtStok.Text = currentProduct.Stok.ToString();

                // Menampilkan gambar jika path gambar valid dan file ada
                if (!string.IsNullOrEmpty(currentProduct.Gambar))
                {
                    // Membuat path absolut untuk gambar
                    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, currentProduct.Gambar);
                    if (File.Exists(imagePath))
                    {
                        pbGambar.ImageLocation = imagePath;
                    }
                    else
                    {
                        pbGambar.Image = null; // Menghapus gambar jika file tidak ditemukan
                    }
                }
                else
                {
                    pbGambar.Image = null; // Menghapus gambar jika tidak ada path gambar
                }
            }
        }

        /// <summary>
        /// Menangani klik tombol "Create" untuk menambahkan produk baru ke database.
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Validasi input: memastikan semua field informasi produk terisi
            if (string.IsNullOrEmpty(txtNama.Text) || string.IsNullOrEmpty(txtDeskripsi.Text) ||
                string.IsNullOrEmpty(txtHarga.Text) || string.IsNullOrEmpty(txtStok.Text))
            {
                MessageBox.Show("Harap isi semua field informasi produk.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi: memastikan gambar sudah dipilih
            if (string.IsNullOrEmpty(pbGambar.ImageLocation))
            {
                MessageBox.Show("Harap pilih gambar terlebih dahulu.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal harga;
                int stok;
                // Validasi input harga
                if (!decimal.TryParse(txtHarga.Text, out harga) || harga < 0)
                {
                    MessageBox.Show("Harga tidak valid. Harap masukkan angka positif.", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validasi input stok
                if (!int.TryParse(txtStok.Text, out stok) || stok < 0)
                {
                    MessageBox.Show("Stok tidak valid. Harap masukkan bilangan bulat non-negatif.", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Memastikan direktori 'img' ada di direktori dasar aplikasi
                string imageDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img");
                Directory.CreateDirectory(imageDir); // Membuat direktori jika belum ada

                string fileName = Path.GetFileName(pbGambar.ImageLocation); // Mengambil nama file dari path lengkap
                string destinationPath = Path.Combine(imageDir, fileName); // Membuat path tujuan di folder 'img'

                // Menyalin gambar ke folder 'img' jika baru atau diperbarui
                if (!File.Exists(destinationPath) || new FileInfo(pbGambar.ImageLocation).LastWriteTime > new FileInfo(destinationPath).LastWriteTime)
                {
                    File.Copy(pbGambar.ImageLocation, destinationPath, true); // true untuk menimpa jika sudah ada
                }

                // Membuat objek Product baru
                Product newProduct = new Product
                {
                    Nama = txtNama.Text,
                    Deskripsi = txtDeskripsi.Text,
                    Harga = harga,
                    Stok = stok,
                    Gambar = "img/" + fileName // Menyimpan path relatif di database
                };

                // Menambahkan produk menggunakan repository
                _productRepository.AddProduct(newProduct);

                MessageBox.Show("Produk berhasil ditambahkan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Memuat ulang DataGridView
                ClearFields(); // Membersihkan field input
            }
            catch (MySqlException ex) // Menangani kesalahan spesifik database MySQL
            {
                MessageBox.Show("Kesalahan Database saat menambahkan produk: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Menangani kesalahan tak terduga lainnya
            {
                MessageBox.Show("Gagal menambahkan produk: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Menangani klik tombol "Update" untuk memodifikasi produk yang sudah ada di database.
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validasi: memastikan produk dipilih untuk diupdate
            if (currentProduct == null || currentProduct.Id == 0)
            {
                MessageBox.Show("Harap pilih produk untuk diperbarui.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi input: memastikan semua field informasi produk terisi
            if (string.IsNullOrEmpty(txtNama.Text) || string.IsNullOrEmpty(txtDeskripsi.Text) ||
                string.IsNullOrEmpty(txtHarga.Text) || string.IsNullOrEmpty(txtStok.Text))
            {
                MessageBox.Show("Harap isi semua field informasi produk.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal harga;
                int stok;
                // Validasi input harga
                if (!decimal.TryParse(txtHarga.Text, out harga) || harga < 0)
                {
                    MessageBox.Show("Harga tidak valid. Harap masukkan angka positif.", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validasi input stok
                if (!int.TryParse(txtStok.Text, out stok) || stok < 0)
                {
                    MessageBox.Show("Stok tidak valid. Harap masukkan bilangan bulat non-negatif.", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Memperbarui properti objek currentProduct dengan nilai dari field form
                currentProduct.Nama = txtNama.Text;
                currentProduct.Deskripsi = txtDeskripsi.Text;
                currentProduct.Harga = harga;
                currentProduct.Stok = stok;

                // Memperbarui produk menggunakan repository
                _productRepository.UpdateProduct(currentProduct);

                MessageBox.Show("Produk berhasil diperbarui!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Memuat ulang DataGridView
                ClearFields(); // Membersihkan field input
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Kesalahan Database saat memperbarui produk: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memperbarui produk: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Menangani klik tombol "Delete" untuk menghapus produk dari database.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Validasi: memastikan produk dipilih untuk dihapus
            if (currentProduct == null || currentProduct.Id == 0)
            {
                MessageBox.Show("Harap pilih produk untuk dihapus.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Konfirmasi pengguna sebelum menghapus
            if (MessageBox.Show("Apakah Anda yakin ingin menghapus produk ini?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Menghapus produk menggunakan repository
                    _productRepository.DeleteProduct(currentProduct.Id);

                    MessageBox.Show("Produk berhasil dihapus!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Memuat ulang DataGridView
                    ClearFields(); // Membersihkan field input
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Kesalahan Database saat menghapus produk: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus produk: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Menangani klik tombol "Browse" untuk memilih file gambar dari sistem.
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "File Gambar|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Mengatur filter file hanya untuk gambar
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // Jika pengguna memilih file dan klik OK
            {
                pbGambar.ImageLocation = openFileDialog1.FileName; // Menetapkan path file yang dipilih ke PictureBox
            }
        }

        /// <summary>
        /// Membersihkan semua field input pada form dan mereset pilihan produk.
        /// </summary>
        private void ClearFields()
        {
            txtId.Text = "";
            txtNama.Text = "";
            txtDeskripsi.Text = "";
            txtHarga.Text = "";
            txtStok.Text = "";
            pbGambar.ImageLocation = null; // Menghapus path gambar dari PictureBox
            pbGambar.Image = null; // Menghapus gambar yang ditampilkan di PictureBox
            currentProduct = new Product(); // Mereset objek produk yang sedang dipilih
        }

        /// <summary>
        /// Menangani klik tombol "Back to Dashboard" untuk kembali ke form dashboard admin.
        /// </summary>
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            this.Hide(); // Menyembunyikan form saat ini
            FormAdminDashboard dashboardForm = new FormAdminDashboard(); // Membuat instance FormAdminDashboard
            dashboardForm.Show(); // Menampilkan FormAdminDashboard
        }
    }
}