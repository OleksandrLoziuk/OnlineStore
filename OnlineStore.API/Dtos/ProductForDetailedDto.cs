using System.Collections.Generic;
using OnlineStore.API.Models;

namespace OnlineStore.API.Dtos
{
    public class ProductForDetailedDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public double Cost { get; set; }
        public string ColorName { get; set; }
        public int MinQuantity { get; set; }
        public string Description { get; set; }
        public int Balance { get; set; }
        public bool IsAvailable { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}