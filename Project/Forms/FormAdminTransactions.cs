using System;
using System.Data;
using System.Windows.Forms;
using Project.Data;
using Project.Repositories;
using Project.Controllers;

namespace Project.Forms
{
    public partial class FormAdminTransactions : Form, IAdminTransactionsView
    {
        private AdminTransactionsController _controller;

        public string SelectedTransactionStatus
        {
            get => cmbStatus.SelectedItem?.ToString() ?? string.Empty;
        }

        public int SelectedTransactionId
        {
            get
            {
                if (dgvTransactions.CurrentRow != null && dgvTransactions.CurrentRow.Cells["TransactionId"].Value != DBNull.Value)
                {
                    return Convert.ToInt32(dgvTransactions.CurrentRow.Cells["TransactionId"].Value);
                }
                return 0;
            }
        }

        public void DisplayTransactions(DataTable transactions)
        {
            dgvTransactions.DataSource = transactions;
            if (dgvTransactions.Columns.Contains("TransactionId")) dgvTransactions.Columns["TransactionId"].Visible = false;
            dgvTransactions.ClearSelection();
        }

        public void SetInitialStatusSelection(int index)
        {
            if (cmbStatus.Items.Count > index && index >= 0)
            {
                cmbStatus.SelectedIndex = index;
            }
            else if (cmbStatus.Items.Count > 0)
            {
                cmbStatus.SelectedIndex = 0;
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

        public void ShowAdminDashboard()
        {
            FormAdminDashboard dashboardForm = new FormAdminDashboard();
            dashboardForm.Show();
        }

        public event EventHandler LoadView;
        public event DataGridViewCellEventHandler TransactionsCellClick;
        public event EventHandler UpdateStatusButtonClick;
        public event EventHandler BackToDashboardButtonClick;

        public FormAdminTransactions()
        {
            InitializeComponent();

            if (cmbStatus.Items.Count == 0)
            {
                cmbStatus.Items.AddRange(new object[] { "Pending", "Selesai", "Dibatalkan", "Menunggu Konfirmasi" });
            }

            _controller = new AdminTransactionsController(this, new TransactionRepository(new DatabaseConnection()));

            this.Load += (sender, e) => LoadView?.Invoke(sender, e);
            btnUpdateStatus.Click += (sender, e) => UpdateStatusButtonClick?.Invoke(sender, e);
            btnBackToDashboard.Click += (sender, e) => BackToDashboardButtonClick?.Invoke(sender, e);
            dgvTransactions.CellClick += (sender, e) => TransactionsCellClick?.Invoke(sender, e);
        }
    }
}
