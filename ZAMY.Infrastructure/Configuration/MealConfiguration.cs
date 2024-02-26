using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure.Configuration
{
    internal class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.HasKey(meal => meal.Id);

            builder.HasOne(meal => meal.Kitchen)
               .WithMany(meal => meal.Meals)
               .HasForeignKey(meal => meal.KitchenId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(meal => meal.MainCategory)
                .WithMany(meal => meal.Meals)
                .HasForeignKey(meal => meal.MainCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(meal => meal.SubCategory)
               .WithMany(meal => meal.Meals)
               .HasForeignKey(meal => meal.SubCategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
