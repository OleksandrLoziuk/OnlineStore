namespace OnlineStore.API.Dtos
{
    public class StingsOrderForListDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public int OrderId { get; set; }

    }
}
