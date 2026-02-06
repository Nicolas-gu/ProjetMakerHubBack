using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetMakerHubBack.Application.Utils
{
    public class JwtManager(IConfiguration _config)
    {
        private readonly JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();
        private readonly SecurityKey _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]!));

        public string CreateToken(Guid id, string name, string role)
        {
            JwtSecurityToken token = new JwtSecurityToken
            (
                _config["Jwt:Issuer"],
                null,
                [
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, role)
                ],
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(15),
                new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256)
            );
            return _handler.WriteToken(token);
        }

        public ClaimsPrincipal? ValidateToken(string token)
        {
            try
            {
                return _handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidIssuer = _config["Jwt:Issuer"],
                    IssuerSigningKey = _securityKey,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                }, out SecurityToken key);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
