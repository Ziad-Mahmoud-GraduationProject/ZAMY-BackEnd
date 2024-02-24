using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure.Configuration
{
    internal class CarItemItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(cartItem => cartItem.Id);

            builder.HasOne(cartItem => cartItem.Meal)
               .WithMany(cartItem => cartItem.CartItems)
               .HasForeignKey(cartItem => cartItem.MealId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cartItem => cartItem.Cart)
               .WithMany(cartItem => cartItem.CartItems)
               .HasForeignKey(cartItem => cartItem.CartId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
