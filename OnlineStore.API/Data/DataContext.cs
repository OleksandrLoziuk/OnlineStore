using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Models;

namespace OnlineStore.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}
        public DbSet<Category> Categories { get; set; }    
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Таблички",
                    PhotoUrl = "../../assets/img/candle.jpg"
                },
                new Category
                {
                    Id = 2,
                    Name = "Покрывала",
                    PhotoUrl = "../../assets/img/candle.jpg"
                },
                new Category
                {
                    Id = 3,
                    Name ="Наволочки",
                    PhotoUrl = "../../assets/img/candle.jpg"    
                },
                new Category
                {
                    Id = 4,
                    Name = "Рушники",
                    PhotoUrl = "../../assets/img/candle.jpg"
                },
                new Category
                {
                    Id = 5,
                    Name = "Салфетки",
                    PhotoUrl = "../../assets/img/candle.jpg"
                },
                new Category
                {
                    Id = 6,
                    Name = "Платки",
                    PhotoUrl = "../../assets/img/candle.jpg"
                }
                );
            builder.Entity<Color>().HasData(
                new Color
                {
                    Id = 1,
                    ColorName = "Черный"
                },
                new Color
                {
                    Id = 2,
                    ColorName = "Белый"
                },
                new Color
                {
                    Id = 3,
                    ColorName = "Бордовый"
                },
                new Color
                {
                    Id = 4,
                    ColorName = "Синий"
                }
                );
      builder.Entity<Photo>().HasData(
                new Photo{
                            Id = 1,
                            Url = "../../assets/img/candle.jpg",
                            IsMain = true,
                            ProductId = 1
                        },
                new Photo{
                            Id = 2,
                            Url = "../../assets/img/candle.jpg",
                            IsMain = false,
                            ProductId = 1
                        },
                new Photo{
                            Id = 3,
                            Url = "../../assets/img/candle.jpg",
                            IsMain = true,
                            ProductId = 2
                        } , 
                new Photo{
                            Id = 4,
                            Url = "../../assets/img/candle.jpg",
                            IsMain = true,
                            ProductId = 3
                        },  
                new Photo{
                            Id = 5,
                            Url = "../../assets/img/candle.jpg",
                            IsMain = true,
                            ProductId = 4
                        }    
            );
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductName="Табличка пластик 18х25",
                    Cost = 7.50,
                    CategoryId = 1,
                    ColorId =1,
                    MinQuantity = 10,
                    Description ="some",
                    Balance = 10,
                    IsAvailable = true
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Табличка пластик 20х25",
                    Cost = 8.50,
                    CategoryId = 1,
                    ColorId = 1,
                    MinQuantity = 10,
                    Description ="some",
                    Balance = 10,
                    IsAvailable = true
                    
                },
                 new Product
                 {
                     Id = 3,
                     ProductName = "Табличка литьё",
                     Cost = 11.00,
                     CategoryId = 1,
                     ColorId = 1,
                     MinQuantity = 10,
                     Description ="some",
                     Balance = 10,
                     IsAvailable = true
                 },
                new Product
                {
                    Id = 4,
                    ProductName = "Табличка металл",
                    Cost = 15.80,
                    CategoryId = 1,
                    ColorId = 2,
                    MinQuantity = 10,
                    Description ="some",
                    Balance = 10,
                    IsAvailable = true
                },

                 new Product
                 {
                     Id = 5,
                     ProductName = "Покрывало рюш шелк",
                     Cost = 60.00,
                     CategoryId = 2,
                     ColorId = 2,
                     MinQuantity = 1,
                     Description ="some",
                     Balance = 10,
                     IsAvailable = true
                 },
                new Product
                {
                    Id = 6,
                    ProductName = "Покрывало рюш атлас",
                    Cost = 95.00,
                    CategoryId = 2,
                    ColorId = 3,
                    MinQuantity = 1,
                    Description ="some",
                    Balance = 10,
                    IsAvailable = true
                },
                 new Product
                 {
                     Id = 7,
                     ProductName = "Наволочка жатка",
                     Cost = 27.50,
                     CategoryId = 3,
                     ColorId = 2,
                     MinQuantity = 10,
                     Description ="some",
                     Balance = 10,
                     IsAvailable = true
                 },
                new Product
                {
                    Id = 8,
                    ProductName = "Рушник габардин 36",
                    Cost = 32.50,
                    CategoryId = 4,
                    ColorId = 2,
                    MinQuantity = 10,
                    Description ="some",
                    Balance = 10,
                    IsAvailable = true,
                }
                );
        }
        
    }
}