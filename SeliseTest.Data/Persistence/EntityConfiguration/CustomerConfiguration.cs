using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeliseTest.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeliseTest.Data.Persistence.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(1000)
                .IsRequired();

            builder.HasAlternateKey(x => x.Email);

            builder.HasOne(x => x.UserGroup)
                .WithMany(x => x.Customers)
                .HasForeignKey(c => c.UserGroupId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
