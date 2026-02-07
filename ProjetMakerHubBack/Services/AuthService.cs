using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.Application.Utils;
using ProjetMakerHubBack.Domain.Entities;
using System.Security.Authentication;

namespace ProjetMakerHubBack.Application.Services
{
    public class AuthService(UserService _userService, JwtManager _jwtManager, AppDbContext _db)
    {
        public string Login(string email, string password)
        {
            User? user = _userService.GetByUsername(email);

            if(user == null || !PasswordUtils.VerifyPassword(password, user.PasswordHash))
            {
                throw new AuthenticationException();
            }

            return _jwtManager.CreateToken(user.Id, user.Email, user.DisplayName, user.Role.ToString());
        }

        public string Register(string name, string email, string password)
        {
            email = email.Trim().ToLowerInvariant();

            if(_db.Users.Any(u => u.Email == email))
            {
                throw new InvalidOperationException("Email déjà utilisé.");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                DisplayName = name,
                Email = email,
                PasswordHash = PasswordUtils.Hash(password),
                CreatedAt = DateTime.UtcNow,
                Role = Domain.Enums.Role.User
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            return _jwtManager.CreateToken(user.Id, user.Email, user.DisplayName, user.Role.ToString());
        }
    }
}
