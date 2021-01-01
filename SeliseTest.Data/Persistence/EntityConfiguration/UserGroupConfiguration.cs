using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeliseTest.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeliseTest.Data.Persistence.EntityConfiguration
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                    .HasMaxLength(1000)
                    .IsRequired();

            builder.Property(x => x.Discount)
                .IsRequired();
        }
    }
}
