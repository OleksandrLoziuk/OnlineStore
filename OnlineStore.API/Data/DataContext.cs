using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Models;

namespace OnlineStore.API.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options): base(options){}
        public DbSet<Category> Categories { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<StringsOrder> StringsOrders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        
    }
}