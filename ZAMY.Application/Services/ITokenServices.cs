using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure
{
    public interface ITokenServices
    {
       //  Task<JwtSecurityToken> GetTokenAsync(IList<Claim> userClaims, IList<string> roles, IdentityUser user);
    }
}
