using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.Application.Services
{
    public class UserService(AppDbContext _db)
    {
        public User? GetById(Guid id)
        {
            return _db.Users.Find(id);
        }

        public User? GetByUsername(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
