using Microsoft.AspNetCore.Http;

namespace OnlineStore.API.Dtos
{
    public class PhotoCategoryForCreationDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string PublicId { get; set; }
    }
}