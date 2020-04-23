namespace OnlineStore.API.Dtos
{
    public class ClientForOrderDto
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DeliveryMethod { get; set; }
        public string Place { get; set; }
        public int PlaceNumber { get; set; }
        public string PaymentMethod { get; set; }
    }
}