using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeliseTest.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeliseTest.Data.Persistence.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                    .HasMaxLength(1000)
                    .IsRequired();
        }
    }
}
