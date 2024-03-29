﻿using Microsoft.EntityFrameworkCore;
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
        }
    }
}
