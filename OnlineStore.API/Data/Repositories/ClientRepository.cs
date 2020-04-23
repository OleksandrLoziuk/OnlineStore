using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Generic;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Models;

namespace OnlineStore.API.Data.Repositories
{
    public class ClientRepository : DbRepository<Client>, IClientRepository
    {
        public ClientRepository(DataContext context) : base(context)
        {
        }
    }
}