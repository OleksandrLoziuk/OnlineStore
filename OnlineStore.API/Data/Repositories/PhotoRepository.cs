using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Generic;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Models;

namespace OnlineStore.API.Data.Repositories
{
    public class PhotoRepository : DbRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(DataContext context) : base(context)
        {
        }
    }
}