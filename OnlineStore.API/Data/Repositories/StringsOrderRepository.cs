using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Generic;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Models;

namespace OnlineStore.API.Data.Repositories
{
    public class StringsOrderRepository : DbRepository<StringsOrder>, IStringsOrderRepository
    {
        public StringsOrderRepository(DataContext context) : base(context)
        {
        }
    }
}