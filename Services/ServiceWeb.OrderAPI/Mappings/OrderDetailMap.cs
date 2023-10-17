using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceWeb.OrderAPI.Model;

namespace ServiceWeb.OrderAPI.Mappings
{
    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(ch => ch.Id);

            builder.Property(x => x.ProductCode)
             .IsRequired()
             .HasMaxLength(6)
             .HasColumnName("product_code")
             .HasColumnType("VARCHAR(6)");


            builder.Property(x => x.ProductName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("product_name")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Count)
                   .HasColumnName("count")
                   .HasColumnType("INT");


            builder.Property(x => x.Price)
                   .HasColumnName("price")
                   .HasColumnType("DECIMAL");

            builder.HasOne<OrderHeader>(od => od.OrderHeader) // Propriedade de navegação
                   .WithMany(oh => oh.OrderDetails) // Relação "um para muitos"
                   .HasForeignKey(od => od.OrderHeaderId);


        }
    }
}
