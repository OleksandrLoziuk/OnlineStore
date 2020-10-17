namespace OnlineStore.API.Models
{
    public class Balance
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Sum { get; set; }
    }
}