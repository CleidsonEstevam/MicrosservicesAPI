using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceWeb.CartAPI.Model.Entities;

namespace ServiceWeb.CartAPI.Mappings
{
    public class CartItemMap : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Quantity)
                   .IsRequired()
                   .HasMaxLength(1000)
                   .HasColumnName("quantity")
                   .HasColumnType("INT");

            // Configuração de relacionamento com CartHeader
            builder.HasOne(ci => ci.CartHeader)
                   .WithMany(ch => ch.CartItems)
                   .HasForeignKey(ci => ci.CartHeaderId);

            // Configuração de relacionamento com Product
            builder.HasOne(ci => ci.Product)
                   .WithMany()
                   .HasForeignKey(ci => ci.ProductCode);

        }
    }
}
