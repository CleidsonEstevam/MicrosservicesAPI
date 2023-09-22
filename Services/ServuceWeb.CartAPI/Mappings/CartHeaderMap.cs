using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServuceWeb.CartAPI.Model.Entities;

namespace ServuceWeb.CartAPI.Mappings
{
    public class CartHeaderMap : IEntityTypeConfiguration<CartHeader>
    {
        public void Configure(EntityTypeBuilder<CartHeader> builder)
        {
            builder.ToTable("cart");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("BIGINT");

            builder.Property(x => x.UserId)
               .IsRequired()
               .HasMaxLength(1000)
               .HasColumnName("user_id")
               .HasColumnType("VARCHAR(1000)");

            builder.Property(x => x.CouponCode)
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnName("coupon_code")
                .HasColumnType("VARCHAR(1000)");
        }
    }
}
