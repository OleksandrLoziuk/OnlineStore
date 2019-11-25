using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Generic;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Models;

namespace OnlineStore.API.Data.Repositories
{
    public class ColorRepository : DbRepository<Color>, IColorRepository
    {
        public ColorRepository(DataContext context) : base(context)
        {
        }
    }
}