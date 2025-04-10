using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace QuanCafe.Helpers
{
    public class JwtHelper
    {
        private static string secretKey = "324DE023D01C0D80E8671824E53EF462"; // lưu ở nơi an toàn

        public static string GenerateToken(string username, int expireMinutes = 30)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username)
        };

            var token = new JwtSecurityToken(
                issuer: "MyApp",
                audience: "MyClient",
                claims: claims,
                expires: DateTime.Now.AddMinutes(expireMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static bool ValidateToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var parameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "MyApp",
                    ValidAudience = "MyClient",
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuerSigningKey = true
                };

                handler.ValidateToken(token, parameters, out _);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }

}
