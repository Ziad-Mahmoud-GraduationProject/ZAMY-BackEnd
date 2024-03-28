
namespace ZAMY.Application.Common.Seed
{
    public static class AddRole
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManger)
        {
            if (!roleManger.Roles.Any())
            {
                await roleManger.CreateAsync(new IdentityRole() { Name = AppRole.Server.ToString() });
            }
        }
    }
}
