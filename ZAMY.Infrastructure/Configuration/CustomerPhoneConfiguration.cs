using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure.Configuration
{
    internal class CustomerPhoneConfiguration : IEntityTypeConfiguration<CustomerPhone>
    {
        public void Configure(EntityTypeBuilder<CustomerPhone> builder)
        {
            builder.HasKey(customerPhone => customerPhone.Id);

            builder.HasOne(customerPhone => customerPhone.Customer)
                .WithMany(customerPhone => customerPhone.CustomerPhones)
                .HasForeignKey(customerPhone => customerPhone.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
