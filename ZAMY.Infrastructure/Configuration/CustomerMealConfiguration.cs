using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure.Configuration
{
    internal class CustomerMealConfiguration : IEntityTypeConfiguration<CustomerMeal>
    {
        public void Configure(EntityTypeBuilder<CustomerMeal> builder)
        {
            builder.HasKey(customerMeal => customerMeal.Id);

            builder.HasOne(customerMeal => customerMeal.Customer)
                .WithMany(customerMeal => customerMeal.CustomerMeals)
                .HasForeignKey(customerMeal => customerMeal.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(customerMeal => customerMeal.Meal)
               .WithMany(customerMeal => customerMeal.CustomerMeals)
               .HasForeignKey(customerMeal => customerMeal.MealId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
