using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Generic;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Models;

namespace OnlineStore.API.Data.Repositories
{
    public class CategoryRepository : DbRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}