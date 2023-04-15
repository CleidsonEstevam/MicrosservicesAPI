using Microsoft.EntityFrameworkCore;
using ServiceWeb.ProductAPI.Model.Entities;

namespace ServiceWeb.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
