using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Core;
using Project.Data;
using Project.Forms;
using Project.Repositories;
using System.IO;

namespace Project.Controllers
{
    public class PaymentController
    {
        private IPaymentView _view;
        private CartRepository _cartRepository;
        private ProductRepository _productRepository;
        private TransactionRepository _transactionRepository;

        private decimal _grandTotal;
        private List<CartItem> _cartItemsToProcess;
        private string _namaPenerima;
        private string _alamatPengiriman;
        private string _nomorTeleponPenerima;
        private string _buktiTransferPath;

        private const string ADMIN_REKENING = "123-456-7890 (Bank ABC)";

        public PaymentController(IPaymentView view, decimal grandTotal, List<CartItem> cartItemsToProcess, string namaPenerima, string alamatPengiriman, string nomorTeleponPenerima, CartRepository cartRepository, ProductRepository productRepository, TransactionRepository transactionRepository)
        {
            _view = view;
            _grandTotal = grandTotal;
            _cartItemsToProcess = cartItemsToProcess;
            _namaPenerima = namaPenerima;
            _alamatPengiriman = alamatPengiriman;
            _nomorTeleponPenerima = nomorTeleponPenerima;

            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _transactionRepository = transactionRepository;

            _view.LoadView += OnLoadView;
            _view.AmountPaidTextChanged += OnAmountPaidTextChanged;
            _view.PaymentMethodSelectedIndexChanged += OnPaymentMethodSelectedIndexChanged;
            _view.PayButtonClick += OnPayButtonClick;
            _view.CancelButtonClick += OnCancelButtonClick;
            _view.BrowseProofButtonClick += OnBrowseProofButtonClick;
        }

        private void OnLoadView(object sender, EventArgs e)
        {
            _view.GrandTotalLabel = $"Grand Total: {_grandTotal:C}";
            _view.ChangeLabel = "Change: Rp 0.00";
            _view.AmountPaidText = "0";
            _view.PaymentMethod = "Tunai";
            _view.AmountPaidText = _grandTotal.ToString();
            OnPaymentMethodSelectedIndexChanged(sender, e);
        }

        private void OnAmountPaidTextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void OnPaymentMethodSelectedIndexChanged(object sender, EventArgs e)
        {
            // PERBAIKAN DI SINI: Pastikan selectedMethod tidak null untuk perbandingan
            string selectedMethod = _view.PaymentMethod; // Ini akan selalu string non-null dari FormPayment yang diperbaiki

            if (selectedMethod == "Bank Transfer")
            {
                _view.BuktiTransferVisible = true;
                _view.BrowseProofVisible = true;
                _view.AmountPaidEnabled = false;
                _view.AmountPaidText = _grandTotal.ToString();
                _view.ChangeLabel = "Change: Rp 0.00";
                _view.ChangeLabelColor = Color.Black;

                _view.AdminRekeningText = $"No. Rekening Admin: {ADMIN_REKENING}";
                _view.AdminRekeningVisible = true;
            }
            else
            {
                _view.BuktiTransferVisible = false;
                _view.BrowseProofVisible = false;
                _view.AmountPaidEnabled = true;
                _view.AmountPaidText = "0";
                CalculateChange();

                _view.AdminRekeningVisible = false;
            }
        }

