using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure.Configuration
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(review =>review.Id);

            builder.HasOne(review => review.Customer)
              .WithMany(review => review.Reviews)
              .HasForeignKey(review => review.CustomerId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(review => review.Order)
               .WithMany(review => review.Reviews)
               .HasForeignKey(review => review.OrderId)
               .OnDelete(DeleteBehavior.Restrict);
        }

    }

}


