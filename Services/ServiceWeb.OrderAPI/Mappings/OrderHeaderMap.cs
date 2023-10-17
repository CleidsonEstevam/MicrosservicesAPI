using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceWeb.OrderAPI.Model;

namespace ServiceWeb.OrderAPI.Mappings
{
    public class OrderHeaderMap : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.HasKey(ch => ch.Id);

            builder.Property(ch => ch.UserId).IsRequired();

            builder.Property(x => x.PurchaseAmount)
                   .IsRequired()
                   .HasColumnName("purchase_amount")
                   .HasColumnType("DECIMAL");

            builder.Property(x => x.PurchaseAmount)
                   .IsRequired()
                   .HasColumnName("purchase_amount")
                   .HasColumnType("DECIMAL");

            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("first_name")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("last_name")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.DateOrder)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("date_order")
                   .HasColumnType("DATETIME");


            builder.Property(x => x.CardNumber)
                   .IsRequired()
                   .HasMaxLength(16)
                   .HasColumnName("card_number")
                   .HasColumnType("VARCHAR(16)");

            builder.Property(x => x.CVV)
                   .IsRequired()
                   .HasMaxLength(3)
                   .HasColumnName("CVV")
                   .HasColumnType("VARCHAR(3)");

            builder.Property(x => x.ExpiryMonthYear)
                   .IsRequired()
                   .HasMaxLength(5)
                   .HasColumnName("expiry_month_year")
                   .HasColumnType("VARCHAR(5)");

            builder.Property(x => x.CartTotalItens)
                   .IsRequired()
                   .HasColumnName("cart_total_itens")
                   .HasColumnType("INT");

            builder.Property(x => x.PaymentStatus)
                   .IsRequired()
                   .HasColumnName("payment_status")
                   .HasColumnType("INT");

        }
    }
}
