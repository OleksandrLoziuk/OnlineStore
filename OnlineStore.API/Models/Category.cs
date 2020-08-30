using System.Collections.Generic;

namespace OnlineStore.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PhotoCategory photoCategory { get; set; } 
        public ICollection<Product> Products { get; set; }
    }
}