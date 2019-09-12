using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.DatabaseContext.FluentConfiguration
{
    internal class CustomerFluentConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Address).IsRequired();
            builder.Property(c => c.LoyaltyPoint).IsRequired();
        }
    }
}