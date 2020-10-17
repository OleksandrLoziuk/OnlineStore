using System;

namespace OnlineStore.API.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Sum { get; set; }
        public DateTime DateAdded { get; set; }
    }
}