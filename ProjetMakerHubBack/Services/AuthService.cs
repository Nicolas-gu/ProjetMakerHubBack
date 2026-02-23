using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.Application.Services;
using ProjetMakerHubBack.Application.Utils;
using ProjetMakerHubBack.Domain.Entities;
using System.Security.Authentication;

namespace ProjetMakerHubBack.API.Services
{
    public class AuthService(UserService _userService, JwtManager _jwtManager, AppDbContext _db)
    {
        /// <summary>
        /// Trouve user en DB, chexk mdp et génere token
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="AuthenticationException"></exception>
        public async Task<string> LoginAsync(string email, string password)
        {
            email = email.Trim().ToLowerInvariant();
            User? user = await _userService.GetByEmail(email);

            if(user == null || !PasswordUtils.VerifyPassword(password, user.PasswordHash))
            {
                throw new AuthenticationException();
            }

            return _jwtManager.CreateToken(user.Id, user.Email, user.DisplayName, user.Role.ToString());
        }

        /// <summary>
        /// Crée un User, avec password hash et crée un token
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<string> RegisterAsync(string name, string email, string password)
        {
            email = email.Trim().ToLowerInvariant();
            // si email pas utilisé
            bool exist = await _db.Users.AnyAsync(u => u.Email == email);
            if (exist)
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
            await _db.SaveChangesAsync();
            // Crée le token
            return _jwtManager.CreateToken(user.Id, user.Email, user.DisplayName, user.Role.ToString());
        }
    }
}
