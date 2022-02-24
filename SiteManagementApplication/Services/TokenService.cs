using Microsoft.IdentityModel.Tokens;
using SiteManagementApplication.Operations.UserOperations.Queries.LoginUser;
using SiteManagementApplication.Settings;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SiteManagementApplication.Services
{
    internal class TokenService
    {
        private const double EXPIRE_HOURS = 1.0;
        public static string CreateToken(LoginUserModel user)
        {
            var key = Encoding.ASCII.GetBytes(JwtSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user")
                }),
                Expires = DateTime.UtcNow.AddHours(EXPIRE_HOURS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
