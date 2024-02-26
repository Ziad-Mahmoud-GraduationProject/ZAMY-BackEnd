using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);


            builder.HasOne(order => order.Customer)
               .WithMany(order => order.Orders)
               .HasForeignKey(order => order.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(order => order.Kitchen)
             .WithMany(order => order.Orders)
             .HasForeignKey(order => order.KitchenId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
