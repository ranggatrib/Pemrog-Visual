using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Diperlukan untuk MySqlException
using Project.Data;
using Project.Core; // Diperlukan untuk SessionManager (meskipun tidak langsung digunakan di sini, tetapi relevan untuk konteks admin)
using Project.Repositories; // Diperlukan untuk TransactionRepository
using Project.Forms; // Penting: Diperlukan untuk memanggil Form lain di namespace yang sama

namespace Project.Forms // Penting: Namespace untuk form ini
{
    public partial class FormAdminTransactions : Form
    {
        private TransactionRepository _transactionRepository; // Deklarasi instance TransactionRepository

        public FormAdminTransactions()
        {
            InitializeComponent(); // Menginisialisasi komponen UI
            _transactionRepository = new TransactionRepository(new DatabaseConnection()); // Menginisialisasi TransactionRepository dengan koneksi database baru
            cmbStatus.SelectedIndex = 0; // Mengatur pilihan default ComboBox status ke item pertama ("Pending")
        }

        private void FormAdminTransactions_Load(object sender, EventArgs e)
        {
            LoadAllTransactions(); // Memuat semua data transaksi saat form dimuat
        }

        /// <summary>
        /// Memuat semua data transaksi dari database ke DataGridView.
        /// </summary>
        private void LoadAllTransactions()
        {
            try
            {
                dgvTransactions.DataSource = _transactionRepository.GetAllTransactions(); // Mengatur sumber data DataGridView dari repository
                dgvTransactions.ClearSelection(); // Menghapus seleksi baris yang ada di DataGridView untuk tampilan bersih
            }
            catch (MySqlException ex) // Menangani kesalahan spesifik yang terkait dengan database MySQL
            {
                MessageBox.Show("Kesalahan Database saat memuat semua transaksi: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Menangani kesalahan tak terduga lainnya
            {
                MessageBox.Show("Gagal memuat semua transaksi: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Menangani klik sel di DataGridView untuk mengisi ComboBox status dengan status baris yang dipilih.
        /// </summary>
        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Memastikan klik dilakukan pada baris yang valid (bukan header atau area kosong)
            {
                DataGridViewRow row = dgvTransactions.Rows[e.RowIndex]; // Mengambil objek baris dari DataGridView
                // Mengambil nilai status dari sel dengan nama kolom "Status"
                string currentStatus = row.Cells["Status"].Value.ToString();
                cmbStatus.SelectedItem = currentStatus; // Menetapkan nilai status saat ini ke ComboBox untuk diedit
            }
        }

        /// <summary>
        /// Menangani klik tombol "Update Status" untuk mengubah status transaksi yang dipilih di database.
        /// </summary>
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count > 0) // Memastikan setidaknya ada satu baris yang dipilih
            {
                // Mengambil TransactionId dari sel pertama baris yang dipilih
                int transactionId = Convert.ToInt32(dgvTransactions.SelectedRows[0].Cells["TransactionId"].Value);
                // Mengambil status baru dari item yang dipilih di ComboBox
                string newStatus = cmbStatus.SelectedItem?.ToString();

                // Validasi: memastikan status baru tidak kosong
                if (string.IsNullOrEmpty(newStatus))
                {
                    MessageBox.Show("Silakan pilih status baru.", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Konfirmasi pengguna sebelum melakukan pembaruan status
                if (MessageBox.Show($"Apakah Anda yakin ingin memperbarui status Transaksi ID {transactionId} menjadi '{newStatus}'?", "Konfirmasi Pembaruan",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // Memanggil metode UpdateTransactionStatus dari repository untuk memperbarui data di database
                        bool success = _transactionRepository.UpdateTransactionStatus(transactionId, newStatus);
                        if (success)
                        {
                            MessageBox.Show("Status transaksi berhasil diperbarui!", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAllTransactions(); // Memuat ulang data untuk menampilkan status yang diperbarui di DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Gagal memperbarui status transaksi.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (MySqlException ex) // Menangani kesalahan spesifik yang terkait dengan database MySQL
                    {
                        MessageBox.Show("Kesalahan Database saat memperbarui status: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex) // Menangani kesalahan tak terduga lainnya
                    {
                        MessageBox.Show("Gagal memperbarui status: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else // Jika tidak ada baris yang dipilih
            {
                MessageBox.Show("Silakan pilih transaksi untuk diperbarui.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Menangani klik tombol "Back to Dashboard" untuk kembali ke form dashboard admin.
        /// </summary>
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            this.Hide(); // Menyembunyikan form transaksi saat ini
            FormAdminDashboard dashboardForm = new FormAdminDashboard(); // Membuat instance FormAdminDashboard
            dashboardForm.Show(); // Menampilkan Dashboard Admin
        }
    }
}