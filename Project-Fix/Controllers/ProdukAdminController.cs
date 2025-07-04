using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Data;
using Project.Forms;
using Project.Repositories;

namespace Project.Controllers
{
    public class ProdukAdminController
    {
        private IProdukAdminView _view;
        private ProductRepository _productRepository;
        private Product _currentProduct;

        public ProdukAdminController(IProdukAdminView view, ProductRepository productRepository)
        {
            _view = view;
            _productRepository = productRepository;
            _currentProduct = new Product();

            _view.LoadView += OnLoadView;
            _view.ProductCellClick += OnProductCellClick;
            _view.CreateButtonClick += OnCreateButtonClick;
            _view.UpdateButtonClick += OnUpdateButtonClick;
            _view.DeleteButtonClick += OnDeleteButtonClick;
            _view.BrowseImageButtonClick += OnBrowseImageButtonClick;
            _view.ClearFieldsButtonClick += OnClearFieldsButtonClick;
            _view.BackToDashboardButtonClick += OnBackToDashboardButtonClick;
        }

        private void OnLoadView(object sender, EventArgs e)
        {
            LoadProducts();
            ClearInputFields();
        }

        private void OnProductCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dgvProduk = (DataGridView)sender;
                DataGridViewRow row = dgvProduk.Rows[e.RowIndex];

                _currentProduct = new Product
                {
                    Id = Convert.ToInt32(row.Cells["Id"].Value),
                    Nama = row.Cells["Nama"].Value.ToString(),
                    Deskripsi = row.Cells["Deskripsi"].Value.ToString(),
                    Harga = Convert.ToDecimal(row.Cells["Harga"].Value),
                    Stok = Convert.ToInt32(row.Cells["Stok"].Value),
                    Gambar = row.Cells["Gambar"].Value?.ToString()
                };

                _view.ProductIdText = _currentProduct.Id.ToString();
                _view.ProductNameText = _currentProduct.Nama;
                _view.ProductDescriptionText = _currentProduct.Deskripsi;
                _view.ProductPriceText = _currentProduct.Harga.ToString();
                _view.ProductStockText = _currentProduct.Stok.ToString();

                if (!string.IsNullOrEmpty(_currentProduct.Gambar))
                {
                    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _currentProduct.Gambar);
                    if (File.Exists(imagePath))
                    {
                        _view.ProductImageLocation = imagePath; // HANYA SET PATH
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

        private void OnCreateButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_view.ProductNameText) || string.IsNullOrEmpty(_view.ProductDescriptionText) ||
                string.IsNullOrEmpty(_view.ProductPriceText) || string.IsNullOrEmpty(_view.ProductStockText))
            {
                _view.ShowMessage("Harap isi semua field informasi produk.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(_view.ProductImageLocation))
            {
                _view.ShowMessage("Harap pilih gambar terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(_view.ProductPriceText, out decimal harga) || harga < 0)
            {
                _view.ShowMessage("Harga tidak valid. Harap masukkan angka positif.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(_view.ProductStockText, out int stok) || stok < 0)
            {
                _view.ShowMessage("Stok tidak valid. Harap masukkan bilangan bulat non-negatif.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string imageDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img");
                Directory.CreateDirectory(imageDir);

                string fileName = Path.GetFileName(_view.ProductImageLocation);
                string destinationPath = Path.Combine(imageDir, fileName);

                if (!File.Exists(destinationPath) || new FileInfo(_view.ProductImageLocation).LastWriteTime > new FileInfo(destinationPath).LastWriteTime)
                {
                    File.Copy(_view.ProductImageLocation, destinationPath, true);
                }

                Product newProduct = new Product
                {
                    Nama = _view.ProductNameText,
                    Deskripsi = _view.ProductDescriptionText,
                    Harga = harga,
                    Stok = stok,
                    Gambar = "img/" + fileName
                };

                _productRepository.AddProduct(newProduct);

                _view.ShowMessage("Produk berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
                ClearInputFields();
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database saat menambahkan produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Gagal menambahkan produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnUpdateButtonClick(object sender, EventArgs e)
        {
            if (_currentProduct == null || _currentProduct.Id == 0)
            {
                _view.ShowMessage("Harap pilih produk untuk diperbarui.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(_view.ProductNameText) || string.IsNullOrEmpty(_view.ProductDescriptionText) ||
                string.IsNullOrEmpty(_view.ProductPriceText) || string.IsNullOrEmpty(_view.ProductStockText))
            {
                _view.ShowMessage("Harap isi semua field informasi produk.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal harga;
                int stok;
                if (!decimal.TryParse(_view.ProductPriceText, out harga) || harga < 0)
                {
                    _view.ShowMessage("Harga tidak valid. Harap masukkan angka positif.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(_view.ProductStockText, out stok) || stok < 0)
                {
                    _view.ShowMessage("Stok tidak valid. Harap masukkan bilangan bulat non-negatif.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _currentProduct.Nama = _view.ProductNameText;
                _currentProduct.Deskripsi = _view.ProductDescriptionText;
                _currentProduct.Harga = harga;
                _currentProduct.Stok = stok;

                _productRepository.UpdateProduct(_currentProduct);

                _view.ShowMessage("Produk berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
                ClearInputFields();
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database saat memperbarui produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Gagal memperbarui produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteButtonClick(object sender, EventArgs e)
        {
            if (_currentProduct == null || _currentProduct.Id == 0)
            {
                _view.ShowMessage("Harap pilih produk untuk dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ShowMessage sekarang mengembalikan DialogResult
            if (_view.ShowMessage("Apakah Anda yakin ingin menghapus produk ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _productRepository.DeleteProduct(_currentProduct.Id);

                    _view.ShowMessage("Produk berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                    ClearInputFields();
                }
                catch (MySqlException ex)
                {
                    _view.ShowMessage("Kesalahan Database saat menghapus produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    _view.ShowMessage("Gagal menghapus produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnBrowseImageButtonClick(object sender, EventArgs e)
        {
            string fileName = "";
            if (_view.ShowOpenFileDialog("File Gambar|*.jpg;*.jpeg;*.png;*.gif;*.bmp", out fileName) == DialogResult.OK)
            {
                _view.ProductImageLocation = fileName;
            }
        }

        private void OnClearFieldsButtonClick(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void OnBackToDashboardButtonClick(object sender, EventArgs e)
        {
            _view.HideView();
            _view.ShowAdminDashboard();
        }

        private void LoadProducts()
        {
            try
            {
                _view.DisplayProducts(_productRepository.GetAllProducts());
                _view.ClearFields();
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            _view.ClearFields();
            _currentProduct = new Product();
        }
    }
}