using ProjetMakerHubBack.Application.Utils;
using ProjetMakerHubBack.Domain.Entities;
using System.Security.Authentication;

namespace ProjetMakerHubBack.Application.Services
{
    public class AuthService(UserService _userService, JwtManager _jwtManager)
    {
        public string Login(string email, string password)
        {
            User? user = _userService.GetByUsername(email);

            if(user == null || !PasswordUtils.VerifyPassword(password, user.PasswordHash))
            {
                throw new AuthenticationException();
            }

            return _jwtManager.CreateToken(user.Id, user.DisplayName, user.Role.ToString());
        }
    }
}
