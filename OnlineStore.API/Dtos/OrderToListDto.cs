namespace OnlineStore.API.Dtos
{
    public class OrderToListDto
    {
        public int Id { get; set; }
        public string ClientPhone { get; set; }
        public double SumOrder { get; set; }
        public string DateTimeOrder { get; set; }
        public string Status { get; set; }   
    }
}