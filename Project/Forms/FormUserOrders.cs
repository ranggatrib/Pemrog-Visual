using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Project.Core;
using Project.Repositories;
using Project.Forms;
using Project.Data;

namespace Project.Forms
{
    public partial class FormUserOrders : Form
    {
        private TransactionRepository _transactionRepository;

        public FormUserOrders()
        {
            InitializeComponent();
            _transactionRepository = new TransactionRepository(new DatabaseConnection());
        }

        private void FormUserOrders_Load(object sender, EventArgs e)
        {
            LoadUserOrders();
        }

        private void LoadUserOrders()
        {
            if (SessionManager.Instance.CurrentUser == null)
            {
                MessageBox.Show("Please log in to view your orders!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            try
            {
                dgvUserOrders.DataSource = _transactionRepository.GetUserPurchaseHistory(SessionManager.Instance.CurrentUser.Id);
                dgvUserOrders.ClearSelection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error loading orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load your orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}