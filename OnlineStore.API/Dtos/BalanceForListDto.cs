namespace OnlineStore.API.Dtos
{
    public class BalanceForListDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Sum { get; set; }
    }
}