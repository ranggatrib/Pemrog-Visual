using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Data;
using Project.Repositories;
using Project.Core;
using System.Drawing;

namespace Project.Forms
{
    public partial class FormPayment : Form
    {
        private decimal _grandTotal;
        private List<CartItem> _cartItemsToProcess;
        private CartRepository _cartRepository;
        private ProductRepository _productRepository;
        private TransactionRepository _transactionRepository;

        public FormPayment(decimal grandTotal, List<CartItem> cartItemsToProcess)
        {
            InitializeComponent();
            _grandTotal = grandTotal;
            _cartItemsToProcess = cartItemsToProcess;

            _cartRepository = new CartRepository(new DatabaseConnection());
            _productRepository = new ProductRepository(new DatabaseConnection());
            _transactionRepository = new TransactionRepository(new DatabaseConnection());

            lblGrandTotal.Text = $"Grand Total: {_grandTotal:C}";
            lblChange.Text = "Change: Rp 0.00";
            txtAmountPaid.Text = "0";
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            cmbPaymentMethod.SelectedIndex = 0; // Select the first payment method (Tunai) by default
            txtAmountPaid.Focus();
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            if (decimal.TryParse(txtAmountPaid.Text, out decimal amountPaid))
            {
                decimal change = amountPaid - _grandTotal;
                lblChange.Text = $"Change: {change:C}";
                lblChange.ForeColor = change >= 0 ? Color.Green : Color.Red;
            }
            else
            {
                lblChange.Text = "Change: Rp 0.00";
                lblChange.ForeColor = Color.Black;
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmountPaid.Text, out decimal amountPaid))
            {
                MessageBox.Show("Please enter a valid amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(cmbPaymentMethod.Text))
            {
                MessageBox.Show("Please select a payment method.", "Invalid Payment Method", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (amountPaid < _grandTotal)
            {
                MessageBox.Show("Amount paid is insufficient. Please pay the full amount.", "Payment Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                                throw new Exception($"Not enough stock for '{item.NamaProduk}'. Available: {productInDb?.Stok ?? 0}");
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
                                Status = "Selesai"
                            };
                            _transactionRepository.AddTransaction(newTransaction, conn, transaction);
                        }

                        _cartRepository.ClearCart(SessionManager.Instance.CurrentUser.Id, conn, transaction);

                        transaction.Commit();
                        MessageBox.Show("Payment successful! Your order has been placed and paid.", "Payment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (MySqlException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Database Error during payment: " + ex.Message + "\nOrder rolled back.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Abort;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("An error occurred during payment processing: " + ex.Message + "\nOrder rolled back.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Abort;
                        this.Close();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}