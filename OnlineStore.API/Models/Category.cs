using System.Collections.Generic;

namespace OnlineStore.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategorySign CategorySign { get; set; }
        public int? CategorySignId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}