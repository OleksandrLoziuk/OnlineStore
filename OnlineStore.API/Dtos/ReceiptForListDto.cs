using System;

namespace OnlineStore.API.Dtos
{
    public class ReceiptForListDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductCost { get; set; }
        public int Quantity { get; set; }
        public double Sum { get; set; }
        public string DateAdded { get; set; }
    }
}