using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using WebShop.Data.Mappings;

namespace WebShop.Data
{
    public class WebShopContext: DbContext
    {
        public WebShopContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Models.Discount.GiftCard> GiftCards { get; set; }
        public DbSet<Models.Discount.PercentCard> PercentCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new GiftCardMap());
            modelBuilder.ApplyConfiguration(new PercentCardMap());
        }
    }
}
