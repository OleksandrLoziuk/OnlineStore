using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Generic;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Models;

namespace OnlineStore.API.Data.Repositories
{
    public class BalanceRepository : DbRepository<Balance>, IBalanceRepository
    {
        public BalanceRepository(DataContext context) : base(context)
        {
        }
    }
}