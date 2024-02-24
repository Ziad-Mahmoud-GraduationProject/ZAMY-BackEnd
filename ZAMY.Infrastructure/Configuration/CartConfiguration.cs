using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure.Configuration
{
    internal class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(cart =>cart.Id);

            builder.HasOne(cart => cart.Customer)
               .WithMany(cart => cart.Carts)
               .HasForeignKey(cart => cart.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
