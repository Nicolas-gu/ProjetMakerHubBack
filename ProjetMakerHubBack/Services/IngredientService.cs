using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Services
{
    public class IngredientService(AppDbContext _db)
    {
        public async Task<Ingredient> CreateAsync(IngredientCreateDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException("Ingredient name is required.");
            }

            var normalizedName = Normalize(dto.Name);
            var existing = await _db.Ingredients
                .FirstOrDefaultAsync(i => i.SearchName == normalizedName);

            if(existing != null)
            {
                throw new InvalidOperationException("Ingredient already exists.");
            }

            var ingredient = new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                SearchName = normalizedName,
                CreatedAt = DateTime.UtcNow,
            };

            _db.Ingredients.Add(ingredient);
            await _db.SaveChangesAsync();

            return ingredient;
        }
        private static string Normalize(string name)
        {
            return name
                .Trim()
                .ToLowerInvariant()
                .Replace(" ", "");
        }
    }
}
