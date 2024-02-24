using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAMY.Domain.Entities;

namespace ZAMY.Infrastructure.Configuration
{
    internal class MealPhotoConfiguration : IEntityTypeConfiguration<MealPhoto>
    {
        public void Configure(EntityTypeBuilder<MealPhoto> builder)
        {
            builder.HasKey(mealPhoto => mealPhoto.Id);

            builder.HasOne(mealPhoto => mealPhoto.Meal)
              .WithMany(mealPhoto => mealPhoto.MealPhotos)
              .HasForeignKey(mealPhoto => mealPhoto.MealId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
