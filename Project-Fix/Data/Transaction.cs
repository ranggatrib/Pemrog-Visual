using System;

namespace Project.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ProdukId { get; set; }
        public int Jumlah { get; set; }
        public DateTime Tanggal { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public string Status { get; set; } = "Pending";
    }
}