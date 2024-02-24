using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAMY.Domain.Entities;

namespace ZAMY.Infrastructure.Configuration
{
    internal class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasKey(customerAddress => customerAddress.Id);

            builder.HasOne(customerAddress => customerAddress.Customer)
                .WithMany(customerAddress => customerAddress.CustomerAddresses)
                .HasForeignKey(customerAddress => customerAddress.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
