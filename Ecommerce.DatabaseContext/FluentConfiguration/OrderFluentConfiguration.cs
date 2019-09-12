using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.DatabaseContext.FluentConfiguration
{
    internal class OrderFluentConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.OrderNo).IsRequired();
            builder.Property(o => o.OrderDate).IsRequired();
        }
    }
}