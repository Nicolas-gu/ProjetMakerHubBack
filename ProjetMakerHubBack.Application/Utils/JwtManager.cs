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


        // creation d'un token
        public string CreateToken(Guid id,string email, string name, string role)
        {
            JwtSecurityToken token = new JwtSecurityToken
            (
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                [
                    // info presente dans le token
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, role)
                ],
                DateTime.UtcNow,

                //TODO add refresh token   validite 60min pour le dev
                DateTime.UtcNow.AddMinutes(60),
                new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256)
            );
            return _handler.WriteToken(token);
        }

        //public ClaimsPrincipal? ValidateToken(string token)
        //{
        //    try
        //    {
        //        return _handler.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidIssuer = _config["Jwt:Issuer"],
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = _securityKey,
        //            ValidateAudience = true,
        //            ValidAudience = _config["Jwt:Audience"],
        //            ValidateLifetime = true,
        //            ClockSkew = TimeSpan.FromMinutes(1)
        //        }, out SecurityToken key);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
    }
}
