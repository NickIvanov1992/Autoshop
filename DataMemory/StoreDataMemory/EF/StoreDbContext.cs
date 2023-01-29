using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using domain.store;


namespace DataMemory.EF
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
        
        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StoreCartItem> StoreCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
