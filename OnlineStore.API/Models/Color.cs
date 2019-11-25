using System;
using System.Collections.Generic;

namespace OnlineStore.API.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}