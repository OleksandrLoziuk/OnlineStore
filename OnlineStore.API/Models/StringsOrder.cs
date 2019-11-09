namespace OnlineStore.API.Models
{
    public class StringsOrder
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}