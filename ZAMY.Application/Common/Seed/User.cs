using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAMY.Domain.Consts;

namespace ZAMY.Application.Common.Seed
{
    public static class Adduser
    {
        public static async Task SeedServerAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManger )
        {
            var defaultServer = new IdentityUser
            {
                Id = AppSettings.IdServer,
                UserName = "Server",
                Email = AppSettings.EmailServer,
                EmailConfirmed = true,
                PhoneNumber = "01129609244",
            };

            var user = await userManager.FindByEmailAsync(defaultServer.Email);

            if (user == null)
            {
                await userManager.CreateAsync(defaultServer, AppSettings.PasswordServer);
                await userManager.AddToRoleAsync(defaultServer, AppRole.Server.ToString());
            }
            
        }
    }
}
