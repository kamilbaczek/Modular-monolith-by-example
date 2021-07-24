﻿using System;
using Divstack.Company.Estimation.Tool.Carts.Domain.Carts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divstack.Company.Estimation.Tool.Carts.Persistance.Domain.Carts
{
    internal class CartEntityTypeConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey("Id");
            builder.Property<Guid>("UserId").IsRequired();
            builder.Property("Status").IsRequired().HasMaxLength(50);
            builder.Property<DateTime>("CreationDate").IsRequired();
            builder.Property<DateTime>("LastActivity").IsRequired();


            builder.OwnsMany<CartItem>("Items", ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToTable("Items");
                ownedNavigationBuilder.Property<Guid>("ProductId");
                ownedNavigationBuilder.WithOwner().HasForeignKey("CartId");
                ownedNavigationBuilder.HasKey("Id");
            });
        }
    }
}