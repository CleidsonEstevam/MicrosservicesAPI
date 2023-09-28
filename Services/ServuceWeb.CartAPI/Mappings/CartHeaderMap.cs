using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceWeb.CartAPI.Model.Entities;

namespace ServiceWeb.CartAPI.Mappings
{
    public class CartHeaderMap : IEntityTypeConfiguration<CartHeader>
    {
        public void Configure(EntityTypeBuilder<CartHeader> builder)
        {
            builder.HasKey(ch => ch.Id);
            builder.Property(ch => ch.UserId).IsRequired();

            // Configuração de relacionamento com CartItem
            builder.HasMany(ch => ch.CartItems)
                .WithOne(ci => ci.CartHeader)
                .HasForeignKey(ci => ci.CartHeaderId);

            builder.Property(x => x.CouponCode)
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnName("coupon_code")
                .HasColumnType("VARCHAR(1000)");
        }
    }
}
