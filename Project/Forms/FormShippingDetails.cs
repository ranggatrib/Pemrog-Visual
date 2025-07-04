using System;
using System.Windows.Forms;
using Project.Controllers;

namespace Project.Forms
{
    public partial class FormShippingDetails : Form, IShippingDetailsView
    {
        private ShippingDetailsController _controller;

        public string NamaPenerimaText => txtNamaPenerima.Text.Trim();
        public string AlamatPengirimanText => txtAlamat.Text.Trim();
        public string NomorTeleponPenerimaText => txtNomorTelepon.Text.Trim();

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

        public event EventHandler ContinuePaymentButtonClick;
        public event EventHandler CancelButtonClick;

        public FormShippingDetails()
        {
            InitializeComponent();

            _controller = new ShippingDetailsController(this);

            btnContinuePayment.Click += (sender, e) => ContinuePaymentButtonClick?.Invoke(sender, e);
            btnCancel.Click += (sender, e) => CancelButtonClick?.Invoke(sender, e);
        }
    }
}
