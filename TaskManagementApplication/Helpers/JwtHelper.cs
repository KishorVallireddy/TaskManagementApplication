using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TaskManagementApplication.Helpers
{
    public static class JwtHelper
    {
        public static string GenerateAccessToken(int userId, IConfiguration config)
        {
            var claims = new[] { new Claim("UserId", userId.ToString()),
                new Claim(ClaimTypes.Role, "Admin"),
    new Claim(ClaimTypes.Role, "User")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["Jwt:Key"]));

            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(
                    int.Parse(config["Jwt:AccessTokenMinutes"])),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