        private void OnPayButtonClick(object sender, EventArgs e)
        {
            if (!decimal.TryParse(_view.AmountPaidText, out decimal amountPaid))
            {
                _view.ShowMessage("Harap masukkan jumlah yang valid.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string paymentMethod = _view.PaymentMethod;
            if (string.IsNullOrEmpty(paymentMethod))
            {
                _view.ShowMessage("Harap pilih metode pembayaran.", "Metode Pembayaran Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (paymentMethod == "Tunai" && amountPaid < _grandTotal)
            {
                _view.ShowMessage("Jumlah yang dibayarkan tidak cukup. Harap bayar jumlah penuh.", "Pembayaran Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (paymentMethod == "Bank Transfer" && string.IsNullOrEmpty(_buktiTransferPath))
            {
                _view.ShowMessage("Harap unggah bukti transfer.", "Pembayaran Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string savedBuktiTransferPath = null;
            if (paymentMethod == "Bank Transfer" && !string.IsNullOrEmpty(_buktiTransferPath))
            {
                try
                {
                    string imageDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bukti_transfer");
                    Directory.CreateDirectory(imageDir);

                    string fileName = Path.GetFileName(_buktiTransferPath);
                    savedBuktiTransferPath = Path.Combine(imageDir, fileName);

                    if (!File.Exists(savedBuktiTransferPath) || File.GetLastWriteTime(_buktiTransferPath) > File.GetLastWriteTime(savedBuktiTransferPath))
                    {
                        File.Copy(_buktiTransferPath, savedBuktiTransferPath, true);
                        savedBuktiTransferPath = "bukti_transfer/" + fileName;
                    }
                    else
                    {
                        savedBuktiTransferPath = "bukti_transfer/" + fileName;
                    }
                }
                catch (Exception ex)
                {
                    _view.ShowMessage($"Gagal menyimpan bukti transfer: {ex.Message}", "Kesalahan Penyimpanan File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            using (var conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in _cartItemsToProcess)
                        {
                            Product productInDb = _productRepository.GetProductById(item.ProdukId);
                            if (productInDb == null || productInDb.Stok < item.Jumlah)
                            {
                                throw new Exception($"Stok tidak cukup untuk '{item.NamaProduk}'. Tersedia: {productInDb?.Stok ?? 0}");
                            }
                        }

                        foreach (var item in _cartItemsToProcess)
                        {
                            _productRepository.UpdateProductStock(item.ProdukId, -item.Jumlah, conn, transaction);

                            Transaction newTransaction = new Transaction
                            {
                                ProdukId = item.ProdukId,
                                Jumlah = item.Jumlah,
                                Tanggal = DateTime.Now,
                                UserId = SessionManager.Instance.CurrentUser.Id,
                                Status = (paymentMethod == "Tunai") ? "Selesai" : "Menunggu Konfirmasi",
                                MetodePembayaran = paymentMethod,
                                NamaPenerima = _namaPenerima,
                                AlamatPengiriman = _alamatPengiriman,
                                NomorTeleponPenerima = _nomorTeleponPenerima,
                                BuktiTransferPath = savedBuktiTransferPath
                            };
                            _transactionRepository.AddTransaction(newTransaction, conn, transaction);
                        }

                        _cartRepository.ClearCart(SessionManager.Instance.CurrentUser.Id, conn, transaction);

                        transaction.Commit();

                        _view.ShowMessage("Pembayaran berhasil! Pesanan Anda telah ditempatkan dan dibayar.", "Sukses Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _view.SetDialogResult(DialogResult.OK);
                        _view.CloseView();
                    }
                    catch (MySqlException ex)
                    {
                        transaction.Rollback();
                        _view.ShowMessage("Kesalahan Database selama pembayaran: " + ex.Message + "\nPesanan di-rollback.", "Kesalahan Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _view.SetDialogResult(DialogResult.Abort);
                        _view.CloseView();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _view.ShowMessage("Terjadi kesalahan selama pemrosesan pembayaran: " + ex.Message + "\nPesanan di-rollback.", "Kesalahan Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _view.SetDialogResult(DialogResult.Abort);
                        _view.CloseView();
                    }
                }
            }
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            _view.SetDialogResult(DialogResult.Cancel);
            _view.CloseView();
        }

        private void OnBrowseProofButtonClick(object sender, EventArgs e)
        {
            string filePath = "";
            if (_view.ShowOpenFileDialog("File Gambar|*.jpg;*.jpeg;*.png;*.gif;*.bmp", out filePath) == DialogResult.OK)
            {
                _buktiTransferPath = filePath;
                _view.BuktiTransferPath = filePath;
            }
        }

        private void CalculateChange()
        {
            if (decimal.TryParse(_view.AmountPaidText, out decimal amountPaid))
            {
                decimal change = amountPaid - _grandTotal;
                _view.ChangeLabel = $"Change: {change:C}";
                _view.ChangeLabelColor = change >= 0 ? Color.Green : Color.Red;
            }
            else
            {
                _view.ChangeLabel = "Change: Rp 0.00";
                _view.ChangeLabelColor = Color.Black;
            }
        }
    }
}