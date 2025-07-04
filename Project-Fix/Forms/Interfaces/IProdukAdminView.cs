using System;
using System.Data;
using System.Windows.Forms;
namespace Project.Forms

{
    public interface IProdukAdminView
    {
        // Properti untuk membaca dan menulis nilai dari/ke View (input fields)
        string ProductIdText { get; set; }
        string ProductNameText { get; set; }
        string ProductDescriptionText { get; set; }
        string ProductPriceText { get; set; }
        string ProductStockText { get; set; }

        // PERBAIKAN: Hanya Property ProductImageLocation (string path)
        string ProductImageLocation { get; set; } // Sesuai dengan PictureBox.ImageLocation

        // Properti untuk membaca produk yang dipilih dari DataGridView
        int SelectedProductId { get; }
        string SelectedProductName { get; }
        string SelectedProductDescription { get; }
        decimal SelectedProductPrice { get; }
        int SelectedProductStock { get; }
        string SelectedProductImage { get; }

        // Metode untuk menampilkan/memperbarui data ke DataGridView
        void DisplayProducts(DataTable products);

        // Metode untuk membersihkan field input
        void ClearFields();

        // PERBAIKAN: Ubah return type dari void menjadi DialogResult
        DialogResult ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);

        // Metode untuk memicu dialog OpenFileDialog
        DialogResult ShowOpenFileDialog(string filter, out string fileName);

        // Metode untuk menavigasi kembali
        void HideView();
        void ShowAdminDashboard();

        // Event yang akan diekspos oleh View dan ditangani oleh Controller
        event EventHandler LoadView;
        event DataGridViewCellEventHandler ProductCellClick;
        event EventHandler CreateButtonClick;
        event EventHandler UpdateButtonClick;
        event EventHandler DeleteButtonClick;
        event EventHandler BrowseImageButtonClick;
        event EventHandler ClearFieldsButtonClick;
        event EventHandler BackToDashboardButtonClick;
    }
}