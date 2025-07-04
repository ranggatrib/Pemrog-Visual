using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Core;
using Project.Data;
using Project.Forms;
using Project.Repositories;
using System.Collections.Generic;

namespace Project.Controllers
{
    public class ProdukUserController
    {
        private IProdukUserView _view;
        private ProductRepository _productRepository;
        private TransactionRepository _transactionRepository;
        private CartRepository _cartRepository;

        private Product _selectedProduct;

        public ProdukUserController(IProdukUserView view, ProductRepository productRepository, TransactionRepository transactionRepository, CartRepository cartRepository)
        {
            _view = view;
            _productRepository = productRepository;
            _transactionRepository = transactionRepository;
            _cartRepository = cartRepository;

            _view.LoadView += OnLoadView;
            _view.ProductCellClick += OnProductCellClick;
            _view.BuyButtonClick += OnBuyButtonClick;
            _view.AddToCartButtonClick += OnAddToCartButtonClick;
            _view.ViewCartButtonClick += OnViewCartButtonClick;
            _view.MyOrdersButtonClick += OnMyOrdersButtonClick;
            _view.LogoutButtonClick += OnLogoutButtonClick;
        }

        private void OnLoadView(object sender, EventArgs e)
        {
            LoadProducts();
            ClearProductSelection();
        }

        private void OnProductCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dgvProduk = (DataGridView)sender;
                DataGridViewRow row = dgvProduk.Rows[e.RowIndex];

                _selectedProduct = new Product
                {
                    Id = Convert.ToInt32(row.Cells["Id"].Value),
                    Nama = row.Cells["Nama"].Value.ToString(),
                    Deskripsi = row.Cells["Deskripsi"].Value.ToString(),
                    Harga = Convert.ToDecimal(row.Cells["Harga"].Value),
                    Stok = Convert.ToInt32(row.Cells["Stok"].Value),
                    Gambar = row.Cells["Gambar"].Value?.ToString()
                };

                _view.ProductName = _selectedProduct.Nama;
                _view.ProductDescription = _selectedProduct.Deskripsi;
                _view.ProductPrice = _selectedProduct.Harga.ToString("C");
                _view.ProductStock = _selectedProduct.Stok.ToString();
                _view.MaxQuantity = _selectedProduct.Stok > 0 ? _selectedProduct.Stok : 1;

                if (!string.IsNullOrEmpty(_selectedProduct.Gambar))
                {
                    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _selectedProduct.Gambar);
                    if (File.Exists(imagePath))
                    {
                        _view.ProductImageLocation = imagePath;
                    }
                    else
                    {
                        _view.ProductImageLocation = null;
                    }
                }
                else
                {
                    _view.ProductImageLocation = null;
                }
            }
        }

        private void OnBuyButtonClick(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.IsLoggedIn)
            {
                _view.ShowMessage("Harap login untuk melakukan pembelian!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_selectedProduct == null || _selectedProduct.Id == 0)
            {
                _view.ShowMessage("Silakan pilih produk terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = _view.Quantity;

            if (quantity <= 0)
            {
                _view.ShowMessage("Jumlah harus lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quantity > _selectedProduct.Stok)
            {
                _view.ShowMessage($"Jumlah melebihi stok yang tersedia! Tersedia: {_selectedProduct.Stok}", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string namaPenerima = "";
            string alamatPengiriman = "";
            string nomorTeleponPenerima = "";
            DialogResult shippingResult = _view.ShowShippingDetailsForm(out namaPenerima, out alamatPengiriman, out nomorTeleponPenerima);

            if (shippingResult == DialogResult.OK)
            {
                decimal grandTotal = _selectedProduct.Harga * quantity;
                List<CartItem> singleItemCart = new List<CartItem>
                {
                    new CartItem
                    {
                        ProdukId = _selectedProduct.Id,
                        NamaProduk = _selectedProduct.Nama,
                        HargaProduk = _selectedProduct.Harga,
                        Jumlah = quantity
                    }
                };

                DialogResult paymentResult = _view.ShowPaymentForm(grandTotal, singleItemCart, namaPenerima, alamatPengiriman, nomorTeleponPenerima);

                if (paymentResult == DialogResult.OK)
                {
                    _view.ShowMessage("Pembelian berhasil diproses dan dibayar!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                    ClearProductSelection();
                }
                else if (paymentResult == DialogResult.Cancel)
                {
                    _view.ShowMessage("Pembayaran dibatalkan oleh pengguna. Produk tidak dibeli.", "Pembelian Dibatalkan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _view.ShowMessage("Proses pembayaran gagal. Harap periksa produk dan coba lagi.", "Kesalahan Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (shippingResult == DialogResult.Cancel)
            {
                _view.ShowMessage("Detail pengiriman dibatalkan. Pembelian dibatalkan.", "Pembelian Dibatalkan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadProducts();
            ClearProductSelection();
        }

        private void OnAddToCartButtonClick(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.IsLoggedIn)
            {
                _view.ShowMessage("Harap login untuk menambahkan item ke keranjang Anda!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_selectedProduct == null || _selectedProduct.Id == 0)
            {
                _view.ShowMessage("Silakan pilih produk terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = _view.Quantity;
            if (quantity <= 0)
            {
                _view.ShowMessage("Jumlah harus lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (quantity > _selectedProduct.Stok)
            {
                _view.ShowMessage($"Jumlah melebihi stok yang tersedia! Tersedia: {_selectedProduct.Stok}", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool success = _cartRepository.AddToCart(SessionManager.Instance.CurrentUser.Id, _selectedProduct.Id, quantity);
                if (success)
                {
                    _view.ShowMessage($"{quantity} dari {_selectedProduct.Nama} ditambahkan ke keranjang!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearProductSelection();
                }
                else
                {
                    _view.ShowMessage("Gagal menambahkan item ke keranjang.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database saat menambahkan ke keranjang: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Gagal menambahkan item ke keranjang: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnViewCartButtonClick(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.IsLoggedIn)
            {
                _view.ShowMessage("Harap login untuk melihat keranjang Anda!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _view.ShowCartForm();
            LoadProducts();
        }

        private void OnMyOrdersButtonClick(object sender, EventArgs e)
        {
            if (!SessionManager.Instance.IsLoggedIn)
            {
                _view.ShowMessage("Harap login untuk melihat pesanan Anda!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _view.ShowUserOrdersForm();
        }

        private void OnLogoutButtonClick(object sender, EventArgs e)
        {
            SessionManager.Instance.LogoutUser();
            _view.HideView();
            _view.ShowLoginForm();
        }

        private void LoadProducts()
        {
            try
            {
                _view.DisplayProducts(_productRepository.GetAllProducts());
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Gagal memuat data produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearProductSelection()
        {
            _selectedProduct = new Product();
            _view.ClearProductSelection();
        }
    }
}