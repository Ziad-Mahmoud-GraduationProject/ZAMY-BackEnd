using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure.Configuration
{
    internal class KitchenConfiguration : IEntityTypeConfiguration<Kitchen>
    {
        public void Configure(EntityTypeBuilder<Kitchen> builder)
        {
            builder.HasKey(kitchen => kitchen.Id);
        }
    }
}
