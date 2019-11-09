using System.Collections.Generic;

namespace OnlineStore.API.Models
{
    public class CategorySign
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}