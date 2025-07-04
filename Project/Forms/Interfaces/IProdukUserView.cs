using System;
using System.Data;
using System.Windows.Forms;
using Project.Data;
using System.Collections.Generic;

namespace Project.Forms
{
    public interface IProdukUserView
    {
        int SelectedProductId { get; }
        int Quantity { get; }

        string ProductName { set; }
        string ProductDescription { set; }
        string ProductPrice { set; }
        string ProductStock { set; }
        string ProductImageLocation { set; }
        int MaxQuantity { set; }

        void DisplayProducts(DataTable products);
        void ClearProductSelection();

        void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);
        void HideView();
        void ShowLoginForm();
        void ShowCartForm();
        void ShowUserOrdersForm();
        DialogResult ShowShippingDetailsForm(out string namaPenerima, out string alamatPengiriman, out string nomorTeleponPenerima);
        DialogResult ShowPaymentForm(decimal grandTotal, List<CartItem> cartItems, string namaPenerima, string alamatPengiriman, string nomorTeleponPenerima);

        event EventHandler LoadView;
        event DataGridViewCellEventHandler ProductCellClick;
        event EventHandler BuyButtonClick;
        event EventHandler AddToCartButtonClick;
        event EventHandler ViewCartButtonClick;
        event EventHandler MyOrdersButtonClick;
        event EventHandler LogoutButtonClick;
    }
}