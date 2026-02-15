using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Services
{
    public class PantryService(AppDbContext _db)
    {
        public async Task<List<PantryItemDto>> GetAsync(Guid userId)
        {
            return await _db.PantryItems
                .AsNoTracking()
                .Where(p => p.UserId == userId)
                .OrderBy(p => p.Ingredient.Name)
                .Select(p => new PantryItemDto
                {
                    Id = p.Id,
                    IngredientId = p.IngredientId,
                    IngredientName = p.Ingredient.Name,
                    Quantity = p.Quantity,
                    Unit = p.Unit,
                    UpdatedAt = p.UpdateAt
                })
                .ToListAsync();
        }

        public async Task<PantryItemDto> UpsertAsync(Guid userId, PantryUpdateDto dto)
        {
            if(dto.IngredientId == Guid.Empty)
            {
                throw new ArgumentException("IngredientId required.");
            }
            if (dto.Quantity < 0)
            {
                throw new ArgumentException("Quantity must be >= 0.");
            }

            // check si ingredient existe
            var ing = await _db.Ingredients
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == dto.IngredientId);
            if (ing == null)
            {
                throw new KeyNotFoundException("Ingredient not found.");
            }


            var existing = await _db.PantryItems
                .FirstOrDefaultAsync(p => p.UserId == userId && p.IngredientId == dto.IngredientId);

            // si existe mais stock 0 supprime
            if(dto.Quantity == 0)
            {
                if (existing != null)
                {
                    _db.PantryItems .Remove(existing);
                    await _db.SaveChangesAsync();
                }
                return null;
            }

            var q = Math.Round(dto.Quantity, 2);

            if (existing == null)
            {
                existing = new PantryItem
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    IngredientId = dto.IngredientId,
                    Quantity = q,
                    Unit = dto.Unit,
                    UpdateAt = DateTime.UtcNow
                };
                _db.PantryItems.Add(existing);
            }
            else
            {
                existing.Quantity = q;
                existing.Unit = dto.Unit;
                existing.UpdateAt = DateTime.UtcNow;
            }

            await _db.SaveChangesAsync();

            return new PantryItemDto
            {
                Id = existing.Id,
                IngredientId = ing.Id,
                IngredientName = ing.Name,
                Quantity = existing.Quantity,
                Unit = existing.Unit,
                UpdatedAt = existing.UpdateAt
            };

        }

        public async Task DeleteAsync(Guid userId, Guid pantryItemId)
        {
            var item = await _db.PantryItems
                .FirstOrDefaultAsync(p => p.Id == pantryItemId && p.UserId == userId);

            if (item == null)
                throw new KeyNotFoundException("Pantry item not found.");

            _db.PantryItems.Remove(item);
            await _db.SaveChangesAsync();
        }


    }
}
