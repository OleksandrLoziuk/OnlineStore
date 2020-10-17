using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Generic;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Models;

namespace OnlineStore.API.Data.Repositories
{
    public class ReceiptRepository : DbRepository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(DataContext context) : base(context)
        {
        }
    }
}