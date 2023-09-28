using Microsoft.EntityFrameworkCore;
using ServiceWeb.CartAPI.Mappings;
using ServiceWeb.CartAPI.Model.Entities;

namespace ServuceWeb.CartAPI.Model.Context
{
    public class MySqlCartContext : DbContext
    {
        public MySqlCartContext() { }
        public MySqlCartContext(DbContextOptions<MySqlCartContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartHeaderMap());
            modelBuilder.ApplyConfiguration(new CartItemMap());
            modelBuilder.ApplyConfiguration(new ProductMap());

          

            base.OnModelCreating(modelBuilder);
        }
    }
}
