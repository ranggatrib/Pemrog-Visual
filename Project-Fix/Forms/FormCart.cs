using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Project.Data;
using Project.Repositories;
using Project.Controllers;

namespace Project.Forms
{
    public partial class FormCart : Form, ICartView
    {
        private CartController _controller;

        public int SelectedCartItemId
        {
            get
            {
                if (dgvCartItems.SelectedRows.Count > 0 && dgvCartItems.SelectedRows[0].Cells["CartItemId"].Value != DBNull.Value)
                {
                    return Convert.ToInt32(dgvCartItems.SelectedRows[0].Cells["CartItemId"].Value);
                }
                return 0;
            }
        }

        public string GrandTotalText { set => lblGrandTotal.Text = value; }
        public bool CheckoutButtonEnabled { set => btnCheckout.Enabled = value; }
        public bool RemoveItemButtonEnabled { set => btnRemoveItem.Enabled = value; }

        public void DisplayCartItems(DataTable cartItems)
        {
            dgvCartItems.DataSource = cartItems;
            if (dgvCartItems.Columns.Contains("CartItemId"))
            {
                dgvCartItems.Columns["CartItemId"].Visible = false;
            }
            dgvCartItems.ClearSelection();
        }

        public DialogResult ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, title, buttons, icon);
        }

        public void CloseView()
        {
            this.Close();
        }

        public void SetDialogResult(DialogResult result)
        {
            this.DialogResult = result;
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
        public event EventHandler RemoveItemButtonClick;
        public event EventHandler CheckoutButtonClick;
        public event DataGridViewCellEventHandler CartItemsCellClick;

        public FormCart()
        {
            InitializeComponent();

            _controller = new CartController(
                this,
                new CartRepository(new DatabaseConnection()),
                new ProductRepository(new DatabaseConnection()),
                new TransactionRepository(new DatabaseConnection())
            );

            this.Load += (sender, e) => LoadView?.Invoke(sender, e);
            btnRemoveItem.Click += (sender, e) => RemoveItemButtonClick?.Invoke(sender, e);
            btnCheckout.Click += (sender, e) => CheckoutButtonClick?.Invoke(sender, e);
        }
    }
}
