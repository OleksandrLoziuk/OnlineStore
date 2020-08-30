namespace OnlineStore.API.Models
{
    public class PhotoCategory
    {
        public int Id { get; set; }
        public string Url { get; set; } 
        public string PublicId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
