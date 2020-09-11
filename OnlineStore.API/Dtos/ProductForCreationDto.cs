using OnlineStore.API.Models;

namespace OnlineStore.API.Dtos
{
    public class ProductForCreationDto
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public double Cost { get; set; }
        public string ColorName { get; set; }
        public int MinQuantity { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; } 
    }
}