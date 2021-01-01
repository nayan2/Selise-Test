using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeliseTest.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeliseTest.Data.Persistence.EntityConfiguration
{
    class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(c => c.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
