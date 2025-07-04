using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Project.Controllers;
using Project.Data;
using Project.Repositories;

namespace Project.Forms
{
    public partial class FormProdukUser : Form, IProdukUserView
    {
        private ProdukUserController _controller;

        public int SelectedProductId
        {
            get
            {
                if (dgvProduk.CurrentRow != null && dgvProduk.CurrentRow.Cells["Id"].Value != DBNull.Value)
                {
                    return Convert.ToInt32(dgvProduk.CurrentRow.Cells["Id"].Value);
                }
                return 0;
            }
        }

        public int Quantity => (int)numJumlah.Value;

        public new string ProductName { set => labelNama.Text = value; }
        public string ProductDescription { set => labelDeskripsi.Text = value; }
        public string ProductPrice { set => labelHarga.Text = value; }
        public string ProductStock { set => labelStok.Text = value; }

        public string ProductImageLocation
        {
            set
            {
                if (!string.IsNullOrEmpty(value) && File.Exists(value))
                {
                    pbGambar.Image = Image.FromFile(value);
                }
                else
                {
                    pbGambar.Image = null;
                }
            }
        }

        public int MaxQuantity { set => numJumlah.Maximum = value; }

        public void DisplayProducts(DataTable products)
        {
            dgvProduk.DataSource = products;
            if (dgvProduk.Columns.Contains("Id")) dgvProduk.Columns["Id"].Visible = false;
            if (dgvProduk.Columns.Contains("Gambar")) dgvProduk.Columns["Gambar"].Visible = false;
        }

        public void ClearProductSelection()
        {
            labelNama.Text = "Nama Produk";
            labelDeskripsi.Text = "Deskripsi Produk";
            labelHarga.Text = "Rp 0";
            labelStok.Text = "Stok: 0";
            pbGambar.Image = null;
            numJumlah.Value = 1;
            numJumlah.Maximum = 1;

            if (dgvProduk.CurrentRow != null)
            {
                dgvProduk.CurrentRow.Selected = false;
            }
        }

        public void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        public void HideView()
        {
            this.Hide();
        }

        public void ShowLoginForm()
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
        }

        public void ShowCartForm()
        {
            FormCart cartForm = new FormCart();
            cartForm.ShowDialog();
        }

        public void ShowUserOrdersForm()
        {
            FormUserOrders userOrdersForm = new FormUserOrders();
            userOrdersForm.Show();
        }

        public DialogResult ShowShippingDetailsForm(out string namaPenerima, out string alamatPengiriman, out string nomorTeleponPenerima)
        {
            namaPenerima = "";
            alamatPengiriman = "";
            nomorTeleponPenerima = "";

            using (FormShippingDetails shippingForm = new FormShippingDetails())
            {
                if (shippingForm.ShowDialog() == DialogResult.OK)
                {
                    namaPenerima = shippingForm.NamaPenerimaText;
                    alamatPengiriman = shippingForm.AlamatPengirimanText;
                    nomorTeleponPenerima = shippingForm.NomorTeleponPenerimaText;
                    return DialogResult.OK;
                }
                return DialogResult.Cancel;
            }
        }

        public DialogResult ShowPaymentForm(decimal grandTotal, List<CartItem> cartItems, string namaPenerima, string alamatPengiriman, string nomorTeleponPenerima)
        {
            using (FormPayment paymentForm = new FormPayment(grandTotal, cartItems, namaPenerima, alamatPengiriman, nomorTeleponPenerima))
            {
                return paymentForm.ShowDialog();
            }
        }

        public event EventHandler LoadView;
        public event DataGridViewCellEventHandler ProductCellClick;
        public event EventHandler BuyButtonClick;
        public event EventHandler AddToCartButtonClick;
        public event EventHandler ViewCartButtonClick;
        public event EventHandler MyOrdersButtonClick;
        public event EventHandler LogoutButtonClick;

        public FormProdukUser()
        {
            InitializeComponent();

            _controller = new ProdukUserController(
                this,
                new ProductRepository(new DatabaseConnection()),
                new TransactionRepository(new DatabaseConnection()),
                new CartRepository(new DatabaseConnection())
            );

            this.Load += (sender, e) => LoadView?.Invoke(sender, e);
            dgvProduk.CellClick += (sender, e) => ProductCellClick?.Invoke(sender, e);
            btnBeli.Click += (sender, e) => BuyButtonClick?.Invoke(sender, e);
            btnAddToCart.Click += (sender, e) => AddToCartButtonClick?.Invoke(sender, e);
            btnViewCart.Click += (sender, e) => ViewCartButtonClick?.Invoke(sender, e);
            btnMyOrders.Click += (sender, e) => MyOrdersButtonClick?.Invoke(sender, e);
            btnLogout.Click += (sender, e) => LogoutButtonClick?.Invoke(sender, e);

            numJumlah.Minimum = 1;
            numJumlah.Maximum = 1;
        }
    }
}
