using System.Collections.Generic;

namespace OnlineStore.API.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int PaymentMethod { get; set; }
        public ICollection<User> Users { get; set; }
    }
}