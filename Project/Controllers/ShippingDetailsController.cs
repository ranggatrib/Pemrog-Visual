using System;
using System.Windows.Forms;
using Project.Forms; 

namespace Project.Controllers
{
    public class ShippingDetailsController
    {
        private IShippingDetailsView _view;

        public ShippingDetailsController(IShippingDetailsView view)
        {
            _view = view;

            // Langganan event dari View
            _view.ContinuePaymentButtonClick += OnContinuePaymentButtonClick;
            _view.CancelButtonClick += OnCancelButtonClick;
        }

        // --- Event Handlers dari View yang ditangani oleh Controller ---
        private void OnContinuePaymentButtonClick(object sender, EventArgs e)
        {
            string namaPenerima = _view.NamaPenerimaText;
            string alamatPengiriman = _view.AlamatPengirimanText;
            string nomorTeleponPenerima = _view.NomorTeleponPenerimaText;

            if (string.IsNullOrWhiteSpace(namaPenerima) ||
                string.IsNullOrWhiteSpace(alamatPengiriman) ||
                string.IsNullOrWhiteSpace(nomorTeleponPenerima))
            {
                _view.ShowMessage("Harap isi semua detail pengiriman.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Data yang valid akan diambil oleh Form pemanggil melalui properti View
            _view.SetDialogResult(DialogResult.OK);
            _view.CloseView();
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            _view.SetDialogResult(DialogResult.Cancel);
            _view.CloseView();
        }
    }
}