using System;

namespace OnlineStore.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public double SumOrder { get; set; }
        public DateTime DateTimeOrder { get; set; }
        public string Status { get; set; }         

    }
}