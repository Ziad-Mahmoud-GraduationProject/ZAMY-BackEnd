﻿

namespace ZAMY.Application.Services
{
    class TokenServices :  ITokenServices
    { 
        private readonly UserManager<IdentityUser> _userManager; 
        private readonly JWT _jwt;
        public TokenServices(UserManager<IdentityUser> UserManager,IOptions<JWT> jwt )
        { 
            _jwt = jwt.Value;
            _userManager = UserManager; 
        } 
        public async Task<JwtSecurityToken> GetTokenAsync(IdentityUser user)
        {

            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim(Claims.Roles, role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(Claims.UserIdLogin, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
