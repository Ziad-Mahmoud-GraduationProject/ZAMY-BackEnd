using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAMY.Domain.Entities;

namespace ZAMY.Infrastructure.Configuration
{
    internal class KitchenOwnerPhoneConfiguration : IEntityTypeConfiguration<KitchenOwnerPhone>
    {
        public void Configure(EntityTypeBuilder<KitchenOwnerPhone> builder)
        {
            builder.HasKey(kitchenPhone => kitchenPhone.Id);

            builder.HasOne(kitchenPhone => kitchenPhone.Kitchen)
              .WithMany(kitchenPhone => kitchenPhone.KitchenOwnerPhones)
              .HasForeignKey(kitchenPhone => kitchenPhone.KitchenId)
              .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
