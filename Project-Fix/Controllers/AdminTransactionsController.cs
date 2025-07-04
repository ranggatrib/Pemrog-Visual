using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Forms;
using Project.Repositories;

namespace Project.Controllers
{
    public class AdminTransactionsController
    {
        private IAdminTransactionsView _view;
        private TransactionRepository _transactionRepository;

        public AdminTransactionsController(IAdminTransactionsView view, TransactionRepository transactionRepository)
        {
            _view = view;
            _transactionRepository = transactionRepository;

            // Langganan event dari View
            _view.LoadView += OnLoadView;
            _view.TransactionsCellClick += OnTransactionsCellClick;
            _view.UpdateStatusButtonClick += OnUpdateStatusButtonClick;
            _view.BackToDashboardButtonClick += OnBackToDashboardButtonClick;
        }

        // --- Event Handlers dari View yang ditangani oleh Controller ---
        private void OnLoadView(object sender, EventArgs e)
        {
            LoadAllTransactions();
            _view.SetInitialStatusSelection(0); // Pilih item pertama (misalnya "Pending")
        }

        private void OnTransactionsCellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void OnUpdateStatusButtonClick(object sender, EventArgs e)
        {
            if (_view.SelectedTransactionId == 0)
            {
                _view.ShowMessage("Silakan pilih transaksi untuk diperbarui.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newStatus = _view.SelectedTransactionStatus;

            if (string.IsNullOrEmpty(newStatus))
            {
                _view.ShowMessage("Silakan pilih status baru.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool success = _transactionRepository.UpdateTransactionStatus(_view.SelectedTransactionId, newStatus);
                if (success)
                {
                    _view.ShowMessage("Status transaksi berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllTransactions(); // Muat ulang data setelah update
                }
                else
                {
                    _view.ShowMessage("Gagal memperbarui status transaksi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database saat memperbarui status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Gagal memperbarui status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnBackToDashboardButtonClick(object sender, EventArgs e)
        {
            _view.HideView();
            _view.ShowAdminDashboard();
        }

        // --- Metode Internal yang Digunakan oleh Controller ---
        private void LoadAllTransactions()
        {
            try
            {
                _view.DisplayTransactions(_transactionRepository.GetAllTransactions());
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database saat memuat semua transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Gagal memuat semua transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}