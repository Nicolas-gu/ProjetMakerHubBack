using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.Application.Utils;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Services
{
    public class IngredientService(AppDbContext _db)
    {
        public async Task<List<IngredientSearchResponseDto>> SearchAsync(IngredientSearchRequestDto dto)
        {
            var query = _db.Ingredients
                .AsNoTracking()
                .AsQueryable();

            // recherche par nom via input
            if (!string.IsNullOrWhiteSpace(dto.Q))
            {
                var searchData = dto.Q.Trim();
                query = query.Where(r => r.SearchName.Contains(searchData));
            }

            return await query
                .OrderByDescending(i => i.Name)
                .Select(i => new IngredientSearchResponseDto
                {
                    Name = i.Name
                }).ToListAsync();
        }

        public async Task<Ingredient> CreateAsync(IngredientCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException("Ingredient name is required.");
            }

            var normalizedName = NormalizeName.Normalize(dto.Name);
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

        public async Task DeleteAsync(Guid ingredientId)
        {
            Ingredient? toDelete = _db.Ingredients
                .Find(ingredientId);
            if (toDelete == null)
            {
                throw new KeyNotFoundException("Ingredient does not exist.");
            }

            var usedInRecipe = await _db.RecipeIngredients
                .AnyAsync(i => i.IngredientId == ingredientId);
            if (usedInRecipe)
            {
                throw new InvalidOperationException("Ingredient is used and cannot be deleted.");
            }

            _db.Ingredients.Remove(toDelete);
            await _db.SaveChangesAsync();
        }

    }
}
