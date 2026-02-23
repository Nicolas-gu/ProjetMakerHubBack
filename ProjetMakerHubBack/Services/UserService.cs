using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.Application.Services
{
    public class UserService(AppDbContext _db)
    {
        // Retourne le premier User trouvé via son email
        public async Task<User?> GetByEmail(string email)
        {
            return await _db.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
