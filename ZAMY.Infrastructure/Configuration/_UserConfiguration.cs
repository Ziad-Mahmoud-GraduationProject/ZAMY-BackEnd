using Authentication.Authorization.Helper.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZAMY.Infrastructure.Configuration
{
    internal class _UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(user => user.Id);
        }
    }
}
