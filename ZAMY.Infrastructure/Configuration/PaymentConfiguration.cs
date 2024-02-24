using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure.Configuration
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(payment => payment.Id);

            builder.HasOne(payment => payment.Customer)
                .WithMany(payment => payment.Payments)
                .HasForeignKey(payment => payment.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(payment => payment.Order)
               .WithMany(payment => payment.Payments)
               .HasForeignKey(payment => payment.OrderId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
