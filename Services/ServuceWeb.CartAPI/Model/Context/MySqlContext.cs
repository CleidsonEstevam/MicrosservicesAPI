using Microsoft.EntityFrameworkCore;
using ServiceWeb.CartAPI.Mappings;
using ServiceWeb.CartAPI.Model.Entities;

namespace ServuceWeb.CartAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartHeaderMap());
            modelBuilder.ApplyConfiguration(new CartItemMap());
            modelBuilder.ApplyConfiguration(new ProductMap());

            // Outras configurações, se houver

            base.OnModelCreating(modelBuilder);
        }
    }
}
