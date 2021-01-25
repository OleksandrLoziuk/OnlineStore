namespace OnlineStore.API.Dtos
{
    public class OrderForDetailDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DeliveryMethod { get; set; }
        public string Place { get; set; }
        public int PlaceNumber { get; set; }
        public string PaymentMethod { get; set; }
        public int ClientId { get; set; }
        public double SumOrder { get; set; }
        public string DateTimeOrder { get; set; }
        public string StatusName { get; set; }     
 
    }
}