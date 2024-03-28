using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Infrastructure
{
    public interface ITokenServices
    {
        string GetToken(IdentityUser user);
    }
}
