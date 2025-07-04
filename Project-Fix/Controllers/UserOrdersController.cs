using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Core; 
using Project.Forms;
using Project.Repositories;

namespace Project.Controllers
{
    public class UserOrdersController
    {
        private IUserOrdersView _view;
        private TransactionRepository _transactionRepository;

        public UserOrdersController(IUserOrdersView view, TransactionRepository transactionRepository)
        {
            _view = view;
            _transactionRepository = transactionRepository;

            // Langganan event dari View
            _view.LoadView += OnLoadView;
        }

        // --- Event Handlers dari View yang ditangani oleh Controller ---

        private void OnLoadView(object sender, EventArgs e)
        {
            LoadUserOrders();
        }

        // --- Metode Internal yang Digunakan oleh Controller ---

        private void LoadUserOrders()
        {
            if (SessionManager.Instance.CurrentUser == null)
            {
                _view.ShowMessage("Harap login untuk melihat pesanan Anda!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _view.CloseView();
                return;
            }

            try
            {
                _view.DisplayUserOrders(_transactionRepository.GetUserPurchaseHistory(SessionManager.Instance.CurrentUser.Id));
            }
            catch (MySqlException ex)
            {
                _view.ShowMessage("Kesalahan Database saat memuat pesanan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Gagal memuat pesanan Anda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}