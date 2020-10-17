using System;

namespace OnlineStore.API.Dtos
{
    public class ReceiptForCreationDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Sum { get; set; }
        public DateTime DateAdded { get; set; }

        public ReceiptForCreationDto()
        {
            DateAdded = DateTime.Now; 
        }
    }
}