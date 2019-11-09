using System.Collections.Generic;

namespace OnlineStore.API.Models
{
    public class Delivery
    {
       public int Id { get; set; }
       public string DeiveryMethod { get; set; }
       public string Locality { get; set; }
       public bool IsTargeted { get; set; } 
       public string Address { get; set; }
       public ICollection<User> Users { get; set; }
    }
}