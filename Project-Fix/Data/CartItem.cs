using System;

namespace Project.Data
{
    public class CartItem
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public int ProdukId { get; set; }
        public int Jumlah { get; set; }
        public DateTime TanggalDitambahkan { get; set; } = DateTime.Now;

        public string NamaProduk { get; set; }
        public decimal HargaProduk { get; set; }
        public string GambarProduk { get; set; }
        public int StokProduk { get; set; }
    }
}