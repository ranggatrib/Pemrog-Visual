using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Project.Data;
using Project.Repositories;
using Project.Controllers;

namespace Project.Forms
{
    public partial class FormPayment : Form, IPaymentView
    {
        private PaymentController _controller;

        public string GrandTotalLabel { set => lblGrandTotal.Text = value; }
        public string ChangeLabel { set => lblChange.Text = value; }
        public Color ChangeLabelColor { set => lblChange.ForeColor = value; }

        public string AmountPaidText
        {
            get => txtAmountPaid.Text;
            set => txtAmountPaid.Text = value;
        }

        public string PaymentMethod
        {
            get => cmbPaymentMethod.SelectedItem?.ToString() ?? string.Empty;
            set => cmbPaymentMethod.SelectedItem = value;
        }

        public string BuktiTransferPath
        {
            get => txtBuktiTransferPath.Text;
            set => txtBuktiTransferPath.Text = value;
        }

        public bool BuktiTransferVisible { set => lblBuktiTransfer.Visible = value; }
        public bool AmountPaidEnabled { set => txtAmountPaid.Enabled = value; }
        public bool BrowseProofVisible { set => btnBrowseProof.Visible = value; }
        public bool AdminRekeningVisible { set => lblAdminRekening.Visible = value; }
        public string AdminRekeningText { set => lblAdminRekening.Text = value; }

        public void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        public void CloseView()
        {
            this.Close();
        }

        public void SetDialogResult(DialogResult result)
        {
            this.DialogResult = result;
        }

        public DialogResult ShowOpenFileDialog(string filter, out string fileName)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                return DialogResult.OK;
            }
            fileName = "";
            return DialogResult.Cancel;
        }

        public event EventHandler LoadView;
        public event EventHandler AmountPaidTextChanged;
        public event EventHandler PaymentMethodSelectedIndexChanged;
        public event EventHandler PayButtonClick;
        public event EventHandler CancelButtonClick;
        public event EventHandler BrowseProofButtonClick;

        public FormPayment(decimal grandTotal, List<CartItem> cartItemsToProcess, string namaPenerima, string alamatPengiriman, string nomorTeleponPenerima)
        {
            InitializeComponent();

            if (cmbPaymentMethod.Items.Count == 0)
            {
                cmbPaymentMethod.Items.Add("Tunai");
                cmbPaymentMethod.Items.Add("Bank Transfer");
            }

            _controller = new PaymentController(
                this,
                grandTotal,
                cartItemsToProcess,
                namaPenerima,
                alamatPengiriman,
                nomorTeleponPenerima,
                new CartRepository(new DatabaseConnection()),
                new ProductRepository(new DatabaseConnection()),
                new TransactionRepository(new DatabaseConnection())
            );

            this.Load += (sender, e) => LoadView?.Invoke(sender, e);
            txtAmountPaid.TextChanged += (sender, e) => AmountPaidTextChanged?.Invoke(sender, e);
            cmbPaymentMethod.SelectedIndexChanged += (sender, e) => PaymentMethodSelectedIndexChanged?.Invoke(sender, e);
            btnPay.Click += (sender, e) => PayButtonClick?.Invoke(sender, e);
            btnCancel.Click += (sender, e) => CancelButtonClick?.Invoke(sender, e);
            btnBrowseProof.Click += (sender, e) => BrowseProofButtonClick?.Invoke(sender, e);
        }
    }
}
