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
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Status> Status { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Status>().HasData(
                new Status
                {
                    Id = 1,
                    Name = "Новый"
                },
                new Status
                {
                    Id = 2,
                    Name = "Принят"
                },
                new Status
                {
                    Id = 3,
                    Name = "Выполнен"
                },
                new Status
                {
                    Id = 4,
                    Name = "Отменён"
                }
            );
        }

        
    }
}