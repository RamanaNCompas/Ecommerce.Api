﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasMany(s => s.ProductOrders)
                .WithOne(s => s.Order)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Shippment)
                .WithMany(s => s.Orders)
                .HasForeignKey("ShippmentdId");

            builder.HasOne(s => s.OrderDiscount)
                .WithMany(s => s.Orders)
                .HasForeignKey("OrderDiscountId");

            builder.HasOne(s => s.User)
                .WithMany(s => s.Orders)
                .HasForeignKey("UserId");
        }
    }
}