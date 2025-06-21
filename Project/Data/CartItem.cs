// Project/Data/CartItem.cs
using System;

namespace Project.Data
{
    public class CartItem
    {
        public int Id { get; set; } // Cart item ID from database
        public int UserId { get; set; }
        public int ProdukId { get; set; }
        public int Jumlah { get; set; }
        public DateTime TanggalDitambahkan { get; set; } = DateTime.Now;

        // Properties below are not stored directly in the 'keranjang' table,
        // but are retrieved via JOIN for display purposes.
        public string NamaProduk { get; set; }
        public decimal HargaProduk { get; set; }
        public string GambarProduk { get; set; }
        public int StokProduk { get; set; } // Added for stock validation
    }
}