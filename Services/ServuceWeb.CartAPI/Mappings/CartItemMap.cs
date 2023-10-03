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

            builder.Property(ci => ci.ProductCode) // Mapeie o ProductCode
                   .IsRequired()
                   .HasMaxLength(255) // Defina o tamanho máximo adequado
                   .HasColumnName("product_code");

            // Configuração de relacionamento com CartHeader
            builder.HasOne(ci => ci.CartHeader)
                   .WithMany(ch => ch.CartItems)
                   .HasForeignKey(ci => ci.CartHeaderId);

        }
    }
}
