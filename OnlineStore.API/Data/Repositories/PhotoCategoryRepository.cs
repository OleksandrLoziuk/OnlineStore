using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Generic;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Models;

namespace OnlineStore.API.Data.Repositories
{
    public class PhotoCategoryRepository : DbRepository<PhotoCategory>, IPhotoCategoryRepository
    {
        public PhotoCategoryRepository(DataContext context) : base(context)
        {
        }
    }
}