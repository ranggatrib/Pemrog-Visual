using System;
using System.Data;
using System.Windows.Forms;
using Project.Data;
using Project.Repositories;
using Project.Controllers;

namespace Project.Forms
{
    public partial class FormProdukAdmin : Form, IProdukAdminView
    {
        private ProdukAdminController _controller;

        public string ProductIdText
        {
            get => txtId.Text;
            set => txtId.Text = value;
        }

        public string ProductNameText
        {
            get => txtNama.Text;
            set => txtNama.Text = value;
        }

        public string ProductDescriptionText
        {
            get => txtDeskripsi.Text;
            set => txtDeskripsi.Text = value;
        }

        public string ProductPriceText
        {
            get => txtHarga.Text;
            set => txtHarga.Text = value;
        }

        public string ProductStockText
        {
            get => txtStok.Text;
            set => txtStok.Text = value;
        }

        public string ProductImageLocation
        {
            get => pbGambar.ImageLocation;
            set => pbGambar.ImageLocation = value;
        }

        public int SelectedProductId { get; private set; }
        public string SelectedProductName { get; private set; }
        public string SelectedProductDescription { get; private set; }
        public decimal SelectedProductPrice { get; private set; }
        public int SelectedProductStock { get; private set; }
        public string SelectedProductImage { get; private set; }

        public void DisplayProducts(DataTable products)
        {
            dgvProduk.DataSource = products;
            if (dgvProduk.Columns.Contains("Id"))
                dgvProduk.Columns["Id"].Visible = false;
        }

        public void ClearFields()
        {
            txtId.Clear();
            txtNama.Clear();
            txtDeskripsi.Clear();
            txtHarga.Clear();
            txtStok.Clear();
            pbGambar.ImageLocation = null;
            pbGambar.Image = null;
            SelectedProductId = 0;
            SelectedProductName = string.Empty;
            SelectedProductDescription = string.Empty;
            SelectedProductPrice = 0;
            SelectedProductStock = 0;
            SelectedProductImage = string.Empty;
        }

        public DialogResult ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, title, buttons, icon);
        }

        public DialogResult ShowOpenFileDialog(string filter, out string fileName)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = filter;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    return DialogResult.OK;
                }
                fileName = "";
                return DialogResult.Cancel;
            }
        }

        public void HideView()
        {
            this.Hide();
        }

        public void ShowAdminDashboard()
        {
            FormAdminDashboard adminDashboard = new FormAdminDashboard();
            adminDashboard.Show();
        }

        public event EventHandler LoadView;
        public event DataGridViewCellEventHandler ProductCellClick;
        public event EventHandler CreateButtonClick;
        public event EventHandler UpdateButtonClick;
        public event EventHandler DeleteButtonClick;
        public event EventHandler BrowseImageButtonClick;
        public event EventHandler ClearFieldsButtonClick;
        public event EventHandler BackToDashboardButtonClick;

        public FormProdukAdmin()
        {
            InitializeComponent();

            _controller = new ProdukAdminController(this, new ProductRepository(new DatabaseConnection()));

            this.Load += (sender, e) => LoadView?.Invoke(sender, e);
            dgvProduk.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvProduk.Rows[e.RowIndex];
                    SelectedProductId = Convert.ToInt32(row.Cells["Id"].Value);
                    SelectedProductName = row.Cells["Nama"].Value.ToString();
                    SelectedProductDescription = row.Cells["Deskripsi"].Value.ToString();
                    SelectedProductPrice = Convert.ToDecimal(row.Cells["Harga"].Value);
                    SelectedProductStock = Convert.ToInt32(row.Cells["Stok"].Value);
                    SelectedProductImage = row.Cells["Gambar"].Value?.ToString();
                }
                ProductCellClick?.Invoke(sender, e);
            };
            btnCreate.Click += (sender, e) => CreateButtonClick?.Invoke(sender, e);
            btnUpdate.Click += (sender, e) => UpdateButtonClick?.Invoke(sender, e);
            btnDelete.Click += (sender, e) => DeleteButtonClick?.Invoke(sender, e);
            btnBrowse.Click += (sender, e) => BrowseImageButtonClick?.Invoke(sender, e);
            btnBackToDashboard.Click += (sender, e) => BackToDashboardButtonClick?.Invoke(sender, e);
        }
    }
}
