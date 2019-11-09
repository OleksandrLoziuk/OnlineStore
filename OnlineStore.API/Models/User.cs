using System.Collections.Generic;

namespace OnlineStore.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Patronymic { get; set; } 
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte [] PasswordSalt { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Delivery Delivery { get; set; }
        public int DeliveryId { get; set; }
        public Payment Payment { get; set; }
        public int PaymentId { get; set; }
    }
}