using System;

namespace OnlineStore.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public double SumOrder { get; set; }
        public DateTime DateTimeOrder { get; set; }

    }
}