using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure.Configuration
{
    internal class CustomerPaymentConfiguration : IEntityTypeConfiguration<CustomerPayment>
    {
        public void Configure(EntityTypeBuilder<CustomerPayment> builder)
        {
            builder.HasKey(customerPayment => customerPayment.Id);

            builder.HasOne(customerPayment => customerPayment.Customer)
                .WithMany(customerPayment => customerPayment.CustomerPayments)
                .HasForeignKey(customerPayment => customerPayment.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(customerPayment => customerPayment.PaymentMethod)
              .WithMany(customerPayment => customerPayment.CustomerPayments)
              .HasForeignKey(customerPayment => customerPayment.PaymentMethodId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
