namespace OnlineStore.API.Dtos
{
    public class ProductForListDto
    {
        public int Id { get; set; }
        public string ProductName  { get; set; }
        public string CategoryName { get; set; }
        public double Cost { get; set; }
        public int MinQuantity { get; set; }
        public bool IsAvailable { get; set; }
        public string PhotoUrl { get; set; }

    }
}