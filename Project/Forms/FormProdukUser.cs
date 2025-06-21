using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Data;
using Project.Core;
using Project.Repositories;
using Project.Forms;

namespace Project.Forms
{
    public partial class FormProdukUser : Form
    {
        private ProductRepository _productRepository;
        private TransactionRepository _transactionRepository;
        private CartRepository _cartRepository;
        private Product selectedProduct = new Product();

        public FormProdukUser()
        {
            InitializeComponent();
            _productRepository = new ProductRepository(new DatabaseConnection());
            _transactionRepository = new TransactionRepository(new DatabaseConnection());
            _cartRepository = new CartRepository(new DatabaseConnection());
            LoadData();
            ClearSelection();
        }

        private void LoadData()
        {
            try
            {
                dgvProduk.DataSource = _productRepository.GetAllProducts();
                dgvProduk.ClearSelection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduk.Rows[e.RowIndex];

                selectedProduct = new Product
                {
                    Id = Convert.ToInt32(row.Cells["Id"].Value),
                    Nama = row.Cells["Nama"].Value.ToString(),
                    Deskripsi = row.Cells["Deskripsi"].Value.ToString(),
                    Harga = Convert.ToDecimal(row.Cells["Harga"].Value),
                    Stok = Convert.ToInt32(row.Cells["Stok"].Value),
                    Gambar = row.Cells["Gambar"].Value?.ToString()
                };

                txtNama.Text = selectedProduct.Nama;
                txtDeskripsi.Text = selectedProduct.Deskripsi;
                txtHarga.Text = selectedProduct.Harga.ToString("C");
                txtStok.Text = selectedProduct.Stok.ToString();

                numJumlah.Maximum = selectedProduct.Stok > 0 ? selectedProduct.Stok : 1;
                numJumlah.Minimum = 1;
                numJumlah.Value = 1;

                if (!string.IsNullOrEmpty(selectedProduct.Gambar))
                {
                    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, selectedProduct.Gambar);
                    if (File.Exists(imagePath))
                    {
                        pbGambar.ImageLocation = imagePath;
                    }
                    else
                    {
                        pbGambar.Image = null;
                    }
                }
                else
                {
                    pbGambar.Image = null;
                }
            }
        }

        private void btnBeli_Click(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.IsLoggedIn)
            {
                MessageBox.Show("Please log in to make a purchase!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedProduct == null || selectedProduct.Id == 0)
            {
                MessageBox.Show("Please select a product first!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)numJumlah.Value;

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quantity > selectedProduct.Stok)
            {
                MessageBox.Show($"Quantity exceeds available stock! Available: {selectedProduct.Stok}",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            _productRepository.UpdateProductStock(selectedProduct.Id, -quantity, conn, transaction);

                            Transaction newTransaction = new Transaction
                            {
                                ProdukId = selectedProduct.Id,
                                Jumlah = quantity,
                                Tanggal = DateTime.Now,
                                UserId = SessionManager.Instance.CurrentUser.Id,
                                Status = "Pending"
                            };
                            _transactionRepository.AddTransaction(newTransaction, conn, transaction);

                            transaction.Commit();

                            MessageBox.Show($"Successfully purchased {quantity} item(s)!\n" +
                                          $"Remaining stock: {selectedProduct.Stok - quantity}",
                                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadData();
                            ClearSelection();
                        }
                        catch (Exception innerEx)
                        {
                            transaction.Rollback();
                            throw innerEx;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error during purchase: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Purchase failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Instance.LogoutUser();
            this.Hide();
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
        }

        private void ClearSelection()
        {
            selectedProduct = new Product();
            txtNama.Text = "";
            txtDeskripsi.Text = "";
            txtHarga.Text = "";
            txtStok.Text = "";
            pbGambar.Image = null;
            numJumlah.Value = 1;
            numJumlah.Maximum = 1;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.IsLoggedIn)
            {
                MessageBox.Show("Please log in to add items to your cart!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (selectedProduct == null || selectedProduct.Id == 0)
            {
                MessageBox.Show("Please select a product first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)numJumlah.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (quantity > selectedProduct.Stok)
            {
                MessageBox.Show($"Quantity exceeds available stock! Available: {selectedProduct.Stok}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool success = _cartRepository.AddToCart(SessionManager.Instance.CurrentUser.Id, selectedProduct.Id, quantity);
                if (success)
                {
                    MessageBox.Show($"{quantity} of {selectedProduct.Nama} added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearSelection();
                }
                else
                {
                    MessageBox.Show("Failed to add item to cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error adding to cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add item to cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewCart_Click(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.IsLoggedIn)
            {
                MessageBox.Show("Please log in to view your cart!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormCart cartForm = new FormCart();
            cartForm.ShowDialog();
            LoadData();
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.IsLoggedIn)
            {
                MessageBox.Show("Please log in to view your orders!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormUserOrders userOrdersForm = new FormUserOrders();
            userOrdersForm.ShowDialog();
        }
    }
}