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

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(150)
                   .HasColumnName("name")
                   .HasColumnType("VARCHAR(150)");

            builder.Property(p => p.Description)
                   .HasMaxLength(200)
                   .HasColumnName("description")
                   .HasColumnType("VARCHAR(200)");

            builder.Property(p => p.Supplier)
                   .HasMaxLength(50)
                   .HasColumnName("supplier")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.Category)
                   .HasMaxLength(50)
                   .HasColumnName("category")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.PackagingType)
                   .HasMaxLength(20)
                   .HasColumnName("packaging_type")
                   .HasColumnType("VARCHAR(20)");

            builder.Property(p => p.PackagingQuantity)
                   .HasColumnName("packaging_quantity")
                   .HasColumnType("INT");

            builder.Property(p => p.BarCode)
                   .HasMaxLength(13)
                   .HasColumnName("bar_code")
                   .HasColumnType("VARCHAR(13)");

            builder.Property(p => p.Origin)
                   .HasMaxLength(1)
                   .HasColumnName("bar_code")
                   .HasColumnType("CHAR(1)");

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnName("price")
                   .HasColumnType("DECIMAL");


        }



    }
}
