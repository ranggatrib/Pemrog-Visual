using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; 
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Core;
using Project.Data;
using Project.Forms; 
using Project.Repositories;

namespace Project.Controllers
{
    public class CartController
    {
        private ICartView _view;
        private CartRepository _cartRepository;
        private ProductRepository _productRepository;
        private TransactionRepository _transactionRepository; // Diperlukan untuk proses checkout

        private List<CartItem> _currentCartItems; // State internal untuk item keranjang

        public CartController(ICartView view, CartRepository cartRepository, ProductRepository productRepository, TransactionRepository transactionRepository)
        {
            _view = view;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _transactionRepository = transactionRepository;

            // Langganan event dari View
            _view.LoadView += OnLoadView;
            _view.RemoveItemButtonClick += OnRemoveItemButtonClick;
            _view.CheckoutButtonClick += OnCheckoutButtonClick;
        }

        // --- Event Handlers dari View yang ditangani oleh Controller ---
        private void OnLoadView(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        private void OnRemoveItemButtonClick(object sender, EventArgs e)
        {
            if (_view.SelectedCartItemId == 0) // Jika tidak ada item yang dipilih
            {
                _view.ShowMessage("Silakan pilih item untuk dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_view.ShowMessage("Anda yakin ingin menghapus item ini dari keranjang Anda?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool success = _cartRepository.RemoveCartItem(_view.SelectedCartItemId);
                    if (success)
                    {
                        _view.ShowMessage("Item berhasil dihapus dari keranjang.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCartItems(); // Muat ulang keranjang setelah dihapus
                    }
                    else
                    {
                        _view.ShowMessage("Gagal menghapus item dari keranjang.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    _view.ShowMessage("Kesalahan Database saat menghapus item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    _view.ShowMessage("Gagal menghapus item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnCheckoutButtonClick(object sender, EventArgs e)
        {
            if (_currentCartItems == null || _currentCartItems.Count == 0)
            {
                _view.ShowMessage("Keranjang Anda kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi stok sebelum melanjutkan ke pengiriman/pembayaran
            foreach (var item in _currentCartItems)
            {
                Product productInDb = _productRepository.GetProductById(item.ProdukId);
                if (productInDb == null || productInDb.Stok < item.Jumlah)
                {
                    _view.ShowMessage($"Stok tidak cukup untuk '{item.NamaProduk}'. Tersedia: {productInDb?.Stok ?? 0}", "Checkout Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadCartItems(); // Muat ulang keranjang jika stok tidak valid
                    return;
                }
            }

            decimal grandTotal = _currentCartItems.Sum(item => item.Jumlah * item.HargaProduk);

            // Memanggil FormShippingDetails
            string namaPenerima = "";
            string alamatPengiriman = "";
            string nomorTeleponPenerima = "";
            DialogResult shippingResult = _view.ShowShippingDetailsForm(out namaPenerima, out alamatPengiriman, out nomorTeleponPenerima);

            if (shippingResult == DialogResult.OK)
            {
                // Memanggil FormPayment
                DialogResult paymentResult = _view.ShowPaymentForm(grandTotal, _currentCartItems, namaPenerima, alamatPengiriman, nomorTeleponPenerima);

                if (paymentResult == DialogResult.OK)
                {
                    // Setelah pembayaran berhasil, keranjang di database sudah dibersihkan oleh FormPayment
                    _view.ShowMessage("Pesanan berhasil diproses dan dibayar!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCartItems(); // Muat ulang keranjang (seharusnya kosong sekarang)
                    _view.CloseView(); // Tutup Form Keranjang
                }
                else if (paymentResult == DialogResult.Cancel)
                {
                    _view.ShowMessage("Pembayaran dibatalkan oleh pengguna. Keranjang Anda tetap utuh.", "Pembayaran Dibatalkan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // DialogResult.Abort atau kegagalan lain dari FormPayment
                {
                    _view.ShowMessage("Proses pembayaran gagal. Harap periksa keranjang Anda dan coba lagi.", "Kesalahan Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (shippingResult == DialogResult.Cancel)
            {
                _view.ShowMessage("Detail pengiriman dibatalkan. Checkout dibatalkan.", "Checkout Dibatalkan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadCartItems(); // Selalu muat ulang item keranjang jika ada perubahan atau pembatalan
        }


        // --- Metode Internal yang Digunakan oleh Controller ---

        private void LoadCartItems()
        {
            if (SessionManager.Instance.CurrentUser == null)
            {
                _view.ShowMessage("Harap login untuk melihat keranjang Anda!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _view.CloseView();
                return;
            }

            try
            {
                _currentCartItems = _cartRepository.GetCartItemsByUserId(SessionManager.Instance.CurrentUser.Id);

                DataTable dt = new DataTable();
                dt.Columns.Add("CartItemId", typeof(int));
                dt.Columns.Add("Product ID", typeof(int));
                dt.Columns.Add("Product Name", typeof(string));
                dt.Columns.Add("Price per Unit", typeof(decimal));
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("Subtotal", typeof(decimal));

                decimal grandTotal = 0;

                foreach (var item in _currentCartItems)
                {
                    decimal subtotal = item.Jumlah * item.HargaProduk;
                    grandTotal += subtotal;
                    dt.Rows.Add(item.Id, item.ProdukId, item.NamaProduk, item.HargaProduk, item.Jumlah, subtotal);
                }

                _view.DisplayCartItems(dt);
                
                _view.GrandTotalText = $"Total: {grandTotal:C}";

                // Atur status tombol berdasarkan isi keranjang
                if (_currentCartItems.Count == 0)
                {
                    _view.CheckoutButtonEnabled = false;
                    _view.RemoveItemButtonEnabled = false;
                }
                else
                {
                    _view.CheckoutButtonEnabled = true;
                    _view.RemoveItemButtonEnabled = true;
                }
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database saat memuat keranjang: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Gagal memuat item keranjang: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}