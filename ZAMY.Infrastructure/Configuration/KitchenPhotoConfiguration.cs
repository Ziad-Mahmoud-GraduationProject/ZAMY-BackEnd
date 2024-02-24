using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAMY.Domain.Entities;

namespace ZAMY.Infrastructure.Configuration
{
    internal class KitchenPhotoConfiguration : IEntityTypeConfiguration<KitchenPhoto>
    {
        public void Configure(EntityTypeBuilder<KitchenPhoto> builder)
        {
            builder.HasKey(kitchenPhoto => kitchenPhoto.Id);

            builder.HasOne(kitchenPhoto => kitchenPhoto.Kitchen)
              .WithMany(kitchenPhoto => kitchenPhoto.KitchenPhotos)
              .HasForeignKey(kitchenPhoto => kitchenPhoto.KitchenId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
