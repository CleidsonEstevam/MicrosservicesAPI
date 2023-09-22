using Microsoft.EntityFrameworkCore;
using ServuceWeb.CartAPI.Model.Entities;

namespace ServuceWeb.CartAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
