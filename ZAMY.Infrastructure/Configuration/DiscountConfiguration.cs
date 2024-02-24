using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure.Configuration
{
    internal class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(discount => discount.Id);

            builder.HasOne(discount => discount.Offer)
               .WithMany(discount => discount.Discounts)
               .HasForeignKey(discount => discount.OfferId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
