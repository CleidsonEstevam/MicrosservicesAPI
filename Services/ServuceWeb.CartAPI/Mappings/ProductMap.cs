using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceWeb.CartAPI.Model.Entities;

namespace ServiceWeb.CartAPI.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductCode); // Definindo ProductCode como chave primária

            builder.Property(p => p.ProductCode)
                   .HasMaxLength(6) // Defina o tamanho máximo da chave primária ProductCode
                   .IsRequired()
                   .HasColumnName("product_code");
        }



    }
}
