using System;
using System.Data;
using System.Windows.Forms;
using Project.Data;
using Project.Repositories;
using Project.Controllers;

namespace Project.Forms
{
    public partial class FormUserOrders : Form, IUserOrdersView
    {
        private UserOrdersController _controller;

        public FormUserOrders()
        {
            InitializeComponent();

            _controller = new UserOrdersController(this, new TransactionRepository(new DatabaseConnection()));

            this.Load += (sender, e) => LoadView?.Invoke(sender, e);
        }

        public void DisplayUserOrders(DataTable orders)
        {
            dgvUserOrders.DataSource = orders;
            dgvUserOrders.ClearSelection();
        }

        public void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        public void CloseView()
        {
            this.Close();
        }

        public event EventHandler LoadView;
    }
}
