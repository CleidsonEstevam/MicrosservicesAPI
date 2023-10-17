using Microsoft.EntityFrameworkCore;
using ServiceWeb.OrderAPI.Mappings;
using ServiceWeb.OrderAPI.Model;

namespace ServiceWeb.OrderAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderHeaderMap());
            modelBuilder.ApplyConfiguration(new OrderDetailMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
