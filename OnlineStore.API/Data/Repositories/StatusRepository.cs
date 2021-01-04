using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Generic;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Models;

namespace OnlineStore.API.Data.Repositories
{
    public class StatusRepository : DbRepository<Status>, IStatusRepository
    {
        public StatusRepository(DataContext context) : base(context)
        {
        }
    }
}