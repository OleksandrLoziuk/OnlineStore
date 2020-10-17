namespace OnlineStore.API.Dtos
{
    public class BalanceForCreationDto
    {        
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Sum { get; set; }
    }
}