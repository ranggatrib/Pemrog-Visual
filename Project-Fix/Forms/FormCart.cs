using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Core;
using Project.Data;
using Project.Repositories;
using Project.Forms;

namespace Project.Forms
{
    public partial class FormCart : Form
    {
        private CartRepository _cartRepository;
        private ProductRepository _productRepository;
        private TransactionRepository _transactionRepository;
        private List<CartItem> currentCartItems;

        public FormCart()
        {
            InitializeComponent();
            _cartRepository = new CartRepository(new DatabaseConnection());
            _productRepository = new ProductRepository(new DatabaseConnection());
            _transactionRepository = new TransactionRepository(new DatabaseConnection());
        }

        private void FormCart_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            if (SessionManager.Instance.CurrentUser == null)
            {
                MessageBox.Show("Please log in to view your cart!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            try
            {
                currentCartItems = _cartRepository.GetCartItemsByUserId(SessionManager.Instance.CurrentUser.Id);

                DataTable dt = new DataTable();
                dt.Columns.Add("CartItemId", typeof(int));
                dt.Columns.Add("Product ID", typeof(int));
                dt.Columns.Add("Product Name", typeof(string));
                dt.Columns.Add("Price per Unit", typeof(decimal));
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("Subtotal", typeof(decimal));

                decimal grandTotal = 0;

                foreach (var item in currentCartItems)
                {
                    decimal subtotal = item.Jumlah * item.HargaProduk;
                    grandTotal += subtotal;
                    dt.Rows.Add(item.Id, item.ProdukId, item.NamaProduk, item.HargaProduk, item.Jumlah, subtotal);
                }

                dgvCartItems.DataSource = dt;
                dgvCartItems.Columns["CartItemId"].Visible = false;

                lblGrandTotal.Text = $"Total: {grandTotal:C}";

                if (currentCartItems.Count == 0)
                {
                    btnCheckout.Enabled = false;
                    btnRemoveItem.Enabled = false;
                }
                else
                {
                    btnCheckout.Enabled = true;
                    btnRemoveItem.Enabled = true;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error loading cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load cart items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count > 0)
            {
                int cartItemId = Convert.ToInt32(dgvCartItems.SelectedRows[0].Cells["CartItemId"].Value);
                if (MessageBox.Show("Are you sure you want to remove this item from your cart?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bool success = _cartRepository.RemoveCartItem(cartItemId);
                        if (success)
                        {
                            MessageBox.Show("Item removed from cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCartItems();
                        }
                        else
                        {
                            MessageBox.Show("Failed to remove item from cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Database Error removing item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to remove item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (currentCartItems == null || currentCartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal grandTotal = currentCartItems.Sum(item => item.Jumlah * item.HargaProduk);

            foreach (var item in currentCartItems)
            {
                Product productInDb = _productRepository.GetProductById(item.ProdukId);
                if (productInDb == null || productInDb.Stok < item.Jumlah)
                {
                    MessageBox.Show($"Not enough stock for '{item.NamaProduk}'. Available: {productInDb?.Stok ?? 0}", "Checkout Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadCartItems();
                    return;
                }
            }

            // Panggil Form Pembayaran
            FormPayment paymentForm = new FormPayment(grandTotal, currentCartItems);
            DialogResult result = paymentForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("Order processed and paid successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // currentCartItems.Clear() and database cart clear are handled in FormPayment
                LoadCartItems(); // Reload cart (should be empty now)
                this.Close(); // Close cart form
            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Payment cancelled by user. Your cart remains intact.", "Payment Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // DialogResult.Abort or other failure from FormPayment
            {
                MessageBox.Show("Payment process failed. Please check your cart and try again.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadCartItems(); // Refresh items in cart in case of partial success or failure
        }
    }
}