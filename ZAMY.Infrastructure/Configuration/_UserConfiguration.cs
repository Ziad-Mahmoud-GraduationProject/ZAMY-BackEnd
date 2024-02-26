using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAMY.Domain.Common;

namespace ZAMY.Infrastructure.Configuration
{
    internal class _UserConfiguration : IEntityTypeConfiguration<_UserEntity>
    {
        public void Configure(EntityTypeBuilder<_UserEntity> builder)
        {
            builder.HasKey(user => user.Id);
        }
    }
}
