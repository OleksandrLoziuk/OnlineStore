using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Generic;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Models;

namespace OnlineStore.API.Data.Repositories
{
    public class OrderRepository : DbRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context)
        {
        }
    }
}