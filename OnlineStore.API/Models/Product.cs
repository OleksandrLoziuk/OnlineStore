using System.Collections.Generic;

namespace OnlineStore.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public double Cost { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public int MinQuantity { get; set; }
        public string Description { get; set; }
        public int Balance { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<StringsOrder> StringsOrder { get; set; }

    }
}